# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Buổi thực hành:** Buổi 2 - Bảo mật và phân quyền JWT cho Web API

---

## 🏗️ 1. Mô hình kiến trúc hệ thống (Client - Server)

Dự án được xây dựng theo mô hình Client - Server, bao gồm hai thành phần chính:

- **MiniSupermarket.API (Backend):** Ứng dụng ASP.NET Core Web API chịu trách nhiệm xử lý các yêu cầu đăng nhập, cấp phát JWT Token, xác thực người dùng và bảo vệ các API bằng cơ chế xác thực Bearer Token.
- **MiniSupermarket.WinForm (Frontend Client):** Ứng dụng Windows Forms cung cấp giao diện đăng nhập, quản lý phiên làm việc và lưu trữ thông tin xác thực để phục vụ việc gọi API.

Trong buổi thực hành 2, hệ thống tập trung vào việc nâng cấp ứng dụng CRUD đã xây dựng ở buổi 1 bằng cơ chế xác thực JWT và phân quyền người dùng.

## 🛠️ 2. Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#
- **Nền tảng:** .NET 8.0
- **Backend:** ASP.NET Core Web API, Controllers, JWT Authentication
- **Frontend:** Windows Forms (WinForms)
- **Bảo mật:** JSON Web Token (JWT), Bearer Authentication
- **Thư viện hỗ trợ:** `System.IdentityModel.Tokens.Jwt`, `Microsoft.AspNetCore.Authentication.JwtBearer`, `System.Net.Http.Json`
- **Công cụ kiểm thử:** Swagger UI, Visual Studio

## 📂 3. Cấu trúc Solution

```text
MiniSuperMarket/
│
├── MiniSupermarket.API/                  # Dự án Web API (Backend)
│   │
│   ├── Controllers/
│   │   ├── AuthController.cs              # Xử lý đăng nhập và xác thực người dùng
│   │   ├── CategoriesController.cs        # API quản lý danh mục, áp dụng bảo vệ API
│   │   ├── RolesController.cs             # API quản lý vai trò
│   │   └── WeatherForecastController.cs   # Controller mẫu của ASP.NET Core
│   │
│   ├── Models/
│   │   ├── Category.cs                    # Model danh mục
│   │   └── Roles.cs                       # Model vai trò
│   │
│   ├── Properties/                        # Cấu hình thuộc tính dự án
│   ├── Dependencies/                      # Các thư viện và gói phụ thuộc
│   ├── appsettings.json                   # Tệp cấu hình ứng dụng
│   ├── MiniSupermarket.API.http           # Tệp gửi yêu cầu HTTP kiểm thử API
│   ├── Program.cs                         # Cấu hình JWT Authentication và Middleware
│   └── WeatherForecast.cs                 # Model dữ liệu thời tiết mẫu
│
└── MiniSupermarket.WinForm/               # Dự án Windows Forms (Frontend Client)
    │
    ├── Dependencies/                      # Các thư viện và gói phụ thuộc
    ├── Form1.cs                           # Form chính
    ├── FormCategoryManagement.cs           # Giao diện quản lý danh mục
    ├── FormLogin.cs                       # Giao diện đăng nhập hệ thống
    ├── FormRoleManagement.cs               # Giao diện quản lý vai trò
    ├── Program.cs                         # Điểm khởi chạy ứng dụng WinForms
    └── SessionManager.cs                  # Quản lý phiên đăng nhập và JWT Token
```

*Lưu ý: Cây thư mục được trình bày theo cấu trúc Solution hiện tại. Các thư mục, tệp và chức năng được mô tả dựa trên những thành phần hiển thị trong Solution Explorer và nội dung thực hành buổi 2.*

## 🔐 4. Nội dung thực hiện trong buổi 2

### 4.1. Xây dựng chức năng đăng nhập và cấp phát JWT Token

Xây dựng `AuthController.cs` để tiếp nhận thông tin đăng nhập từ Client và thực hiện xác thực người dùng.

Các nội dung chính:
- Tiếp nhận thông tin tài khoản và mật khẩu thông qua API đăng nhập.
- Tạo JWT Token sau khi xác thực thành công.
- Đưa thông tin định danh và vai trò người dùng vào Claims.
- Thiết lập thời hạn sử dụng Token.
- Trả về Token và thông tin vai trò khi đăng nhập thành công.

### 4.2. Cấu hình JWT Authentication trong Web API

Cập nhật `Program.cs` để đăng ký dịch vụ xác thực JWT Bearer và thiết lập các tham số kiểm tra Token.

Các nội dung chính:
- Cấu hình khóa bí mật dùng để ký và xác thực Token.
- Đăng ký dịch vụ `AddAuthentication()` và `AddJwtBearer()`.
- Thiết lập kiểm tra chữ ký Token.
- Sử dụng `UseAuthentication()` trước `UseAuthorization()`.
- Cấu hình Middleware để bảo vệ các API yêu cầu xác thực.

### 4.3. Bảo vệ API bằng cơ chế xác thực và phân quyền

Áp dụng các thuộc tính bảo mật để kiểm soát quyền truy cập vào tài nguyên API.

