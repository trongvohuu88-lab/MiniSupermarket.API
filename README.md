# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Buổi thực hành:** Buổi 3 - Tích hợp SQL Server và Entity Framework Core Code-First

---

## 🏗️ 1. Mục tiêu và Nội dung Thực hành

Trong buổi thực hành 3, dự án được nâng cấp từ cơ chế lưu trữ dữ liệu tạm thời trên RAM (In-Memory) sang sử dụng cơ sở dữ liệu quan hệ Microsoft SQL Server, giúp dữ liệu được lưu trữ lâu dài và không bị mất khi khởi động lại ứng dụng.

Các nội dung đã thực hiện:

- Tích hợp SQL Server vào dự án ASP.NET Core Web API.
- Sử dụng Entity Framework Core (EF Core) theo phương pháp Code-First để tạo và quản lý cấu trúc cơ sở dữ liệu từ các lớp C#.
- Xây dựng các lớp thực thể `Category` và `Product`, khai báo khóa chính, khóa ngoại và quan hệ giữa danh mục với sản phẩm.
- Xây dựng `SupermarketDbContext` để quản lý các bảng dữ liệu và cấu hình dữ liệu mẫu ban đầu (Data Seeding).
- Cấu hình chuỗi kết nối SQL Server trong `appsettings.json`.
- Đăng ký `DbContext` bằng Dependency Injection trong `Program.cs`.
- Sử dụng EF Core Migrations để tạo và cập nhật cơ sở dữ liệu.
- Tái cấu trúc `CategoriesController` để truy vấn và thao tác dữ liệu trực tiếp trên SQL Server.
- Áp dụng LINQ kết hợp `async/await` và các phương thức bất đồng bộ như `ToListAsync()`, `FindAsync()` và `SaveChangesAsync()`.
- Kiểm thử API trên Swagger UI và kiểm tra khả năng lưu trữ dữ liệu lâu dài khi thao tác quản lý danh mục.

## 🛠️ 2. Công nghệ Sử dụng

- **Ngôn ngữ:** C# (.NET 8.0).
- **Backend:** ASP.NET Core Web API.
- **Cơ sở dữ liệu:** Microsoft SQL Server.
- **ORM:** Entity Framework Core.
- **Phương pháp quản lý CSDL:** Code-First Migrations.
- **Truy vấn dữ liệu:** LINQ, async/await.
- **Các gói NuGet:**
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Microsoft.EntityFrameworkCore.Design`
- **Frontend Client:** Windows Forms (.NET 8.0).
- **Giao tiếp Client - Server:** HttpClient.
- **Công cụ kiểm thử API:** Swagger UI.
- **Công cụ quản lý cơ sở dữ liệu:** SQL Server Management Studio (SSMS).

## 📂 3. Cấu trúc Solution

```text
MiniSupermarket.API/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── CategoriesController.cs       # API quản lý danh mục sử dụng EF Core
│   ├── ProductsController.cs
│   ├── RolesController.cs
│   └── WeatherForecastController.cs
│
├── Data/
│   └── SupermarketDbContext.cs       # DbContext, khai báo DbSet và Data Seeding
│
├── Migrations/
│   ├── 20261001132643_InitialCompleteDatabase.cs
│   └── SupermarketDbContextModelSnapshot.cs
│
├── Models/
│   ├── Category.cs                   # Thực thể danh mục sản phẩm
│   ├── Customer.cs
│   ├── Product.cs                    # Thực thể sản phẩm
│   └── Roles.cs
│
├── appsettings.json                  # Cấu hình chuỗi kết nối SQL Server
├── MiniSupermarket.API.http
├── Program.cs                        # Đăng ký DbContext và cấu hình dịch vụ
├── WeatherForecast.cs
│
└── MiniSupermarket.WinForm/
    ├── Dependencies/
    ├── Form1.cs
    ├── FormCategoryManagement.cs     # Giao diện quản lý danh mục
    ├── FormCustomerManagement.cs
    ├── FormLogin.cs
    └── FormRoleManagement.cs
