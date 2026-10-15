namespace MiniSupermarket.API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Cashier";
        public bool IsActive { get; set; } = true;
    }

    // Kho tài khoản mẫu lưu trong bộ nhớ (15 dòng kiểm thử theo đề Buổi 4).
    // Lưu ý: chỉ dùng cho học tập; thực tế phải lưu DB và băm mật khẩu.
    public static class UserStore
    {
        public static readonly List<AppUser> Users = new()
        {
            new() { Id = 1,  Username = "admin01",      Password = "123456", FullName = "Nguyễn Quản Trị",    Role = "Admin" },
            new() { Id = 2,  Username = "admin02",      Password = "123456", FullName = "Trần Giám Đốc",      Role = "Admin" },
            new() { Id = 3,  Username = "cashier01",    Password = "123456", FullName = "Lê Thu Ngân",        Role = "Cashier" },
            new() { Id = 4,  Username = "cashier02",    Password = "123456", FullName = "Phạm Bán Hàng",      Role = "Cashier" },
            new() { Id = 5,  Username = "cashier03",    Password = "123456", FullName = "Hoàng Thu Ngân",     Role = "Cashier" },
            new() { Id = 6,  Username = "cashier04",    Password = "123456", FullName = "Vũ Thị Quầy",        Role = "Cashier" },
            new() { Id = 7,  Username = "cashier05",    Password = "123456", FullName = "Đỗ Bán Lẻ",          Role = "Cashier" },
            new() { Id = 8,  Username = "ware01",       Password = "123456", FullName = "Ngô Quản Kho",       Role = "Warehouse" },
            new() { Id = 9,  Username = "ware02",       Password = "123456", FullName = "Bùi Kiểm Kê",        Role = "Warehouse" },
            new() { Id = 10, Username = "ware03",       Password = "123456", FullName = "Dương Thủ Kho",      Role = "Warehouse" },
            new() { Id = 11, Username = "ware04",       Password = "123456", FullName = "Lý Nhập Hàng",       Role = "Warehouse" },
            new() { Id = 12, Username = "admin_backup", Password = "123456", FullName = "Đặng Hỗ Trợ",        Role = "Admin" },
            new() { Id = 13, Username = "cashier06",    Password = "123456", FullName = "Hồ Ca Chiều",        Role = "Cashier" },
            new() { Id = 14, Username = "ware05",       Password = "123456", FullName = "Trương Vận Chuyển",  Role = "Warehouse" },
            new() { Id = 15, Username = "supervisor",   Password = "123456", FullName = "Mai Giám Sát",       Role = "Admin" },
        };
    }
}
