# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Buổi thực hành:** Buổi 6 – Entity Framework Core nâng cao, phân trang LINQ và tích hợp hệ thống POS Client - Server

## 🏗️ 1. Mô hình kiến trúc hệ thống (Client - Server)

Dự án được xây dựng theo mô hình Client - Server, gồm hai project chính:

- **MiniSupermarket.API (Backend):** Sử dụng ASP.NET Core Web API để xử lý nghiệp vụ, truy vấn dữ liệu, quản lý sản phẩm, danh mục, khách hàng, đơn hàng và cung cấp các API cho ứng dụng Client.
- **MiniSupermarket.WinForm (Frontend Client):** Ứng dụng Windows Forms phục vụ quản lý siêu thị và thao tác tại quầy POS. Client kết nối với Backend thông qua HTTP API để trao đổi dữ liệu.

Luồng xử lý chính:

`WinForms Client → HttpClient → ASP.NET Core Web API → Entity Framework Core → SQL Server`

## 🛠️ 2. Công nghệ sử dụng

- **Ngôn ngữ:** C#
- **Nền tảng:** .NET / ASP.NET Core
- **Backend:** ASP.NET Core Web API, Controllers, DTO, Entity Framework Core.
- **Truy vấn dữ liệu:** LINQ, Eager Loading (`Include`), `Skip`, `Take`, `AsNoTracking`.
- **Frontend:** Windows Forms, `HttpClient`, JSON.
- **Cơ sở dữ liệu:** SQL Server.
- **Kiểm thử API:** Swagger UI.
- **Môi trường phát triển:** Visual Studio.

## 📂 3. Cấu trúc Solution

Cây thư mục dưới đây được tổng hợp theo cấu trúc project hiện tại. Các thư mục có nhiều file nghiệp vụ được trình bày tương đối để README dễ theo dõi.

```text
MiniSupermarket/
│
├── MiniSupermarket.API/
│   │
│   ├── Controllers/
│   │   ├── AdoProductController.cs
│   │   ├── AuthController.cs
│   │   ├── CategoriesController.cs
│   │   ├── CheckoutController.cs
│   │   ├── CustomerController.cs
│   │   ├── OrdersController.cs
│   │   ├── ProductsController.cs
│   │   ├── ReportsController.cs
│   │   ├── RolesController.cs
│   │   ├── UsersController.cs
│   │   └── WeatherForecastController.cs
│   │
│   ├── Data/
│   │   └── SupermarketDbContext.cs
│   │       # Cấu hình truy cập dữ liệu bằng EF Core
│   │
│   ├── Dto/
│   │   ├── CashierRevenueDto.cs
│   │   ├── CategoryDtos.cs
│   │   ├── CheckoutDtos.cs
│   │   ├── CustomerDtos.cs
│   │   ├── DashboardSummaryDto.cs
│   │   ├── ProductDtos.cs
│   │   ├── ProductLookupDto.cs
│   │   ├── TopSellingProductDto.cs
│   │   └── ... các DTO khác
│   │
│   ├── Migrations/
│   │   └── ... các migration của cơ sở dữ liệu
│   │
│   ├── Models/
│   │   ├── Category.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   ├── OrderDetail.cs
│   │   ├── PagedResponseDto.cs
│   │   ├── Product.cs
│   │   ├── Roles.cs
│   │   └── User.cs
│   │
│   ├── appsettings.json
│   ├── MiniSupermarket.API.http
│   ├── Program.cs
│   └── WeatherForecast.cs
│
└── MiniSupermarket.WinForm/
    │
    ├── Services/
    │   └── ... các lớp dịch vụ kết nối API
    │
    ├── Theme/
    │   └── ... các thành phần giao diện
    │
    ├── Form1.cs
    ├── FormCancelOrder.cs
    ├── FormCategoryManagement.cs
    ├── FormCustomerManagement.cs
    ├── FormLogin.cs
    ├── FormMainShell.cs
    ├── FormPOS.cs
    ├── FormProductManagement.cs
    ├── FormQuickAddCustomer.cs
    ├── FormQuickReport.cs
    ├── FormRoleManagement.cs
    ├── FormUserManagement.cs
    ├── Program.cs
    └── SessionManager.cs
```

### Các file trọng tâm của Buổi 6

| File | Vai trò |
|---|---|
| `ProductsController.cs` | Xử lý API sản phẩm; là nơi triển khai hoặc tích hợp chức năng tìm kiếm, phân trang. |
| `PagedResponseDto.cs` | Cấu trúc dữ liệu phản hồi phân trang nếu được sử dụng trong phần triển khai. |
| `Product.cs` | Mô hình dữ liệu sản phẩm. |
| `Category.cs` | Mô hình danh mục sản phẩm, liên kết với sản phẩm. |
| `FormProductManagement.cs` | Giao diện quản lý sản phẩm trên WinForms. |
| `Services/` | Chứa các lớp dịch vụ dùng để kết nối Client với API. |
| `Program.cs` | Điểm khởi chạy và cấu hình ứng dụng tương ứng với từng project. |

