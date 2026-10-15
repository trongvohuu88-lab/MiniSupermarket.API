using System.Net.Http.Json;
using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private List<ProductDto> _products = new();
        private bool _isInitialized = false; // Cờ kiểm tra form đã load xong chưa

        public FormProductManagement()
        {
            InitializeComponent(); // Khởi tạo giao diện từ file Designer

            BackColor = Color.FromArgb(244, 245, 247);

            // Đăng ký các sự kiện tương tác cơ bản
            btnSearch.Click += async (_, _) => await LoadProductsAsync();
            txtSearch.KeyDown += async (_, e) => { if (e.KeyCode == Keys.Enter) await LoadProductsAsync(); };
            btnNew.Click += (_, _) => ClearInputs();
            btnAdd.Click += async (_, _) => await SaveAsync(isNew: true);
            btnUpdate.Click += async (_, _) => await SaveAsync(isNew: false);
            btnDelete.Click += async (_, _) => await DeleteAsync();

            // Sự kiện chọn dòng trên bảng
            dgv.SelectionChanged += (_, _) =>
            {
                if (_isInitialized) FillFromSelection();
            };

            // Sự kiện Load form
            Load += async (_, _) =>
            {
                await LoadCategoriesAsync();
                await LoadProductsAsync();
                _isInitialized = true; // Đánh dấu form đã sẵn sàng
            };
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                if (ApiClientService.Client == null) return;

                var cats = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories") ?? new();

                cboCategory.DataSource = cats;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                var filter = new List<CategoryDto> { new() { CategoryId = 0, CategoryName = "-- Tất cả nhóm --" } };
                if (cats.Count > 0)
                {
                    filter.AddRange(cats);
                }
                cboFilter.DataSource = filter;
                cboFilter.DisplayMember = "CategoryName";
                cboFilter.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                if (ApiClientService.Client == null) return;

                string url = $"products/search?keyword={Uri.EscapeDataString(txtSearch.Text.Trim())}";
                if (cboFilter.SelectedValue is int cid && cid > 0) url += $"&categoryId={cid}";

                _products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>(url) ?? new();
                dgv.DataSource = _products.Select(p => new
                {
                    p.ProductId,
                    p.Barcode,
                    p.ProductName,
                    p.Price,
                    p.StockQuantity,
                    p.Unit,
                    CategoryName = p.Category?.CategoryName
                }).ToList();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nạp sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FillFromSelection()
        {
            if (dgv == null || dgv.CurrentRow == null || _products == null || _products.Count == 0) return;

            var cellValue = dgv.CurrentRow.Cells["ProductId"]?.Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int id = Convert.ToInt32(cellValue);
            var p = _products.FirstOrDefault(x => x.ProductId == id);
            if (p == null) return;

            txtId.Text = p.ProductId.ToString();
            txtBarcode.Text = p.Barcode ?? "";
            txtName.Text = p.ProductName ?? "";
            nudPrice.Value = p.Price;
            nudStock.Value = p.StockQuantity;
            txtUnit.Text = p.Unit ?? "";

            if (cboCategory.DataSource != null)
            {
                cboCategory.SelectedValue = p.CategoryId;
            }
        }

        private async Task SaveAsync(bool isNew)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Mã vạch và tên sản phẩm không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!isNew && string.IsNullOrEmpty(txtId.Text)) { MessageBox.Show("Hãy chọn sản phẩm cần sửa."); return; }
            if (cboCategory.SelectedValue is not int catId) { MessageBox.Show("Hãy chọn nhóm hàng."); return; }

            var body = new
            {
                ProductId = isNew ? 0 : int.Parse(txtId.Text),
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                Unit = txtUnit.Text.Trim(),
                CategoryId = catId
            };
            try
            {
                var res = isNew
                    ? await ApiClientService.Client.PostAsJsonAsync("products", body)
                    : await ApiClientService.Client.PutAsJsonAsync($"products/{body.ProductId}", body);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show(isNew ? "Thêm sản phẩm thành công!" : "Cập nhật thành công!", "Thông báo");
                    await LoadProductsAsync(); if (isNew) ClearInputs();
                }
                else MessageBox.Show($"Thao tác thất bại ({(int)res.StatusCode}): {await res.Content.ReadAsStringAsync()}", "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi"); }
        }

        private async Task DeleteAsync()
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;
            if (MessageBox.Show($"Xác nhận xóa sản phẩm ID = {txtId.Text}?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                var res = await ApiClientService.Client.DeleteAsync($"products/{txtId.Text}");
                if (res.IsSuccessStatusCode) { await LoadProductsAsync(); ClearInputs(); }
                else MessageBox.Show("Xóa thất bại: " + (int)res.StatusCode, "Lỗi");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi"); }
        }

        private void ClearInputs()
        {
            txtId.Clear(); txtBarcode.Clear(); txtName.Clear(); txtUnit.Clear();
            nudPrice.Value = 0; nudStock.Value = 0;
        }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Unit { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public decimal UnitPrice { get; internal set; }
    }
}