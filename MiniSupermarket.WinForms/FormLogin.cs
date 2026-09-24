using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms // Sửa lại thành WinForms cho đồng bộ namespace
{
    public partial class FormLogin : Form
    {
        private readonly HttpClient _httpClient;

        // Đường dẫn Base API của backend (Đảm bảo số cổng localhost khớp với API đang bật)
        private const string ApiBaseUrl = "https://localhost:7221/api/Auth/login";

        public FormLogin()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";

            try
            {
                // 1. Chuẩn bị dữ liệu gửi lên API
                var loginDto = new { Username = username, Password = password };
                var jsonContent = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

                // 2. Gọi API Login
                HttpResponseMessage response = await _httpClient.PostAsync(ApiBaseUrl, jsonContent);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 3. Đọc dữ liệu JSON trả về từ API
                    using var doc = JsonDocument.Parse(responseBody);
                    var root = doc.RootElement;

                    string token = root.GetProperty("token").GetString() ?? "";
                    string role = root.GetProperty("role").GetString() ?? "";

                    // 4. Đồng bộ lưu Token vào SessionManager
                    SessionManager.JwtToken = token;
                    SessionManager.UserRole = role;

                    MessageBox.Show($"Đăng nhập thành công! Quyền: {role}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Mở Form main (FormCategoryManagement) và đóng/ẩn FormLogin
                    FormCategoryManagement mainForm = new FormCategoryManagement();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại! Sai tài khoản hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến máy chủ API: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}