*Lưu ý: Cây thư mục phản ánh các tên file nhìn thấy trong Solution Explorer và cấu trúc theo nội dung thực hành. Cần kiểm tra nội dung mã nguồn để xác nhận chính xác các chức năng đã hoàn thành trong từng file.*

## 📌 4. Nội dung thực hành Buổi 6

### 4.1. Xây dựng API tìm kiếm và phân trang sản phẩm

Tổ chức truy vấn sản phẩm tại Backend nhằm tránh trả về toàn bộ dữ liệu khi danh sách hàng hóa lớn.

Các nội dung trọng tâm:

- Tiếp nhận từ khóa tìm kiếm, số trang và kích thước trang.
- Sử dụng LINQ để lọc dữ liệu theo tên sản phẩm hoặc mã vạch.
- Sử dụng `Skip()` và `Take()` để lấy dữ liệu của trang hiện tại.
- Sử dụng `CountAsync()` để xác định tổng số bản ghi phù hợp.
- Tính tổng số trang và trả về dữ liệu kèm thông tin phân trang.

Endpoint theo nội dung bài thực hành:

```http
GET /api/products/paged?keyword=&pageNumber=1&pageSize=5
```

### 4.2. Truy vấn dữ liệu với Entity Framework Core

- Sử dụng `Include()` để lấy thông tin danh mục liên quan đến sản phẩm.
- Sử dụng `AsNoTracking()` cho các truy vấn chỉ đọc nhằm giảm chi phí theo dõi thay đổi dữ liệu.
- Kết hợp điều kiện lọc, sắp xếp và phân trang trong truy vấn LINQ.
- Sử dụng SQL Server làm nơi lưu trữ dữ liệu của hệ thống.

### 4.3. Tích hợp WinForms Client với Web API

Tập trung vào màn hình `FormProductManagement.cs` và lớp dịch vụ trong thư mục `Services`.

Các chức năng theo nội dung bài thực hành:

- Gọi API để tải danh sách sản phẩm.
- Hiển thị dữ liệu sản phẩm trên `DataGridView`.
- Tải danh mục sản phẩm lên `ComboBox`.
- Tìm kiếm sản phẩm theo từ khóa.
- Điều hướng giữa các trang dữ liệu.
- Gửi yêu cầu thêm, sửa và xóa sản phẩm thông qua API.
- Sử dụng `HttpClient` và JSON để trao đổi dữ liệu giữa Client và Server.

### 4.4. Kiểm thử API

Sử dụng Swagger UI để kiểm tra endpoint phân trang sản phẩm và đối chiếu cấu trúc dữ liệu phản hồi.

Các thông tin cần kiểm tra:

- Trang hiện tại (`CurrentPage`).
- Số phần tử mỗi trang (`PageSize`).
- Tổng số sản phẩm phù hợp (`TotalItems`).
- Tổng số trang (`TotalPages`).
- Danh sách sản phẩm (`Items`).
- Thông tin danh mục đi kèm sản phẩm khi truy vấn.

Với bộ dữ liệu mẫu gồm 15 sản phẩm, nếu không lọc dữ liệu và sử dụng `pageSize=5`, kết quả dự kiến là 5 sản phẩm mỗi trang và 3 trang dữ liệu.

## 🚀 5. Hướng dẫn chạy dự án

### Bước 1: Mở Solution

Mở file Solution `MiniSupermarket` bằng Visual Studio.

### Bước 2: Cấu hình cơ sở dữ liệu

Kiểm tra chuỗi kết nối trong `appsettings.json`, bảo đảm phù hợp với SQL Server đang sử dụng.

Nếu cần, kiểm tra các migration và cập nhật cơ sở dữ liệu theo cấu hình của dự án.

### Bước 3: Chạy Backend API

1. Chọn project `MiniSupermarket.API` làm Startup Project.
2. Chạy ứng dụng bằng F5 hoặc Ctrl + F5.
3. Mở Swagger UI để kiểm tra các endpoint được cung cấp.
4. Ghi nhận địa chỉ và cổng HTTP/HTTPS mà API đang sử dụng.

### Bước 4: Kết nối và chạy WinForms Client

1. Kiểm tra địa chỉ API trong lớp dịch vụ thuộc thư mục `Services`.
2. Bảo đảm địa chỉ và cổng kết nối khớp với Backend đang chạy.
3. Chạy project `MiniSupermarket.WinForm`.
4. Kiểm tra các màn hình quản lý và chức năng gọi API tương ứng.

*Lưu ý: Tên project, chuỗi kết nối và cổng chạy cần được đối chiếu với cấu hình thực tế trên máy.*

## 👨‍💻 6. Thông tin sinh viên

- **Họ tên sinh viên:** Võ Hữu Trọng
- **Mã sinh viên:** 2124110250
- **Lớp học phần:** CCQ2411D

---

**MiniSupermarket System**  
Bài thực hành môn Lập trình Ứng dụng .NET Core – Buổi 6.
