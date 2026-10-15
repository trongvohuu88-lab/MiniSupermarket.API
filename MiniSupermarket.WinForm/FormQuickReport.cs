namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();

            if (btnRunReport != null)
            {
                btnRunReport.Click += (_, _) => RunReport();
            }

            Reset();
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

        private void RunReport()
        {
            if (!SessionManager.IsInRole("Admin"))
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Reset();

            string selectedDate = dtp != null ? dtp.Value.ToString("dd/MM/yyyy") : DateTime.Now.ToString("dd/MM/yyyy");

            MessageBox.Show($"Chưa có dữ liệu hóa đơn ngày {selectedDate} (sẽ nối API ở Buổi 5).", "Thông báo");
        }
    }
}