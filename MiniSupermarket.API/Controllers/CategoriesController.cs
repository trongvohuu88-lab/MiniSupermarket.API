using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Tất cả endpoint đều yêu cầu đăng nhập
    public class CategoriesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public CategoriesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. READ: Lấy toàn bộ danh mục (Admin, Warehouse & Cashier)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.CategoryId)
                .Select(c => new CategoryResponseDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return Ok(list);
        }

        // 2. READ: Lấy chi tiết 1 danh mục
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .Where(c => c.CategoryId == id)
                .Select(c => new CategoryResponseDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng trong CSDL!" });
            }
            return Ok(category);
        }

        // 3. SEARCH: Tìm kiếm danh mục theo tên gần đúng
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            var key = keyword.Trim();
            var result = await _context.Categories
                .AsNoTracking()
                .Where(c => c.CategoryName.Contains(key))
                .Select(c => new CategoryResponseDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
            return Ok(result);
        }

        // 4. CREATE: Thêm mới nhóm hàng (Admin, Warehouse)
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var name = dto.CategoryName.Trim();
            if (await _context.Categories.AnyAsync(c => c.CategoryName == name))
            {
                return BadRequest(new { message = "Tên nhóm hàng đã tồn tại!" });
            }

            var newCat = new Category { CategoryName = name, Description = dto.Description };
            _context.Categories.Add(newCat);
            await _context.SaveChangesAsync();

            var response = new CategoryResponseDto
            {
                CategoryId = newCat.CategoryId,
                CategoryName = newCat.CategoryName,
                Description = newCat.Description
            };
            return CreatedAtAction(nameof(GetById), new { id = newCat.CategoryId }, response);
        }

        // 5. UPDATE: Cập nhật nhóm hàng (Admin, Warehouse)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần sửa!" });
            }

            var name = dto.CategoryName.Trim();
            if (await _context.Categories.AnyAsync(c => c.CategoryName == name && c.CategoryId != id))
            {
                return BadRequest(new { message = "Tên nhóm hàng đã tồn tại!" });
            }

            cat.CategoryName = name;
            cat.Description = dto.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa nhóm hàng (Admin, Warehouse)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần xóa!" });
            }

            // Không cho xóa nhóm hàng còn sản phẩm (tránh lỗi ràng buộc khóa ngoại)
            if (await _context.Products.AnyAsync(p => p.CategoryId == id))
            {
                return BadRequest(new { message = "Nhóm hàng còn sản phẩm, không thể xóa!" });
            }

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