- `[Authorize]`: Yêu cầu người dùng cung cấp JWT Token hợp lệ trước khi truy cập API được bảo vệ.
- `[Authorize(Roles = "Admin")]`: Giới hạn quyền truy cập cho người dùng có vai trò Admin.
- `[Authorize(Roles = "Admin,Cashier")]`: Cho phép các vai trò Admin và Cashier truy cập tài nguyên được chỉ định.

Qua đó, hệ thống phân biệt được hai khái niệm:
- **Authentication (Xác thực):** Xác định người dùng là ai.
- **Authorization (Phân quyền):** Kiểm tra người dùng có quyền thực hiện thao tác hay không.

### 4.4. Xây dựng giao diện đăng nhập trên WinForms

Sử dụng `FormLogin.cs` để xây dựng giao diện đăng nhập cho ứng dụng Windows Forms.

Các nội dung chính:
- Nhập tài khoản và mật khẩu.
- Kiểm tra dữ liệu đầu vào cơ bản trước khi gửi yêu cầu.
- Gửi thông tin đăng nhập đến API thông qua `HttpClient`.
- Xử lý kết quả đăng nhập thành công hoặc thất bại.
- Hiển thị thông báo phù hợp với kết quả xác thực.
- Điều hướng sang giao diện quản lý sau khi đăng nhập thành công.

### 4.5. Quản lý phiên đăng nhập bằng SessionManager

Xây dựng `SessionManager.cs` để lưu trữ thông tin xác thực dùng chung trong ứng dụng WinForms.

Các thông tin chính:
- `JwtToken`: Lưu JWT Token nhận được từ Web API.
- `CurrentRole`: Lưu vai trò của người dùng hiện tại.

Lớp quản lý phiên giúp các Form sử dụng chung thông tin xác thực sau khi người dùng đăng nhập.

### 4.6. Gửi Bearer Token khi gọi API

Cập nhật cách gọi API từ WinForms để đính kèm JWT Token trong HTTP Request Header theo định dạng:

`Authorization: Bearer <token>`

Nhờ đó, các yêu cầu truy cập API được bảo vệ có thể được máy chủ xác thực trước khi xử lý.

## 🧪 5. Kiểm thử và xác minh bảo mật

Sử dụng Swagger UI để kiểm tra hoạt động của cơ chế xác thực và phân quyền JWT.

| Trường hợp kiểm thử | Kết quả mong đợi | Ý nghĩa |
|---|---|---|
| Gọi API được bảo vệ khi chưa đăng nhập | `401 Unauthorized` | Yêu cầu chưa được xác thực |
| Đăng nhập với thông tin hợp lệ | `200 OK` | Đăng nhập thành công và nhận JWT Token |
| Gọi API bằng Token hợp lệ, đúng quyền | `200 OK` | Người dùng được phép truy cập |
| Người dùng đã đăng nhập nhưng không đủ quyền | `403 Forbidden` | Đã xác thực nhưng không được phép thực hiện thao tác |

Các kết quả trên là những trường hợp kiểm thử theo nội dung hướng dẫn của buổi thực hành. Kết quả thực tế phụ thuộc vào cấu hình và dữ liệu của dự án.

## 🚀 6. Hướng dẫn chạy và kiểm thử dự án

### Bước 1: Chạy Web API

1. Mở Solution `MiniSuperMarket` bằng Visual Studio.
2. Chọn project `MiniSupermarket.API` làm Startup Project.
3. Nhấn `F5` để khởi chạy Web API.
4. Mở Swagger UI theo địa chỉ được Visual Studio cung cấp.

### Bước 2: Kiểm thử chức năng đăng nhập

1. Mở endpoint đăng nhập trong Swagger UI.
2. Gửi thông tin tài khoản và mật khẩu theo cấu hình của `AuthController`.
3. Kiểm tra kết quả trả về.
4. Nếu đăng nhập thành công, lấy JWT Token từ phản hồi của API.

### Bước 3: Kiểm thử xác thực và phân quyền

1. Thử gọi API được bảo vệ khi chưa cung cấp Token.
2. Sử dụng chức năng `Authorize` của Swagger UI để gửi JWT Token hợp lệ.
3. Gọi lại API và kiểm tra kết quả.
4. Thử truy cập tài nguyên yêu cầu vai trò cao hơn để kiểm tra quyền truy cập.

### Bước 4: Chạy ứng dụng WinForms

1. Đảm bảo Web API đang hoạt động.
2. Kiểm tra địa chỉ và cổng API được cấu hình trong ứng dụng WinForms.
3. Chọn project `MiniSupermarket.WinForm` để khởi chạy.
4. Đăng nhập bằng tài khoản phù hợp với cấu hình Backend.
5. Kiểm tra việc lưu Token, lưu vai trò và gọi API sau khi đăng nhập.

*Lưu ý: Tài khoản kiểm thử, địa chỉ API và cổng kết nối phải phù hợp với cấu hình thực tế của dự án.*

## 👨‍💻 7. Thông tin sinh viên

- **Họ tên sinh viên:** VÕ HỮU TRỌNG
- **Mã sinh viên:** 2124110250
- **Lớp học phần:** CCQ2411D

---
**MiniSupermarket System - Thực hành Buổi 2: Bảo mật và phân quyền JWT cho Web API**
