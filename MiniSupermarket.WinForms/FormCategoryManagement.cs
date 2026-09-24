using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        // Địa chỉ API gốc (Đảm bảo cổng https://localhost:7221/ khớp với port Backend của bạn)
        private const string ApiBaseUrl = "https://localhost:7221/api/";

        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        // Hàm helper khởi tạo HttpClient đã đính kèm JWT Bearer Token
        private HttpClient GetAuthenticatedClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };

            // Đính kèm Token từ SessionManager / TokenManager
            string token = SessionManager.JwtToken; // Hoặc TokenManager.JwtToken
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        // Sự kiện Form vừa bật lên: Tự động tải dữ liệu từ API
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Tải danh sách Categories từ API
        private async Task LoadDataAsync()
        {
            try
            {
                using var client = GetAuthenticatedClient();
                var categories = await client.GetFromJsonAsync<List<CategoryDto>>("categories");
                dgvCategories.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu hoặc mất quyền truy cập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Tải lại dữ liệu (Refresh)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Khi click chọn dòng trong bảng DataGridView
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? "";
            }
        }

        // Nút THÊM MỚI (CREATE)
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCat = new
            {
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            try
            {
                using var client = GetAuthenticatedClient();
                var response = await client.PostAsJsonAsync("categories", newCat);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Thêm thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút CẬP NHẬT (UPDATE)
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var updateCat = new
            {
                CategoryId = id,
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            try
            {
                using var client = GetAuthenticatedClient();
                var response = await client.PutAsJsonAsync($"categories/{id}", updateCat);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Cập nhật thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút XÓA (DELETE)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using var client = GetAuthenticatedClient();
                    var response = await client.DeleteAsync($"categories/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút TÌM KIẾM (SEARCH)
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                using var client = GetAuthenticatedClient();
                var result = await client.GetFromJsonAsync<List<CategoryDto>>($"categories/search?keyword={keyword}");
                dgvCategories.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy kết quả hoặc bị từ chối truy cập: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Clear input form
        private void ClearInputs()
        {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void grpInfo_Enter(object sender, EventArgs e) { }
    }

    // Lớp DTO hứng dữ liệu JSON
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}