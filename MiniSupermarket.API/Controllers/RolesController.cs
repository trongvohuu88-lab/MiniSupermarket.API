using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Toàn bộ các API vai trò chỉ dành riêng cho Admin
    public class RolesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public RolesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. READ: Lấy danh sách vai trò từ bảng Roles trong CSDL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _context.Roles.AsNoTracking().OrderBy(r => r.Id).ToListAsync();
            return Ok(roles);
        }

        // 2. READ: Lấy chi tiết vai trò
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò!" });
            }
            return Ok(role);
        }

        // 3. CREATE: Thêm vai trò mới
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var name = dto.RoleName.Trim();
            if (await _context.Roles.AnyAsync(r => r.RoleName == name))
            {
                return BadRequest(new { message = "Tên vai trò đã tồn tại!" });
            }

            var newRole = new Role { RoleName = name, Description = dto.Description };
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
        }

        // 4. UPDATE: Cập nhật vai trò
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò cần sửa!" });
            }

            var name = dto.RoleName.Trim();
            if (await _context.Roles.AnyAsync(r => r.RoleName == name && r.Id != id))
            {
                return BadRequest(new { message = "Tên vai trò đã tồn tại!" });
            }

            role.RoleName = name;
            role.Description = dto.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 5. DELETE: Xóa vai trò
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound(new { message = "Không tìm thấy vai trò cần xóa!" });
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