```

## ⚙️ 4. Các Chức năng và Kỹ thuật Đã Thực hiện

### 4.1. Tích hợp Entity Framework Core

- Cài đặt các gói NuGet cần thiết để kết nối SQL Server và sử dụng EF Core Migrations.
- Xây dựng `SupermarketDbContext` kế thừa từ `DbContext`.
- Khai báo `DbSet<Category>` và `DbSet<Product>` để ánh xạ các thực thể với bảng dữ liệu.
- Sử dụng Data Annotations để xác định khóa chính, kiểu dữ liệu, trường bắt buộc và độ dài dữ liệu.
- Thiết lập quan hệ một-nhiều giữa danh mục và sản phẩm thông qua khóa ngoại `CategoryId`.

### 4.2. Quản lý Cơ sở dữ liệu bằng Code-First Migrations

Sử dụng Package Manager Console trong Visual Studio để thực hiện các lệnh:

```powershell
Add-Migration InitialCreateDatabase
Update-Database
```

- `Add-Migration InitialCreateDatabase`: Tạo Migration từ các lớp Model và cấu hình EF Core.
- `Update-Database`: Áp dụng Migration để tạo hoặc cập nhật cấu trúc cơ sở dữ liệu trên SQL Server.
- Kiểm tra các bảng dữ liệu trong SQL Server Management Studio (SSMS).

### 4.3. Xây dựng API quản lý danh mục với EF Core

Tái cấu trúc `CategoriesController` để sử dụng `SupermarketDbContext` thay cho danh sách dữ liệu lưu tạm trong bộ nhớ.

Các chức năng API được triển khai:

- **GET `/api/categories`**: Lấy danh sách danh mục từ SQL Server.
- **GET `/api/categories/{id}`**: Lấy thông tin chi tiết danh mục theo ID.
- **GET `/api/categories/search?keyword=...`**: Tìm kiếm danh mục theo từ khóa.
- **POST `/api/categories`**: Thêm danh mục mới.
- **PUT `/api/categories/{id}`**: Cập nhật thông tin danh mục.
- **DELETE `/api/categories/{id}`**: Xóa danh mục.

Các thao tác truy vấn và lưu dữ liệu sử dụng phương thức bất đồng bộ của EF Core nhằm tránh chặn luồng xử lý trong quá trình truy cập cơ sở dữ liệu.

### 4.4. Kiểm thử và kết nối WinForms Client

- Chạy Backend Web API và kiểm thử các endpoint trên Swagger UI.
- Thực hiện thêm mới danh mục và kiểm tra dữ liệu được ghi vào SQL Server.
- Sử dụng giao diện `FormCategoryManagement` để thực hiện các thao tác quản lý danh mục.
- Khởi động lại WinForms Client và Backend API để kiểm tra dữ liệu vẫn được lưu trữ trong cơ sở dữ liệu.

## 🚀 5. Hướng dẫn Chạy và Kiểm thử Dự án

### Bước 1: Cấu hình cơ sở dữ liệu

Mở file `appsettings.json` trong project `MiniSupermarket.API` và kiểm tra chuỗi kết nối SQL Server trong mục `ConnectionStrings`.

Điều chỉnh tên máy chủ, tên cơ sở dữ liệu và thông tin đăng nhập phù hợp với môi trường SQL Server đang sử dụng.

### Bước 2: Tạo hoặc cập nhật cơ sở dữ liệu

Mở Package Manager Console trong Visual Studio, chọn project `MiniSupermarket.API` làm Default Project và thực hiện Migration nếu cần.

```powershell
Add-Migration InitialCreateDatabase
Update-Database
```

Nếu Migration đã tồn tại, không tạo lại Migration có cùng tên; chỉ thực hiện cập nhật cơ sở dữ liệu khi cần thiết.

### Bước 3: Chạy Backend Web API

- Mở Solution bằng Visual Studio.
- Chạy project `MiniSupermarket.API`.
- Mở Swagger UI để kiểm thử các API quản lý danh mục.
- Kiểm tra dữ liệu trong SQL Server bằng SSMS.

### Bước 4: Chạy WinForms Client

- Khởi chạy project `MiniSupermarket.WinForm`.
- Đảm bảo địa chỉ API trong ứng dụng WinForms khớp với địa chỉ Backend đang chạy.
- Mở màn hình `FormCategoryManagement`.
- Thử nghiệm các chức năng tải danh sách, thêm mới, cập nhật và xóa danh mục.

### Bước 5: Kiểm tra tính bền vững của dữ liệu

Sau khi thao tác trên WinForms, kiểm tra dữ liệu trong SQL Server bằng SSMS. Khởi động lại ứng dụng để xác nhận dữ liệu vẫn còn được lưu trữ.

---

## 👨‍💻 6. Tác giả

- **Họ tên sinh viên:** Nguyễn Quốc Vương
- **Mã sinh viên:** 2124110272
- **Lớp học phần:** CCQ2411D

