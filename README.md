# 🛒 MiniSupermarket System

**Môn học:** Lập trình Ứng dụng .NET Core
**Mã môn:** 229162
**Buổi thực hành:** Buổi 1 - CRUD Web API & Buổi 2 - Bảo mật và Phân quyền JWT

---

# 📌 BUỔI 1 - XÂY DỰNG WEB API QUẢN LÝ DANH MỤC VÀ WINFORMS CLIENT

## 🏗️ 1. Mô hình Kiến trúc Hệ thống

Dự án được xây dựng theo mô hình **Client - Server**, tách biệt giữa Backend và Frontend:

* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API chịu trách nhiệm xử lý logic nghiệp vụ, quản lý dữ liệu và cung cấp RESTful API.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms đóng vai trò máy trạm, sử dụng `HttpClient` để gọi dữ liệu từ API và hiển thị lên `DataGridView`.

---

## 🛠️ 2. Công nghệ Sử dụng

* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Controllers, In-Memory Data, LINQ
* **Frontend:** Windows Forms (.NET 8.0)
* **HTTP Client:** `System.Net.Http.Json`
* **Kiểm thử:** Swagger UI

---

## 📂 3. Cấu trúc Solution

```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   └── CategoriesController.cs
│   ├── Models/
│   │   └── Category.cs
│   └── Program.cs
│
└── MiniSupermarket.WinForms/
    └── FormCategoryManagement.cs
```

---

## ⚙️ 4. Chức năng CRUD

Web API cung cấp các chức năng quản lý danh mục:

| Phương thức | Endpoint               | Chức năng              |
| ----------- | ---------------------- | ---------------------- |
| GET         | `/api/categories`      | Lấy danh sách danh mục |
| GET         | `/api/categories/{id}` | Lấy danh mục theo ID   |
| POST        | `/api/categories`      | Thêm danh mục          |
| PUT         | `/api/categories/{id}` | Cập nhật danh mục      |
| DELETE      | `/api/categories/{id}` | Xóa danh mục           |

WinForms Client sử dụng `HttpClient` để thực hiện các thao tác trên và hiển thị dữ liệu trên `DataGridView`.

---

## 🚀 5. Chạy và Kiểm thử Buổi 1

### Backend

Mở Solution bằng Visual Studio 2022.

Chọn:

```text
MiniSupermarket.API
→ Set as Startup Project
→ F5
```

Swagger UI được sử dụng để kiểm tra các API CRUD.

### Frontend

Chọn:

```text
MiniSupermarket.WinForms
→ Debug
→ Start new instance
```

Thực hiện kiểm tra:

* Tải danh sách danh mục.
* Thêm danh mục.
* Sửa danh mục.
* Xóa danh mục.
* Tìm kiếm danh mục.

---

# 🔐 BUỔI 2 - BẢO MẬT & PHÂN QUYỀN JWT

Sau khi hoàn thành các chức năng CRUD ở Buổi 1, hệ thống được nâng cấp thêm **Authentication và Authorization bằng JWT**.

Mục tiêu của Buổi 2 là xây dựng cơ chế đăng nhập, cấp JWT Token và phân quyền người dùng giữa **Admin** và **Cashier**.

---

## 🔑 6. Authentication và Authorization

### Authentication - Xác thực

Dùng để xác định người dùng là ai.

Hệ thống sử dụng hai tài khoản mẫu:

| Username  | Password | Role    |
| --------- | -------- | ------- |
| `admin`   | `123456` | Admin   |
| `cashier` | `123456` | Cashier |

### Authorization - Phân quyền

Dùng để kiểm tra người dùng có quyền thực hiện một chức năng hay không.

Ví dụ:

* `Admin`: Có quyền truy cập chức năng quản trị.
* `Cashier`: Có quyền truy cập chức năng dành cho nhân viên bán hàng.

---

## 🪪 7. JWT Authentication

JWT được sử dụng để xác thực người dùng theo cơ chế **Stateless Authentication**.

JWT gồm 3 thành phần:

```text
Header.Payload.Signature
```

Trong đó:

* **Header:** Chứa thuật toán mã hóa.
* **Payload:** Chứa các Claims như Username, Role và thời hạn.
* **Signature:** Chữ ký dùng Secret Key để chống giả mạo.

