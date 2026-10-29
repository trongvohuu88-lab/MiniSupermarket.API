using System.Net.Http.Json;
using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private List<ProductItemDto> _items = new();
        private bool _isInitialized = false;

        // Phân trang
        private int _currentPage = 1;
        private int _pageSize = 5;
        private int _totalPages = 1;

        private static bool CanEdit => SessionManager.IsInRole("Admin", "Warehouse");

        public FormProductManagement()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(244, 245, 247);

            // 🛡️ Bổ sung cấu hình giới hạn an toàn để tránh lỗi ArgumentOutOfRangeException
            nudStock.Maximum = 1000000;
            nudPrice.Maximum = 1000000000m;

            ApplyPermissions();

            // Sự kiện nút bấm
            btnSearch.Click += async (_, _) => { _currentPage = 1; await LoadPagedProductsAsync(); };
            txtSearch.KeyDown += async (_, e) => { if (e.KeyCode == Keys.Enter) { _currentPage = 1; await LoadPagedProductsAsync(); } };
            cboCategoryFilter.SelectedIndexChanged += async (_, _) =>
            {
                if (_isInitialized)
                {
                    _currentPage = 1;
                    await LoadPagedProductsAsync();
                }
            };

            btnCreate.Click += async (_, _) => await SaveAsync(isNew: true);
            btnUpdate.Click += async (_, _) => await SaveAsync(isNew: false);
            btnDelete.Click += async (_, _) => await DeleteAsync();

            // Phân trang
            btnPrev.Click += async (_, _) =>
            {
                if (_currentPage > 1)
                {
                    _currentPage--;
                    await LoadPagedProductsAsync();
                }
            };

            btnNext.Click += async (_, _) =>
            {
                if (_currentPage < _totalPages)
                {
                    _currentPage++;
                    await LoadPagedProductsAsync();
                }
            };

            dgvProducts.SelectionChanged += (_, _) =>
            {
                if (_isInitialized) FillFromSelection();
            };

            Load += async (_, _) =>
            {
                await LoadCategoriesAsync();
                await LoadPagedProductsAsync();
                _isInitialized = true;
            };
        }

        private void ApplyPermissions()
        {
            bool canEdit = CanEdit;
            btnCreate.Visible = canEdit;
            btnUpdate.Visible = canEdit;
            btnDelete.Visible = canEdit;

            txtBarcode.ReadOnly = !canEdit;
            txtName.ReadOnly = !canEdit;
            nudPrice.ReadOnly = !canEdit;
            nudStock.ReadOnly = !canEdit;
            cboCategory.Enabled = canEdit;
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

                var filterCategories = new List<CategoryDto>
                {
                    new() { CategoryId = 0, CategoryName = "Tất cả nhóm hàng" }
                };
                filterCategories.AddRange(cats);
                cboCategoryFilter.DataSource = filterCategories;
                cboCategoryFilter.DisplayMember = "CategoryName";
                cboCategoryFilter.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPagedProductsAsync()
        {
            try
            {
                if (ApiClientService.Client == null) return;

                string keyword = Uri.EscapeDataString(txtSearch.Text.Trim());
                int categoryId = cboCategoryFilter.SelectedValue is int selectedCategoryId
                    ? selectedCategoryId
                    : 0;
                string url = $"products/paged?keyword={keyword}&categoryId={categoryId}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedResult<ProductItemDto>>(url);
                if (result != null)
                {
                    _items = result.Items ?? new();
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages > 0 ? result.TotalPages : 1;

                    dgvProducts.DataSource = _items.Select(p => new
                    {
                        p.ProductId,
                        p.Barcode,
                        p.ProductName,
                        p.Price,
                        p.StockQuantity,
                        p.CategoryName
                    }).ToList();

                    lblPaging.Text = $"Trang: {_currentPage} / {_totalPages}";
                    btnPrev.Enabled = (_currentPage > 1);
                    btnNext.Enabled = (_currentPage < _totalPages);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFromSelection()
        {
            if (dgvProducts.CurrentRow == null || _items.Count == 0) return;

            var cellValue = dgvProducts.CurrentRow.Cells["ProductId"]?.Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int id = Convert.ToInt32(cellValue);
            var p = _items.FirstOrDefault(x => x.ProductId == id);
            if (p == null) return;

            txtId.Text = p.ProductId.ToString();
            txtBarcode.Text = p.Barcode;
            txtName.Text = p.ProductName;

            // Gán giá trị an toàn sau khi đã nới Maximum ở constructor
            nudPrice.Value = Math.Clamp(p.Price, nudPrice.Minimum, nudPrice.Maximum);
            nudStock.Value = Math.Clamp(p.StockQuantity, (int)nudStock.Minimum, (int)nudStock.Maximum);

            cboCategory.SelectedValue = p.CategoryId;
        }

        private async Task SaveAsync(bool isNew)
        {
            if (!CanEdit)
            {
                MessageBox.Show("Bạn chỉ có quyền xem sản phẩm!", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Mã vạch và tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isNew && string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Hãy chọn sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue is not int catId)
            {
                MessageBox.Show("Hãy chọn nhóm hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var body = new
            {
                ProductId = isNew ? 0 : int.Parse(txtId.Text),
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = catId
            };

            try
            {
                var res = isNew
                    ? await ApiClientService.Client.PostAsJsonAsync("products", body)
                    : await ApiClientService.Client.PutAsJsonAsync($"products/{body.ProductId}", body);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show(isNew ? "Thêm sản phẩm thành công!" : "Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPagedProductsAsync();
                    if (isNew) ClearInputs();
                }
                else
                {
                    string err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thao tác thất bại: {err}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteAsync()
        {
            if (!CanEdit)
            {
                MessageBox.Show("Bạn chỉ có quyền xem sản phẩm!", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtId.Text)) return;

            if (MessageBox.Show($"Xác nhận xóa sản phẩm ID = {txtId.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var res = await ApiClientService.Client.DeleteAsync($"products/{txtId.Text}");
                if (res.IsSuccessStatusCode)
                {
                    await LoadPagedProductsAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            if (!CanEdit) return;
            txtId.Clear();
            txtBarcode.Clear();
            txtName.Clear();
            nudPrice.Value = 0;
            nudStock.Value = 0;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}