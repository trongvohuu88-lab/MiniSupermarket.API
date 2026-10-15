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

        // 1. READ: Lấy toàn bộ danh mục (Admin & Cashier)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // 2. READ: Lấy chi tiết 1 danh mục (Admin & Cashier)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng trong CSDL!" });
            }
            return Ok(category);
        }

        // 3. SEARCH: Tìm kiếm danh mục (Admin & Cashier)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            var result = await _context.Categories
                .Where(c => c.CategoryName.Contains(keyword))
                .ToListAsync();
            return Ok(result);
        }

        // 4. CREATE: Thêm mới nhóm hàng (Chỉ Admin)
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Create([FromBody] Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(newCat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCat.CategoryId }, newCat);
        }

        // 5. UPDATE: Cập nhật nhóm hàng (Chỉ Admin)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] Category updateCat)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần sửa!" });
            }

            cat.CategoryName = updateCat.CategoryName;
            cat.Description = updateCat.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa nhóm hàng (Chỉ Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound(new { message = "Không tìm thấy nhóm hàng cần xóa!" });
            }

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}