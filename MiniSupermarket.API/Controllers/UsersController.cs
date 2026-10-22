using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin quản trị tài khoản
    public class UsersController : ControllerBase
    {
        private static readonly string[] ValidRoles = { "Admin", "Cashier", "Warehouse" };
        private readonly SupermarketDbContext _context;

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/users  (giữ nguyên dạng JSON { Id, Username, FullName, Role, IsActive } cho WinForm)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users
                .AsNoTracking()
                .OrderBy(u => u.UserId)
                .Select(u => new { Id = u.UserId, u.Username, u.FullName, u.Role, u.IsActive })
                .ToListAsync();
            return Ok(users);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new { message = "Tên đăng nhập và mật khẩu không được trống!" });
            if (string.IsNullOrWhiteSpace(req.FullName))
                return BadRequest(new { message = "Họ tên không được để trống!" });
            if (!ValidRoles.Contains(req.Role))
                return BadRequest(new { message = "Vai trò không hợp lệ!" });
            if (await _context.Users.AnyAsync(u => u.Username == req.Username))
                return Conflict(new { message = "Tên đăng nhập đã tồn tại!" });

            var user = new User
            {
                Username = req.Username.Trim(),
                PasswordHash = req.Password,
                FullName = req.FullName.Trim(),
                Role = req.Role,
                IsActive = true
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Id = user.UserId, user.Username, user.FullName, user.Role, user.IsActive });
        }

        // PUT: api/users/5/reset-password
        [HttpPut("{id:int}/reset-password")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return NotFound(new { message = "Không tìm thấy tài khoản!" });
            u.PasswordHash = "123456";
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/users/5/toggle-lock
        [HttpPut("{id:int}/toggle-lock")]
        public async Task<IActionResult> ToggleLock(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return NotFound(new { message = "Không tìm thấy tài khoản!" });
            if (u.Username == User.Identity?.Name)
                return BadRequest(new { message = "Không thể tự khóa tài khoản đang đăng nhập!" });
            u.IsActive = !u.IsActive;
            await _context.SaveChangesAsync();
            return Ok(new { Id = u.UserId, u.IsActive });
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
    }
}
