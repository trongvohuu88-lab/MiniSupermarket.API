# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Buổi thực hành:** Buổi 5 - ADO.NET nâng cao, Stored Procedure và giao dịch POS Checkout  

---

## 🏗️ 1. Mục tiêu thực hành

Buổi thực hành 5 tập trung vào việc làm chủ kỹ thuật truy xuất dữ liệu tối ưu trên SQL Server bằng ADO.NET thuần, xây dựng hệ thống API backend đạt chuẩn ACID phục vụ các nghiệp vụ bán hàng thời gian thực tại quầy POS.

Các nội dung trọng tâm bao gồm:

- Thiết lập kết nối và thực thi truy vấn cơ sở dữ liệu SQL Server thông qua ADO.NET.
- Sử dụng thành thạo các đối tượng cốt lõi: `SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataReader` và `DataTable`.
- Áp dụng chuẩn xác các phương thức thực thi: `ExecuteScalar()`, `ExecuteNonQuery()` và `ExecuteReader()`.
- Lập trình API tra cứu thông tin sản phẩm siêu tốc theo mã vạch (Barcode Scanner).
- Ứng dụng `SqlDataAdapter` kết hợp `DataTable` để truy xuất và thao tác dữ liệu theo mô hình ngắt kết nối (Disconnected Mode).
- Tối ưu hóa hiệu năng truy vấn báo cáo bằng Stored Procedure tổng hợp doanh thu theo từng nhân viên thu ngân.
- Sử dụng `SqlTransaction` để bảo vệ chuỗi giao dịch bán hàng đa bảng, đảm bảo tính toàn vẹn dữ liệu tuyệt đối khi thanh toán POS.

---

## 🛠️ 2. Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#
- **Nền tảng phát triển:** ASP.NET Core Web API (.NET 8.0) & WinForms Client
- **Truy xuất dữ liệu nâng cao:** ADO.NET
- **Thư viện kết nối CSDL:** `Microsoft.Data.SqlClient`
- **Hệ quản trị CSDL:** Microsoft SQL Server
- **Công cụ quản lý CSDL:** SQL Server Management Studio (SSMS)
- **Công cụ kiểm thử & kiểm tra API:** Swagger UI / Postman
- **Chuẩn trao đổi dữ liệu:** JSON

---

## 📂 3. Cấu trúc Solution

```text
Solution 'MiniSupermarket'
│
├── MiniSupermarket.API/                 # Backend - ASP.NET Core Web API
│   │
│   ├── Controllers/
│   │   ├── AdoProductController.cs      # ADO.NET: Tra cứu mã vạch & tải Cache sản phẩm
│   │   ├── CheckoutController.cs        # API xử lý thanh toán POS bằng SqlTransaction
│   │   ├── ReportsController.cs         # API xuất báo cáo doanh thu qua Stored Procedure
│   │   ├── ProductsController.cs        # API CRUD quản lý sản phẩm
│   │   ├── OrdersController.cs          # API quản lý hóa đơn
│   │   └── ...                          # Các Controller phụ trợ khác
│   │
│   ├── Dto/
│   │   ├── ProductLookupDto.cs          # DTO hứng dữ liệu tra cứu sản phẩm
│   │   ├── CheckoutDtos.cs              # DTO yêu cầu thanh toán POS giỏ hàng
│   │   ├── CashierRevenueDto.cs         # DTO báo cáo doanh thu theo thu ngân
│   │   ├── TopSellingProductDto.cs      # DTO thống kê sản phẩm bán chạy
│   │   └── ...
│   │
│   ├── Models/
│   │   ├── Product.cs                   # Entity mô hình sản phẩm
│   │   ├── Customer.cs                  # Entity mô hình khách hàng
│   │   ├── Order.cs                     # Entity mô hình hóa đơn
│   │   ├── OrderDetail.cs               # Entity mô hình chi tiết hóa đơn
│   │   ├── Category.cs                  # Entity mô hình danh mục
│   │   └── ...                          # Các Model khác
│   │
│   ├── Data/                            # DbContext & cấu hình Entity Framework
│   ├── Migrations/                      # Lịch sử Migration CSDL
│   ├── appsettings.json                 # Cấu hình chuỗi kết nối (ConnectionString)
│   ├── Program.cs                       # Đăng ký dịch vụ & Khởi chạy Web API
│   └── ...
│
└── MiniSupermarket.WinForm/             # Frontend - Desktop Client (WinForms)
    ├── FormPOS.cs                       # Giao diện bán hàng & quét mã vạch POS
    ├── FormQuickReport.cs               # Giao diện xem báo cáo doanh thu nhanh
    ├── FormProductManagement.cs         # Giao diện quản lý danh mục & tồn kho sản phẩm
    ├── FormCustomerManagement.cs        # Giao diện quản lý khách hàng & điểm thưởng
    ├── FormMainShell.cs                 # Giao diện điều khiển chính (Main Shell)
    ├── Program.cs                       # Điểm khởi chạy ứng dụng WinForms
    └── ...                              # Các Form và Control phụ trợ
```

