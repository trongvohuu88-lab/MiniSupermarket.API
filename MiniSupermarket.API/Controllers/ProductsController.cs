using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        [Authorize(Roles = "Admin,Warehouse,Cashier")] // Cho phép Admin, Warehouse và Cashier xem danh sách
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.ProductId)
                .AsNoTracking()
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/Products/paged?keyword=sua&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        [Authorize(Roles = "Admin,Warehouse,Cashier")]
        public async Task<IActionResult> GetPagedProducts(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            // 1. Kiểm tra tham số trang đầu vào hợp lệ
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5; // Mặc định 5 dòng, tối đa 50 dòng

            // 2. Khởi tạo truy vấn LINQ IQueryable kết hợp Eager Loading (.Include)
            // AsNoTracking giúp tối ưu hóa bộ nhớ RAM cho các truy vấn chỉ đọc dữ liệu
            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            // 3. Lọc theo từ khóa tìm kiếm (nếu người dùng có nhập)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim().ToLower();
                query = query.Where(p => p.ProductName.ToLower().Contains(search)
                                        || p.Barcode.Contains(search));
            }

            // 4. Đếm tổng số lượng bản ghi thỏa mãn điều kiện
            int totalItems = await query.CountAsync();

            // 5. Tính toán tổng số trang
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // 6. Áp dụng toán tử Skip và Take để phân trang trực tiếp dưới SQL Server
            var items = await query
                .OrderBy(p => p.ProductId) // Bắt buộc phải OrderBy trước khi Skip/Take
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                })
                .ToListAsync();

            // 7. Đóng gói kết quả trả về cho Client
            var response = new PagedResult<ProductItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return Ok(response);
        }

        // GET: api/Products/with-category  (Bài tập 1 - Eager Loading)
        [HttpGet("with-category")]
        [Authorize(Roles = "Admin,Warehouse,Cashier")]
        public async Task<IActionResult> GetWithCategory()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .OrderBy(p => p.ProductId)
                .Select(p => new
                {
                    p.ProductId,
                    p.Barcode,
                    p.ProductName,
                    p.Price,
                    p.StockQuantity,
                    IsLowStock = p.StockQuantity <= 20,
                    p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : null
                })
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Warehouse,Cashier")] // Cho phép Admin, Warehouse và Cashier xem chi tiết
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound(new { message = "Không tìm thấy sản phẩm!" });

            return Ok(product);
        }

        // GET: api/Products/search?keyword=abc&categoryId=1
        [HttpGet("search")]
        [Authorize(Roles = "Admin,Warehouse,Cashier")] // Giúp thu ngân quét mã vạch và tìm kiếm sản phẩm khi bán hàng POS
        public async Task<IActionResult> Search([FromQuery] string? keyword, [FromQuery] int? categoryId)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var key = keyword.Trim();
                query = query.Where(p => p.ProductName.Contains(key) || p.Barcode.Contains(key));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var list = await query
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // POST: api/Products
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")] // Chỉ Admin và Warehouse được thêm sản phẩm
        public async Task<IActionResult> Create([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existBarcode = await _context.Products.AnyAsync(p => p.Barcode == newProduct.Barcode);
            if (existBarcode)
                return BadRequest(new { message = "Mã vạch đã tồn tại!" });

            var cat = await _context.Categories.FindAsync(newProduct.CategoryId);
            if (cat == null)
                return BadRequest(new { message = "Danh mục không tồn tại!" });

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            await _context.Entry(newProduct).Reference(p => p.Category).LoadAsync();

            return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")] // Chỉ Admin và Warehouse được sửa sản phẩm
        public async Task<IActionResult> Update(int id, [FromBody] Product updateProduct)
        {
            if (id != updateProduct.ProductId)
                return BadRequest(new { message = "Mã sản phẩm không khớp!" });

            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
                return NotFound(new { message = "Không tìm thấy sản phẩm!" });

            var existBarcode = await _context.Products
                .AnyAsync(p => p.Barcode == updateProduct.Barcode && p.ProductId != id);
            if (existBarcode)
                return BadRequest(new { message = "Mã vạch đã tồn tại!" });

            var cat = await _context.Categories.FindAsync(updateProduct.CategoryId);
            if (cat == null)
                return BadRequest(new { message = "Danh mục không tồn tại!" });

            prod.Barcode = updateProduct.Barcode;
            prod.ProductName = updateProduct.ProductName;
            prod.Price = updateProduct.Price;
            prod.StockQuantity = updateProduct.StockQuantity;
            prod.CategoryId = updateProduct.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Warehouse")] // Chỉ Admin và Warehouse được xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
                return NotFound(new { message = "Không tìm thấy sản phẩm!" });

            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}