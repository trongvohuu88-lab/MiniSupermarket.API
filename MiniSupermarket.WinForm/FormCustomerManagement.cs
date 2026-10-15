using Stripe;
using MiniSupermarket.WinForms;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.Client
{
    public partial class FormCustomerManagement : Form
    {
        private const string BaseUrl = "https://localhost:7292/api/customers";
        private static HttpClient _http => ApiClientService.Client; // có gắn Bearer Token

        public FormCustomerManagement()
        {
            InitializeComponent();
            // Form được nhúng vào panel lớn hơn kích thước thiết kế: neo vùng nhập liệu xuống đáy
            // để bảng dgvCustomers dãn ra mà không đè lên các ô nhập.
            foreach (Control c in Controls)
                if (c != dgvCustomers && c.Top > 300)
                    c.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        // ===== Sự kiện khi mở form =====
        private async void FormCustomerManagement_Load(object? sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        // ===== 1. Tải toàn bộ danh sách =====
        private async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _http.GetFromJsonAsync<List<Customer>>(BaseUrl);
                BindGrid(customers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<Customer>? customers)
        {
            dgvCustomers.DataSource = customers ?? new List<Customer>();
            ClearInputs();
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadCustomersAsync();
        }

        // ===== 2. Tìm kiếm theo tên hoặc số điện thoại =====
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                string keyword = Uri.EscapeDataString(txtSearch.Text.Trim());
                var results = await _http.GetFromJsonAsync<List<Customer>>($"{BaseUrl}/search?keyword={keyword}");
                BindGrid(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== 3. Thêm mới (POST) =====
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            var customer = ReadInputs(includeId: false);
            if (customer == null) return;

            try
            {
                var response = await _http.PostAsJsonAsync(BaseUrl, customer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersAsync();
                }
                else
                {
                    await ShowApiErrorAsync(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== 4. Cập nhật (PUT) =====
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = ReadInputs(includeId: true);
            if (customer == null) return;

            try
            {
                var response = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", customer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersAsync();
                }
                else
                {
                    await ShowApiErrorAsync(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== 5. Xóa (DELETE) =====
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng \"{txtCustomerName.Text}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var response = await _http.DeleteAsync($"{BaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa khách hàng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersAsync();
                }
                else
                {
                    await ShowApiErrorAsync(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Chọn dòng trong bảng -> đổ lên các ô nhập =====
        private void dgvCustomers_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer c)
            {
                txtCustomerId.Text = c.CustomerId.ToString();
                txtCustomerName.Text = c.CustomerName;
                txtPhoneNumber.Text = c.PhoneNumber;
                txtAddress.Text = c.Address ?? string.Empty;
                txtRewardPoints.Text = c.RewardPoints.ToString();
                txtMembershipRank.Text = c.MembershipRank;
            }
        }

        // ===== Hàm hỗ trợ =====
        private Customer? ReadInputs(bool includeId)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return null;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return null;
            }

            int points = 0;
            if (!string.IsNullOrWhiteSpace(txtRewardPoints.Text) &&
                (!int.TryParse(txtRewardPoints.Text, out points) || points < 0))
            {
                MessageBox.Show("Điểm thưởng phải là số nguyên không âm.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRewardPoints.Focus();
                return null;
            }

            int id = 0;
            if (includeId) int.TryParse(txtCustomerId.Text, out id);

            return new Customer
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                RewardPoints = points,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                    ? "Chuẩn" : txtMembershipRank.Text.Trim()
            };
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Clear();
            txtMembershipRank.Clear();
        }

        // Đọc thông báo lỗi dạng { "message": "..." } từ API
        private static async Task ShowApiErrorAsync(HttpResponseMessage response)
        {
            string message = $"API trả về lỗi {(int)response.StatusCode}.";
            try
            {
                string body = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("message", out var msg))
                    message = msg.GetString() ?? message;
            }
            catch { /* giữ thông báo mặc định */ }

            MessageBox.Show(message, "Thao tác thất bại",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}