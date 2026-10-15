using System.ComponentModel;
using System.Net.Http.Json;
using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormPOS : Form
    {
        private readonly BindingList<CartItem> _cart = new();

        public FormPOS()
        {
            InitializeComponent(); // Gọi từ file Designer.cs để load giao diện kéo thả

            Text = "Bán hàng POS";
            BackColor = Color.FromArgb(244, 245, 247);
            KeyPreview = true;
            BuildUiLogic();
        }

        private void BuildUiLogic()
        {
            dgvCart.AutoGenerateColumns = false; // Cố định các cột tự định nghĩa
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", FillWeight = 15 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên sản phẩm", FillWeight = 45 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn giá", FillWeight = 15, DefaultCellStyle = { Format = "N0" } });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", FillWeight = 10 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành tiền", FillWeight = 15, DefaultCellStyle = { Format = "N0" } });
            dgvCart.DataSource = _cart;

            txtBarcode.KeyDown += async (_, e) =>
            {
                if (e.KeyCode != Keys.Enter || string.IsNullOrWhiteSpace(txtBarcode.Text)) return;
                e.SuppressKeyPress = true;
                string code = txtBarcode.Text.Trim(); txtBarcode.Clear();
                await AddByBarcodeAsync(code);
            };
            txtCustomerPhone.KeyDown += async (_, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; await LookupCustomerAsync(); } };
            txtCashReceived.TextChanged += (_, _) => CalculateChange();
            btnCheckout.Click += (_, _) => Checkout();
            btnClearCart.Click += (_, _) => ClearAll();
            KeyDown += (_, e) => { if (e.KeyCode == Keys.F9) Checkout(); };
            Shown += (_, _) => txtBarcode.Focus();
        }

        private async Task AddByBarcodeAsync(string barcode)
        {
            try
            {
                var list = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>(
                    $"products/search?keyword={Uri.EscapeDataString(barcode)}") ?? new();
                var product = list.FirstOrDefault(p => p.Barcode == barcode) ?? (list.Count == 1 ? list[0] : null);
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var item = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (item != null)
                {
                    item.Quantity++;
                    _cart.ResetBindings();
                }
                else
                {
                    // Đã sửa product.Price thành product.UnitPrice (hoặc sửa thành product.Price nếu DTO của bạn dùng Price)
                    _cart.Add(new CartItem
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice,
                        Quantity = 1
                    });
                }
                UpdateTotals();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            txtBarcode.Focus();
        }

        private async Task LookupCustomerAsync()
        {
            string phone = txtCustomerPhone.Text.Trim();
            if (phone.Length == 0) { lblCustomerName.Text = "Khách vãng lai"; return; }
            try
            {
                var all = await ApiClientService.Client.GetFromJsonAsync<List<Customer>>("customers") ?? new();
                var c = all.FirstOrDefault(x => x.PhoneNumber == phone);
                lblCustomerName.Text = c == null ? "Không tìm thấy khách hàng" : $"{c.CustomerName} - Hạng {c.MembershipRank} ({c.RewardPoints} điểm)";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tra cứu khách hàng: " + ex.Message, "Lỗi"); }
        }

        private void UpdateTotals()
        {
            lblTotalAmount.Text = $"{_cart.Sum(x => x.TotalPrice):N0} đ";
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived.Text, out var cash))
            {
                decimal change = cash - total;
                lblChange.Text = change >= 0 ? $"{change:N0} đ" : "Chưa đủ tiền!";
                lblChange.ForeColor = change >= 0 ? Color.Black : Color.Red;
            }
            else lblChange.Text = "0 đ";
        }

        private void Checkout()
        {
            if (_cart.Count == 0) { MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (!decimal.TryParse(txtCashReceived.Text, out var cash) || cash < total)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Thanh toán thành công!\nTổng: {total:N0} đ | Tiền thừa: {cash - total:N0} đ", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }

        private void ClearAll()
        {
            _cart.Clear(); txtCashReceived.Clear(); txtCustomerPhone.Clear();
            lblCustomerName.Text = "Khách vãng lai"; UpdateTotals(); txtBarcode.Focus();
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {

        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}