# 🛒 ĐỒ ÁN SIÊU THỊ MINI - BÀI THỰC HÀNH BUỔI 1

Hệ thống Quản lý Siêu thị Mini (Phân hệ Quản lý Danh mục Nhóm hàng & Vai trò) được xây dựng theo kiến trúc phân tầng **Backend (ASP.NET Core Web API)** và **Frontend Client (Windows Forms)** giao tiếp qua chuỗi dữ liệu JSON (`HttpClient`).

---

## 📌 MỤC TIÊU BÀI THỰC HÀNH 1

1. **Backend (API):**
   * Khởi tạo dự án ASP.NET Core Web API (`.NET 8.0`).
   * Định nghĩa các Model thực thể: `Category.cs` (Nhóm hàng) và `Role.cs` (Vai trò).
   * Viết các Controller xử lý các tác vụ CRUD cơ bản trong bộ nhớ tạm (In-Memory List):
     * `CategoriesController.cs`
     * `RolesController.cs`
   * Tích hợp Swagger UI để kiểm thử điểm cuối (endpoints).

2. **Frontend (WinForms Client):**
   * Khởi tạo dự án Windows Forms App (`.NET 8.0`).
   * Cài đặt thư viện NuGet `System.Net.Http.Json` để giao tiếp bất đồng bộ với Web API.
   * Xây dựng giao diện điều khiển và xử lý sự kiện đầy đủ cho 2 Form chính:
     * `FormCategoryManagement.cs`
     * `FormRoleManagement.cs`

---

## 📂 CẤU TRÚC THƯ MỤC NGUỒN (BUỔI 1)

```text
MiniSupermarket/
│
├── MiniSupermarket.API/                   # Dự án Backend Web API
│   ├── Controllers/
│   │   ├── CategoriesController.cs        # Xử lý CRUD Nhóm hàng & Tìm kiếm
│   │   └── RolesController.cs             # Xử lý CRUD Vai trò người dùng
│   ├── Models/
│   │   ├── Category.cs                    # Entity Category (CategoryId, CategoryName, Description)
│   │   └── Role.cs                        # Entity Role (Id, RoleName, Description)
│   ├── Program.cs                         # Cấu hình Services & Swagger UI
│   └── appsettings.json                   # Cấu hình môi trường
│
└── MiniSupermarket.WinForm/               # Dự án Client Windows Forms
    ├── FormCategoryManagement.cs          # Giao diện & Logic quản lý Danh mục
    ├── FormCategoryManagement.Designer.cs
    ├── FormRoleManagement.cs              # Giao diện & Logic quản lý Vai trò
    └── FormRoleManagement.Designer.cs
```

---

## 🚀 CHỨC NĂNG VÀ ĐIỂM CUỐI (ENDPOINTS)

### 1. Quản lý Danh mục (Categories)

| Phương thức | Endpoint | Mô tả |
| :--- | :--- | :--- |
| **GET** | `/api/categories` | Lấy toàn bộ danh sách nhóm hàng |
| **GET** | `/api/categories/{id}` | Lấy thông tin nhóm hàng theo ID |
| **GET** | `/api/categories/search?keyword={keyword}` | Tìm kiếm nhóm hàng theo tên |
| **POST** | `/api/categories` | Thêm mới nhóm hàng |
| **PUT** | `/api/categories/{id}` | Cập nhật thông tin nhóm hàng |
| **DELETE** | `/api/categories/{id}` | Xóa nhóm hàng theo ID |

### 2. Quản lý Vai trò (Roles)

| Phương thức | Endpoint | Mô tả |
| :--- | :--- | :--- |
| **GET** | `/api/roles` | Lấy toàn bộ danh sách vai trò |
| **GET** | `/api/roles/{id}` | Lấy chi tiết vai trò theo ID |
| **POST** | `/api/roles` | Thêm mới vai trò |
| **PUT** | `/api/roles/{id}` | Cập nhật thông tin vai trò |
| **DELETE** | `/api/roles/{id}` | Xóa vai trò theo ID |

---

## 🛠️ HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY DỰ ÁN

### Yêu cầu hệ thống
* Visual Studio 2022 (phiên bản 17.8 trở lên)
* .NET 8.0 SDK

### Các bước thực hiện

1. **Khởi chạy Web API:**
   * Mở Solution `MiniSuperMartket.sln` trên Visual Studio.
   * Nhấp chuột phải vào project `MiniSupermarket.API` $\rightarrow$ Chọn **Set as Startup Project**.
   * Nhấn phím **F5** (hoặc nút **Start**). Trình duyệt web sẽ mở ra giao diện Swagger UI (Ví dụ: `https://localhost:7123/swagger`).

2. **Khởi chạy Client WinForms:**
   * Trong lúc API đang chạy, nhấp chuột phải vào project `MiniSupermarket.WinForm` $\rightarrow$ Chọn **Debug** $\rightarrow$ **Start New Instance**.
   * Lưu ý kiểm tra địa chỉ `BaseAddress` trong mã nguồn `HttpClient` của WinForms để đảm bảo đúng số cổng (Port) của API:
     ```csharp
     private static readonly HttpClient _client = new HttpClient {
         BaseAddress = new Uri("https://localhost:7123/api/")
     };
     ```

---

## 📝 ĐÁNH GIÁ KẾT QUẢ BUỔI 1
* Hiểu rõ mô hình phân tầng Client - Server sử dụng Web API làm cầu nối trung gian.
* Thành thạo thao tác dữ liệu cơ bản qua HTTP Methods (`GET`, `POST`, `PUT`, `DELETE`).
* Áp dụng thành công lập trình bất đồng bộ `async/await` và giải tuần tự hóa dữ liệu JSON trong Windows Forms.
  Họ tên sinh viên; VÕ HỮU TRỌNG
  MSSV: 2124110250
  LỚP:CCQ2411D
