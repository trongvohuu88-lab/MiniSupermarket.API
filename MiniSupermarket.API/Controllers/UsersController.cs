using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin quản trị tài khoản
    public class UsersController : ControllerBase
    {
        private static readonly string[] ValidRoles = { "Admin", "Cashier", "Warehouse" };

        [HttpGet]
        public IActionResult GetAll() =>
            Ok(UserStore.Users.Select(u => new { u.Id, u.Username, u.FullName, u.Role, u.IsActive }));

        [HttpPost]
        public IActionResult Create([FromBody] AppUser req)
        {
            if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new { message = "Tên đăng nhập và mật khẩu không được trống!" });
            if (!ValidRoles.Contains(req.Role))
                return BadRequest(new { message = "Vai trò không hợp lệ!" });
            if (UserStore.Users.Any(u => u.Username.Equals(req.Username, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { message = "Tên đăng nhập đã tồn tại!" });

            req.Id = UserStore.Users.Max(u => u.Id) + 1;
            req.IsActive = true;
            UserStore.Users.Add(req);
            return Ok(new { req.Id, req.Username, req.FullName, req.Role, req.IsActive });
        }

        [HttpPut("{id:int}/reset-password")]
        public IActionResult ResetPassword(int id)
        {
            var u = UserStore.Users.FirstOrDefault(x => x.Id == id);
            if (u == null) return NotFound(new { message = "Không tìm thấy tài khoản!" });
            u.Password = "123456";
            return NoContent();
        }

        [HttpPut("{id:int}/toggle-lock")]
        public IActionResult ToggleLock(int id)
        {
            var u = UserStore.Users.FirstOrDefault(x => x.Id == id);
            if (u == null) return NotFound(new { message = "Không tìm thấy tài khoản!" });
            if (u.Username == User.Identity?.Name)
                return BadRequest(new { message = "Không thể tự khóa tài khoản đang đăng nhập!" });
            u.IsActive = !u.IsActive;
            return Ok(new { u.Id, u.IsActive });
        }
    }
}
