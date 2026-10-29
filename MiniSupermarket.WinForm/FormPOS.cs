using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormPOS : Form
    {
        private readonly BindingList<CartItem> _cart = new();
        private int? _selectedCustomerId;
        private string? _selectedCustomerPhone;

        public FormPOS()
        {
            InitializeComponent();

            Text = "Bán hàng POS";
            BackColor = Color.FromArgb(244, 245, 247);
            KeyPreview = true;
            BuildUiLogic();
        }

        private void BuildUiLogic()
        {
            dgvCart.AutoGenerateColumns = false;
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
            txtCustomerPhone.TextChanged += (_, _) =>
            {
                if (_selectedCustomerId != null && !string.Equals(txtCustomerPhone.Text.Trim(), _selectedCustomerPhone, StringComparison.Ordinal))
                {
                    _selectedCustomerId = null;
                    _selectedCustomerPhone = null;
                    lblCustomerName.Text = "Chưa xác định khách hàng";
                }
            };
            txtCashReceived.TextChanged += (_, _) => CalculateChange();
            btnCheckout.Click += async (_, _) => await CheckoutAsync();
            btnClearCart.Click += (_, _) => ClearAll();
            KeyDown += async (_, e) => { if (e.KeyCode == Keys.F9) { e.Handled = true; e.SuppressKeyPress = true; await CheckoutAsync(); } };
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
                    // Đã sửa thành product.Price để lấy đúng giá sản phẩm từ API/DTO
                    _cart.Add(new CartItem
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
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
            _selectedCustomerId = null;
            _selectedCustomerPhone = null;
            if (phone.Length == 0)
            {
                lblCustomerName.Text = "Chưa chọn khách hàng";
                return;
            }

            try
            {
                var all = await ApiClientService.Client.GetFromJsonAsync<List<Customer>>("customers") ?? new();
                var customer = all.FirstOrDefault(x => string.Equals(x.PhoneNumber?.Trim(), phone, StringComparison.Ordinal));
                if (customer == null)
                {
                    lblCustomerName.Text = "Không tìm thấy khách hàng";
                    return;
                }

                _selectedCustomerId = customer.CustomerId;
                _selectedCustomerPhone = phone;
                lblCustomerName.Text = $"{customer.CustomerName} - Hạng {customer.MembershipRank} ({customer.RewardPoints} điểm)";
            }
            catch (Exception ex)
            {
                lblCustomerName.Text = "Chưa xác định khách hàng";
                MessageBox.Show("Lỗi tra cứu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async Task CheckoutAsync()
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // API yêu cầu CustomerId hợp lệ vì Orders.CustomerId là khóa ngoại bắt buộc.
            // Tra cứu lại nếu thu ngân chưa nhấn Enter sau khi nhập số điện thoại.
            if (_selectedCustomerId == null)
                await LookupCustomerAsync();

            if (_selectedCustomerId == null)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng đã đăng ký và nhấn Enter để xác nhận trước khi thanh toán.",
                    "Chưa chọn khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerPhone.Focus();
                return;
            }

            decimal total = _cart.Sum(x => x.TotalPrice);
            if (!decimal.TryParse(txtCashReceived.Text, out var cash) || cash < total)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ hoặc không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(SessionManager.CurrentUsername))
            {
                MessageBox.Show("Không xác định được tài khoản thu ngân. Vui lòng đăng nhập lại.", "Lỗi phiên đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnCheckout.Enabled = false;
            try
            {
                var request = new CheckoutRequest
                {
                    CashierUsername = SessionManager.CurrentUsername,
                    CustomerId = _selectedCustomerId.Value,
                    Items = _cart.Select(item => new CheckoutItemRequest
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                };

                using var response = await ApiClientService.Client.PostAsJsonAsync("checkout", request);
                string responseText = await response.Content.ReadAsStringAsync();
                using var json = string.IsNullOrWhiteSpace(responseText) ? null : JsonDocument.Parse(responseText);

                if (!response.IsSuccessStatusCode)
                {
                    string message = $"Thanh toán thất bại (HTTP {(int)response.StatusCode}).";
                    if (json != null && json.RootElement.TryGetProperty("message", out var msg))
                        message = msg.GetString() ?? message;
                    MessageBox.Show(message, "Không thể thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string orderCode = "(không có mã hóa đơn)";
                if (json != null && json.RootElement.TryGetProperty("orderCode", out var code))
                    orderCode = code.GetString() ?? orderCode;

                decimal serverTotal = total;
                if (json != null && json.RootElement.TryGetProperty("finalAmount", out var amount)
                    && amount.TryGetDecimal(out var parsedAmount))
                    serverTotal = parsedAmount;

                int rewardPoints = 0;
                if (json != null && json.RootElement.TryGetProperty("rewardPointsAdded", out var points)
                    && points.TryGetInt32(out var parsedPoints))
                    rewardPoints = parsedPoints;

                MessageBox.Show($"Thanh toán đã được máy chủ ghi nhận.\nMã hóa đơn: {orderCode}\nTổng tiền: {serverTotal:N0} đ\nTiền thừa: {cash - serverTotal:N0} đ\nĐiểm tích lũy: {rewardPoints}",
                    "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Không kết nối được API thanh toán. Giao dịch chưa được xác nhận: " + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Máy chủ trả về dữ liệu không hợp lệ: " + ex.Message,
                    "Lỗi phản hồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hoàn tất thanh toán: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheckout.Enabled = true;
            }
        }

        private void ClearAll()
        {
            _cart.Clear();
            txtCashReceived.Clear();
            txtCustomerPhone.Clear();
            _selectedCustomerId = null;
            _selectedCustomerPhone = null;
            lblCustomerName.Text = "Chưa chọn khách hàng";
            UpdateTotals();
            txtBarcode.Focus();
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public sealed class CheckoutRequest
    {
        public string CashierUsername { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public List<CheckoutItemRequest> Items { get; set; } = new();
    }

    public sealed class CheckoutItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
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