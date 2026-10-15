using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        private static readonly Color NavNormal = Color.FromArgb(24, 30, 48);
        private static readonly Color NavActive = Color.FromArgb(41, 100, 180);

        private Button? _activeButton;
        private Form? _currentChild;

        // Ma trận phân quyền: chức năng -> các vai trò được phép
        private static readonly Dictionary<string, string[]> Permissions = new()
        {
            ["pos"]      = new[] { "Admin", "Cashier" },
            ["category"] = new[] { "Admin", "Warehouse" },
            ["product"]  = new[] { "Admin", "Warehouse", "Cashier" },
            ["customer"] = new[] { "Admin", "Cashier" },
            ["reports"]  = new[] { "Admin" },
            ["user"]     = new[] { "Admin" },
        };

        public FormMainShell()
        {
            InitializeComponent();
            lblTitle.UseMnemonic = false;    // giữ nguyên ký tự '&' trong tiêu đề
            lblUserInfo.UseMnemonic = false;
        }

        private void FormMainShell_Load(object? sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole;
            lblUserInfo.Text = $"Nhân viên: {SessionManager.CurrentUsername} | Vai trò: [{role}]";
            lblUserInfo.Left = panelTopHeader.Width - lblUserInfo.Width - 20;
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            if (!ApplyRolePermissions(role)) return;
            OpenDefaultScreenByRole(role);
        }

        private static bool HasAccess(string feature) =>
            Permissions.TryGetValue(feature, out var roles) && SessionManager.IsInRole(roles);

        // ===== LỚP 1: ẨN/HIỆN NÚT TRÊN SIDEBAR =====
        private bool ApplyRolePermissions(string role)
        {
            if (!SessionManager.IsInRole("Admin", "Cashier", "Warehouse"))
            {
                MessageBox.Show("Tài khoản chưa được cấp quyền hạn hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return false;
            }

            btnPOS.Visible        = HasAccess("pos");
            btnCategory.Visible   = HasAccess("category");
            btnProduct.Visible    = HasAccess("product");
            btnCustomer.Visible   = HasAccess("customer");
            btnReports.Visible    = HasAccess("reports");
            btnUserManage.Visible = HasAccess("user");
            return true;
        }

        private void OpenDefaultScreenByRole(string role)
        {
            if (SessionManager.IsInRole("Admin"))
                OpenChildForm("category", () => new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
            else if (SessionManager.IsInRole("Cashier"))
                OpenChildForm("pos", () => new FormPOS(), "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)", btnPOS);
            else if (SessionManager.IsInRole("Warehouse"))
                OpenChildForm("product", () => new FormProductManagement(), "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG", btnProduct);
        }

        // ===== SỰ KIỆN CLICK SIDEBAR =====
        private void btnCategory_Click(object? s, EventArgs e) =>
            OpenChildForm("category", () => new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);

        private void btnPOS_Click(object? s, EventArgs e) =>
            OpenChildForm("pos", () => new FormPOS(), "HỆ THỐNG QUẦY BÁN HÀNG & THU NGÂN (POS)", btnPOS);

        private void btnProduct_Click(object? s, EventArgs e) =>
            OpenChildForm("product", () => new FormProductManagement(), "QUẢN LÝ THÔNG TIN SẢN PHẨM & KHO HÀNG", btnProduct);

        private void btnCustomer_Click(object? s, EventArgs e) =>
            OpenChildForm("customer", () => new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM", btnCustomer);

        private void btnUserManage_Click(object? s, EventArgs e) =>
            OpenChildForm("user", () => new FormUserManagement(), "QUẢN TRỊ TÀI KHOẢN VÀ PHÂN QUYỀN HỆ THỐNG", btnUserManage);

        private void btnReports_Click(object? s, EventArgs e)
        {
            // Lớp bảo vệ riêng cho dữ liệu tài chính (ngoài việc đã ẩn nút)
            if (!SessionManager.IsInRole("Admin"))
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm("reports", () => new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT", btnReports);
        }

        // ===== NHÚNG FORM CON (LỚP 2: CHẶN LOGIC THEO VAI TRÒ) =====
        private void OpenChildForm(string feature, Func<Form> factory, string title, Button navButton)
        {
            if (!HasAccess(feature))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SetActiveButton(navButton);
            lblTitle.Text = title;
            CloseCurrentChild();

            var child = factory();
            _currentChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            panelMainContent.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        private void CloseCurrentChild()
        {
            if (_currentChild == null) return;
            panelMainContent.Controls.Remove(_currentChild);
            _currentChild.Close();
            _currentChild.Dispose();
            _currentChild = null;
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeButton != null) _activeButton.BackColor = NavNormal;
            btn.BackColor = NavActive;
            _activeButton = btn;
        }

        // ===== ĐĂNG XUẤT =====
        private void btnLogout_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất phiên làm việc?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            SessionManager.Clear();
            SessionManager.LogoutRequested = true; // Program sẽ mở lại FormLogin
            Close();
        }
    }
}
