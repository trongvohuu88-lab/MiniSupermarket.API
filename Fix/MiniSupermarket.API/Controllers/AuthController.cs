using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MiniSupermarket.API.Models;
using MiniSupermarket.API.Migrations;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, Data.SupermarketDbContext context) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly Data.SupermarketDbContext _context = context;

        // Endpoint Đăng nhập: POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // Tra cứu tài khoản trong bảng Users của SQL Server
            // (Lưu ý học tập: PasswordHash đang là chuỗi seed theo đề; thực tế nên băm bằng BCrypt)
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u =>
                u.Username == request.Username && u.PasswordHash == request.Password);

            if (user != null)
            {
                if (!user.IsActive)
                    return Unauthorized(new { success = false, message = "Tài khoản đã bị khóa!" });

                var token = GenerateJwtToken(user.Username, user.Role);
                return Ok(new { success = true, token, role = user.Role, fullName = user.FullName });
            }

            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Lấy khóa bí mật từ appsettings.json
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Thời hạn token là 2 tiếng
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