Server không cần lưu Session của người dùng. Client nhận Token và gửi lại Token trong các request tiếp theo.

---

## 📦 8. Cài đặt các Package JWT

Trong project `MiniSupermarket.API`, cài đặt:

```text
System.IdentityModel.Tokens.Jwt
Microsoft.AspNetCore.Authentication.JwtBearer
```

Hai package được sử dụng để tạo JWT Token và xác thực JWT Bearer trong Web API.

---

## 🔐 9. AuthController

Tạo `AuthController` để xử lý chức năng đăng nhập.

Endpoint:

```text
POST /api/auth/login
```

Request:

```json
{
    "username": "admin",
    "password": "123456"
}
```

Nếu đăng nhập thành công, API trả về:

```json
{
    "success": true,
    "token": "JWT_TOKEN",
    "role": "Admin"
}
```

Nếu tài khoản hoặc mật khẩu không chính xác:

```text
401 Unauthorized
```

---

## ⚙️ 10. Cấu hình JWT trong Program.cs

Backend sử dụng `JwtBearer` để kiểm tra JWT Token:

```csharp
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(jwtSecret)
                ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
});
```

Middleware:

```csharp
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
```

`UseAuthentication()` phải được đặt trước `UseAuthorization()`.

---

## 🛡️ 11. Bảo vệ CategoriesController

Sau khi có JWT, `CategoriesController` được bảo vệ bằng:

```csharp
[Authorize]
```

Điều này yêu cầu Client phải gửi JWT Token hợp lệ khi gọi các API trong Controller.

Ví dụ:

```csharp
[Authorize]
public class CategoriesController : ControllerBase
{
    // Các chức năng CRUD từ Buổi 1
}
```

Như vậy, **CRUD của Buổi 1 vẫn được giữ lại**, nhưng từ Buổi 2 các API có thể yêu cầu người dùng đăng nhập trước khi sử dụng.

---

# 👮 12. Phân quyền Admin và Cashier

### Chức năng dành cho Admin

```csharp
[HttpGet("admin-dashboard")]
[Authorize(Roles = "Admin")]
public IActionResult GetAdminDashboard()
{
    return Ok(new
    {
        message = "Chào mừng Admin!"
    });
}
```

Endpoint:

```text
GET /api/categories/admin-dashboard
```

Chỉ tài khoản có Role `Admin` mới truy cập được.

### Chức năng dành cho nhân viên

```csharp
[HttpGet("staff-pos")]
[Authorize(Roles = "Admin,Cashier")]
public IActionResult GetStaffPos()
{
    return Ok(new
    {
        message = "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng."
    });
}
```

Cả `Admin` và `Cashier` đều có thể truy cập endpoint này.

---

# 🖥️ 13. Tích hợp Đăng nhập vào WinForms

Trong `MiniSupermarket.WinForms`, tạo:

```text
FormLogin.cs
```

Giao diện gồm:

* `txtUser`: Nhập username.
* `txtPass`: Nhập password.
* `btnLogin`: Nút đăng nhập.

Sau khi đăng nhập thành công, WinForms nhận JWT Token và Role từ Backend.

---

# 💾 14. SessionManager

Tạo lớp:

```text
SessionManager.cs
```

Dùng để lưu Token và Role:

```csharp
public static class SessionManager
{
    public static string JwtToken { get; set; }
        = string.Empty;

    public static string CurrentRole { get; set; }
        = string.Empty;
}
```

Trong đó:

* `JwtToken`: Lưu JWT Token.
* `CurrentRole`: Lưu quyền của người dùng hiện tại.

---

# 📡 15. Gửi Bearer Token khi gọi API

Khi WinForms gọi API CRUD của Buổi 1, Token phải được gửi trong Header:

```text
Authorization: Bearer <JWT_TOKEN>
```

Ví dụ:

```csharp
client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Bearer",
        SessionManager.JwtToken
    );
```

Sau đó mới thực hiện:

```csharp
var categories =
    await client.GetFromJsonAsync<List<CategoryDto>>(
        "categories"
    );
```

---

