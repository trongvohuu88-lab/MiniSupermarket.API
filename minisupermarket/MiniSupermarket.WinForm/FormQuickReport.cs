using System.Net.Http.Json;
using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();

            // Gắn sự kiện bấm nút xem báo cáo
            if (btnRunReport != null)
            {
                btnRunReport.Click += async (_, _) => await RunReportAsync();
            }

            // Tự động tải dữ liệu ngay khi mở form
            _ = Task.Run(async () => await LoadInitialDataAsync());
        }

        private void Reset()
        {
            if (lblTotalOrders != null) lblTotalOrders.Text = "0";
            if (lblTotalRevenue != null) lblTotalRevenue.Text = "0 đ";
            if (lblBestSeller != null) lblBestSeller.Text = "—";

            if (dgvReport != null)
            {
                dgvReport.DataSource = null;
            }
        }

        private async Task LoadInitialDataAsync()
        {
            // Kiểm tra phân quyền Admin
            if (!SessionManager.IsInRole("Admin"))
            {
                this.Invoke(() =>
                {
                    MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                });
                return;
            }

            await RunReportAsync();
        }

        private async Task RunReportAsync()
        {
            if (!SessionManager.IsInRole("Admin"))
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (ApiClientService.Client == null) return;

                // Gọi API lấy báo cáo doanh thu theo thu ngân
                var response = await ApiClientService.Client.GetFromJsonAsync<CashierReportApiResponse>("reports/revenue-by-cashier");

                if (response != null && response.Success)
                {
                    // Cập nhật giao diện an toàn trên UI Thread
                    this.Invoke(() =>
                    {
                        if (lblTotalOrders != null) lblTotalOrders.Text = response.TotalCashiers.ToString("N0");
                        if (lblTotalRevenue != null) lblTotalRevenue.Text = $"{response.GrandTotalRevenue:N0} đ";
                        if (lblBestSeller != null) lblBestSeller.Text = $"Tổng số thu ngân: {response.TotalCashiers}";

                        if (dgvReport != null)
                        {
                            dgvReport.DataSource = response.Data;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke(() =>
                {
                    MessageBox.Show("Lỗi tải báo cáo từ server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                });
            }
        }
    }

    // Các lớp DTO hứng kết cấu JSON trả về từ ReportsController
    public class CashierReportApiResponse
    {
        public bool Success { get; set; }
        public string GeneratedAt { get; set; } = string.Empty;
        public int TotalCashiers { get; set; }
        public decimal GrandTotalRevenue { get; set; }
        public List<CashierRevenueItemDto> Data { get; set; } = new();
    }

    public class CashierRevenueItemDto
    {
        public string CashierUsername { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalPointsAwarded { get; set; }
    }
}