**Chi tiết vai trò các thành phần chính Buổi 5:**

- `AdoProductController.cs`: Thực thi truy vấn ADO.NET thuần giúp tối ưu tốc độ đọc dữ liệu trực tiếp từ SQL Server.
- `ProductLookupDto.cs`: Định nghĩa cấu trúc DTO nhỏ gọn phục vụ quét mã vạch dưới 100ms.
- `ReportsController.cs`: Gọi Stored Procedure tổng hợp dữ liệu tài chính chính xác.
- `CashierRevenueDto.cs`: Ánh xạ kết quả doanh thu, tổng đơn hàng và điểm tích lũy theo ca trực của thu ngân.
- `CheckoutController.cs`: Quản lý quy trình thanh toán bán lẻ đa bảng bọc kín trong `SqlTransaction`.
- `CheckoutDtos.cs`: Đóng gói danh sách giỏ hàng và thông tin khách hàng từ quầy POS gửi lên API.

---

## 🔌 4. Nội dung thực hành chi tiết

### 4.1. Kỹ thuật truy xuất dữ liệu với ADO.NET
Khai thác bộ thư viện `Microsoft.Data.SqlClient` để tương tác trực tiếp với cơ sở dữ liệu:

- **`SqlConnection`:** Khởi tạo và quản lý kênh kết nối vật lý. Luôn bọc trong khối `using` để tự động giải phóng tài nguyên kết nối (`Connection Pooling`).
- **`SqlCommand`:** Đóng gói câu lệnh T-SQL hoặc tên Stored Procedure truyền xuống SQL Server.
- **`SqlParameter`:** Truyền tham số hóa dữ liệu vào câu lệnh SQL, đảm bảo an toàn tuyệt đối và triệt tiêu nguy cơ tấn công **SQL Injection**.
- **`SqlDataReader`:** Đọc dữ liệu dạng luồng một chiều (Forward-Only) đạt hiệu năng cao, thích hợp cho các tác vụ đọc nhanh.
- **`DataTable` & `SqlDataAdapter`:** Nạp toàn bộ dữ liệu vào bộ nhớ RAM ở mô hình ngắt kết nối (Disconnected Mode), hỗ trợ lưu đệm dữ liệu.
- **Phân định rõ phương thức thực thi:**
  - `ExecuteScalar()`: Dùng khi truy vấn trả về 1 ô duy nhất (ví dụ: lấy `OrderId` vừa tạo bằng `OUTPUT INSERTED.OrderId`).
  - `ExecuteNonQuery()`: Dùng khi thực thi lệnh `INSERT`, `UPDATE`, `DELETE` (trả về số dòng bị tác động).
  - `ExecuteReader()`: Dùng khi đọc tập dữ liệu gồm nhiều dòng, nhiều cột.

---

### 4.2. API tra cứu mã vạch siêu tốc (Connected & Disconnected Mode)
**File xử lý:** `AdoProductController.cs`