# 🧪 16. Kiểm thử Bảo mật bằng Swagger

### Trường hợp 1: Chưa đăng nhập

Gọi:

```text
GET /api/categories
```

Không gửi Token.

Kết quả:

```text
401 Unauthorized
```

API từ chối truy cập.

---

### Trường hợp 2: Cashier đăng nhập

Đăng nhập:

```text
POST /api/auth/login
```

```json
{
    "username": "cashier",
    "password": "123456"
}
```

Copy Token → chọn **Authorize** trên Swagger → nhập:

```text
Bearer <JWT_TOKEN>
```

Sau đó gọi:

```text
GET /api/categories/staff-pos
```

Kết quả:

```text
200 OK
```

---

### Trường hợp 3: Cashier truy cập chức năng Admin

Gọi:

```text
GET /api/categories/admin-dashboard
```

Kết quả:

```text
403 Forbidden
```

Do Cashier đã đăng nhập nhưng không có Role `Admin`.

---

# 🔄 17. Luồng hoạt động của hệ thống sau Buổi 2

```text
                 ┌─────────────────────┐
                 │   WinForms Client   │
                 └──────────┬──────────┘
                            │
                     1. Đăng nhập
                            │
                            ▼
                 ┌─────────────────────┐
                 │   AuthController    │
                 └──────────┬──────────┘
                            │
                     2. Kiểm tra TK
                            │
                            ▼
                 ┌─────────────────────┐
                 │     JWT Token       │
                 │   Username + Role   │
                 └──────────┬──────────┘
                            │
                     3. Lưu Token
                            │
                            ▼
                 ┌─────────────────────┐
                 │   SessionManager    │
                 └──────────┬──────────┘
                            │
                 4. Bearer Token
                            │
                            ▼
                 ┌─────────────────────┐
                 │ MiniSupermarket.API │
                 │ [Authorize]         │
                 └──────────┬──────────┘
                            │
                     5. Kiểm tra Role
                            │
                            ▼
                 ┌─────────────────────┐
                 │ CategoriesController│
                 │       CRUD          │
                 └─────────────────────┘
```

---

# 🚀 18. Cách Chạy Toàn Bộ Hệ Thống

### Bước 1: Chạy Backend

```text
MiniSupermarket.API
→ Set as Startup Project
→ F5
```

### Bước 2: Kiểm tra Swagger

Kiểm tra:

```text
POST /api/auth/login
GET  /api/categories
POST /api/categories
PUT  /api/categories/{id}
DELETE /api/categories/{id}
```

### Bước 3: Chạy WinForms

```text
MiniSupermarket.WinForms
→ Debug
→ Start new instance
```

Ứng dụng mở:

```text
FormLogin
    ↓
Đăng nhập
    ↓
Nhận JWT Token
    ↓
SessionManager
    ↓
FormCategoryManagement
    ↓
CRUD Categories
```

---

# 📌 19. Kết quả Sau Buổi 1 và Buổi 2

| Nội dung                 | Buổi 1 | Buổi 2 |
| ------------------------ | ------ | ------ |
| Web API                  | ✅      | ✅      |
| CRUD Categories          | ✅      | ✅      |
| WinForms Client          | ✅      | ✅      |
| HttpClient               | ✅      | ✅      |
| Swagger                  | ✅      | ✅      |
| Đăng nhập                | ❌      | ✅      |
| JWT Token                | ❌      | ✅      |
| Authentication           | ❌      | ✅      |
| Authorization            | ❌      | ✅      |
| Role Admin/Cashier       | ❌      | ✅      |
| Bearer Token             | ❌      | ✅      |
| SessionManager           | ❌      | ✅      |
| Bảo vệ API `[Authorize]` | ❌      | ✅      |

Qua Buổi 2, hệ thống được nâng cấp từ ứng dụng CRUD thành hệ thống Client - Server có **xác thực và phân quyền**, trong đó WinForms đăng nhập, nhận JWT Token và sử dụng Token để gọi các API được bảo vệ.

---

# 👨‍💻 20. Tác giả

**Họ tên sinh viên:** Võ Hữu Trọng

**Mã sinh viên:** 2124110250

**Lớp học phần:** CCQ2411D

---
