using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiniSupermarket.API.Data;
using System.Text;

// 1. Khởi tạo WebApplicationBuilder ĐẦU TIÊN
var builder = WebApplication.CreateBuilder(args);

// 2. Lấy Connection String và JWT Secret từ Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtSecret = builder.Configuration["JwtSettings:Secret"];
if (string.IsNullOrWhiteSpace(jwtSecret) || jwtSecret.Length < 32)
{
    throw new InvalidOperationException(
        "Thiếu JwtSettings:Secret hoặc secret quá ngắn. Hãy cấu hình bằng User Secrets hoặc biến môi trường.");
}

// 3. Đăng ký DbContext với SQL Server
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));

// 4. Cấu hình JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// 5. Cấu hình Swagger UI có hỗ trợ nút Authorize JWT
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniSupermarket API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Chỉ cần dán JWT Token vào ô bên dưới (không cần nhập chữ Bearer):"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// 6. Cấu hình CORS để client (WinForms/trình duyệt) gọi được vào API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWinForms", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddControllers();

// 7. Build ứng dụng
var app = builder.Build();

// 8. Cấu hình HTTP Request Pipeline (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS phải đặt trước Authentication/Authorization
app.UseCors("AllowWinForms");

// Thứ tự Middleware bắt buộc: Authentication TRƯỚC, Authorization SAU
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();