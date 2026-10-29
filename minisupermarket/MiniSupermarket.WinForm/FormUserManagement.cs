using System.Net.Http.Json;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent(); // Nạp giao diện từ file Designer

            BackColor = Color.FromArgb(244, 245, 247);

            btnAdd.Click += async (_, _) => await AddUserAsync();
            btnReset.Click += async (_, _) => await CallOnSelectedAsync("reset-password", "Đã reset mật khẩu về 123456.");
            btnLock.Click += async (_, _) => await CallOnSelectedAsync("toggle-lock", "Đã đổi trạng thái khóa tài khoản.");

            Load += async (_, _) => await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try { dgv.DataSource = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users") ?? new(); }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task AddUserAsync()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            { MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var body = new
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };
            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("users", body);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo");
                    txtUsername.Clear(); txtPassword.Clear(); txtFullName.Clear();
                    await LoadUsersAsync();
                }
                else MessageBox.Show("Thất bại: " + await res.Content.ReadAsStringAsync(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi"); }
        }

        private async Task CallOnSelectedAsync(string action, string okMessage)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Hãy chọn một tài khoản."); return; }
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["Id"].Value);
            try
            {
                var res = await ApiClientService.Client.PutAsync($"users/{id}/{action}", null);
                if (res.IsSuccessStatusCode) { MessageBox.Show(okMessage, "Thông báo"); await LoadUsersAsync(); }
                else MessageBox.Show("Thất bại: " + await res.Content.ReadAsStringAsync(), "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi"); }
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}