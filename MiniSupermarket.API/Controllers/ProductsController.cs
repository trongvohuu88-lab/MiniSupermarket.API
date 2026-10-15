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