Xây dựng bộ API hỗ trợ quầy tính tiền POS quét mã Barcode phản hồi tức thì:

- **Endpoint tra cứu Barcode (`GET /api/ado-products/barcode/{barcode}`):** 
  - Sử dụng `SqlDataReader` đọc nhanh đúng 1 dòng dữ liệu sản phẩm theo mã vạch.
  - Sử dụng `@Barcode` qua `SqlParameter` để lọc dữ liệu an toàn.
  - Phản hồi dữ liệu dạng JSON cho WinForms hiển thị lên giỏ hàng.
  - Trả về mã lỗi `404 Not Found` nếu mã vạch không tồn tại hoặc `400 Bad Request` nếu chuỗi mã vạch trống.
- **Endpoint tải danh sách ngắt kết nối (`GET /api/ado-products/disconnected-cache`):**
  - Sử dụng `SqlDataAdapter.Fill()` đổ dữ liệu danh sách sản phẩm vào `DataTable`.
  - Tự động đóng kết nối ngay sau khi nạp xong, giúp giải phóng bộ nhớ cho máy chủ CSDL.

---

### 4.3. API báo cáo doanh thu bằng Stored Procedure
**File xử lý:** `ReportsController.cs`

Tối ưu hóa tốc độ tính toán báo cáo tài chính bằng cách chuyển các truy vấn gom nhóm phức tạp xuống CSDL:

- **Xây dựng Stored Procedure `sp_GetRevenueByCashier` trên SQL Server:**
  - Thống kê tổng số đơn hàng bằng `COUNT(OrderId)`.
  - Tính tổng doanh thu thực tế bằng `SUM(FinalAmount)`.
  - Tính tổng điểm thưởng đã phát hành bằng `SUM(RewardPoints)`.
  - Gom nhóm dữ liệu theo `CashierUsername` (`GROUP BY`) và sắp xếp giảm dần theo doanh thu (`ORDER BY TotalRevenue DESC`).
- **Thực thi trên C#:**
  - Thiết lập `command.CommandType = CommandType.StoredProcedure;`.
  - Ánh xạ từng dòng dữ liệu từ `SqlDataReader` sang danh sách `CashierRevenueDto` (có xử lý an toàn các giá trị `DBNull.Value`).
  - Trả về kết quả tổng quan kèm danh sách chi tiết dưới dạng JSON.

---

### 4.4. API thanh toán POS Checkout & Bảo vệ bằng SqlTransaction
**File xử lý:** `CheckoutController.cs`

Xây dựng quy trình thanh toán đơn hàng khép kín gồm 4 bước liên hoàn:

1. **Bước 1 (Tạo Hóa đơn):** Thêm mới bản ghi vào bảng `Orders`, dùng mệnh đề `OUTPUT INSERTED.OrderId` kết hợp `ExecuteScalar()` để lấy `OrderId` tự tăng ngay lập tức.
2. **Bước 2 (Lưu Chi tiết & Trừ kho):** Lặp qua danh sách giỏ hàng `Items`, kiểm tra tồn kho thực tế trong bảng `Products`. Nếu đủ số lượng, tiến hành thêm bản ghi vào `OrderDetails` và trừ `StockQuantity` trong `Products`.
3. **Bước 3 (Tích điểm thưởng):** Tính toán điểm tích lũy (10.000 VNĐ = 1 điểm) và cộng vào bảng `Customers`.
4. **Bước 4 (Xác nhận/Hoàn tác Giao dịch):**
   - Gọi `transaction.Commit()` để lưu vĩnh viễn toàn bộ dữ liệu vào đĩa cứng khi tất cả các bước thành công.
   - Kích hoạt `transaction.Rollback()` trong khối `catch` để hủy bỏ và khôi phục sạch dữ liệu khi xảy ra bất kỳ ngoại lệ nào (ví dụ: mua vượt quá số lượng tồn kho).

---

### 4.5. Đảm bảo tính toàn vẹn dữ liệu chuẩn ACID
Đảm bảo quy trình thanh toán đáp ứng 4 tiêu chí chuẩn của hệ quản trị CSDL giao dịch:

- **Atomicity (Tính nguyên tử):** Hoặc tất cả 4 bước thanh toán cùng thành công, hoặc không có bất kỳ dòng dữ liệu rác nào được lưu lại nếu gặp sự cố.
- **Consistency (Tính nhất quán):** Số lượng tồn kho và tiền thanh toán luôn đảm bảo đúng theo quy tắc nghiệp vụ trước và sau giao dịch.
- **Isolation (Tính cô lập):** Nhiều quầy POS thanh toán đồng thời không gây tranh chấp hoặc đọc dữ liệu chưa chốt (`Dirty Read`).
- **Durability (Tính bền vững):** Dữ liệu sau khi `Commit()` thành công sẽ lưu vĩnh viễn trên SQL Server.

---

## 🧪 5. Hướng dẫn chạy và kiểm thử API

### Bước 1: Khởi chạy ứng dụng Backend Web API

1. Mở Solution `MiniSupermarket.sln` bằng Visual Studio 2022.
2. Đặt `MiniSupermarket.API` làm **Startup Project**.
3. Kiểm tra chuỗi `DefaultConnection` trong file `appsettings.json` đảm bảo trỏ đúng đến SQL Server.
4. Nhấn `F5` hoặc `Ctrl + F5` để khởi chạy. Trang Swagger UI sẽ tự động mở ra.

---

### Bước 2: Kiểm thử Tra cứu mã vạch
- **Endpoint:** `GET /api/ado-products/barcode/{barcode}`
- **Thử nghiệm:** Nhập mã vạch `893456789001` và bấm **Execute**.
- **Kết quả:** Trả về mã HTTP `200 OK` kèm thông tin tên sản phẩm, đơn giá và số lượng tồn kho. Nhập mã sai `999999999999` sẽ nhận mã `404 Not Found`.

---

### Bước 3: Kiểm thử Tải dữ liệu lưu đệm (Disconnected Mode)
- **Endpoint:** `GET /api/ado-products/disconnected-cache`
- **Kết quả:** Trả về mã HTTP `200 OK` kèm tổng số bản ghi và mảng dữ liệu sản phẩm được nạp từ `DataTable`.

---

### Bước 4: Kiểm thử Báo cáo doanh thu theo thu ngân
- **Đảm bảo:** Đã thực thi lệnh `CREATE PROCEDURE sp_GetRevenueByCashier` trên SSMS trong database `MiniSupermarketDb`.
- **Endpoint:** `GET /api/reports/revenue-by-cashier`
- **Kết quả:** Trả về mã HTTP `200 OK` chứa tổng doanh thu toàn siêu thị và danh sách doanh thu phân theo từng tài khoản `CashierUsername`.

---

### Bước 5: Kiểm thử Thanh toán POS Checkout & Cơ chế Rollback
- **Endpoint:** `POST /api/checkout`
- **Kịch bản 1 (Thanh toán hợp lệ):** Gửi JSON giỏ hàng với số lượng nhỏ hơn tồn kho $\rightarrow$ Nhận phản hồi `200 OK`, kiểm tra SSMS thấy tạo hóa đơn mới, trừ tồn kho và cộng điểm thưởng thành công.
- **Kịch bản 2 (Mua vượt quá tồn kho - Kích hoạt Rollback):** Gửi JSON với số lượng mua `999` cho sản phẩm chỉ còn tồn `40` $\rightarrow$ Nhận mã lỗi `400 Bad Request` thông báo *"Sản phẩm không đủ tồn kho!"*. Kiểm tra SSMS xác nhận không sinh ra hóa đơn rác và sản phẩm đứng trước trong giỏ hàng không bị trừ kho sai.

---

## 👨‍💻 6. Thông tin sinh viên thực hiện

- **Họ và tên sinh viên:** VÕ HỮU TRỌNG
- **Mã số sinh viên:** 2124110250
- **Lớp học phần:** CCQ2411D