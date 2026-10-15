namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dtp = new DateTimePicker();
            btnRunReport = new Button();
            topPanel = new FlowLayoutPanel();
            lblDate = new Label();
            cardsPanel = new TableLayoutPanel();
            dgvReport = new DataGridView();

            // Khởi tạo các nhãn giá trị và tiêu đề cho thẻ KPI
            lblTotalOrders = new Label();
            lblTotalRevenue = new Label();
            lblBestSeller = new Label();

            card1 = MakeCard("TỔNG SỐ ĐƠN", lblTotalOrders, Color.FromArgb(52, 152, 219));
            card2 = MakeCard("TỔNG DOANH THU", lblTotalRevenue, Color.FromArgb(46, 204, 113));
            card3 = MakeCard("SẢN PHẨM BÁN CHẠY", lblBestSeller, Color.FromArgb(155, 89, 182));

            topPanel.SuspendLayout();
            cardsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvReport)).BeginInit();
            SuspendLayout();

            // topPanel (Khu vực chọn ngày & nút bấm)
            topPanel.Controls.Add(lblDate);
            topPanel.Controls.Add(dtp);
            topPanel.Controls.Add(btnRunReport);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(16, 16, 16, 8);
            topPanel.Size = new Size(800, 60);
            topPanel.TabIndex = 0;
            topPanel.BackColor = Color.White;

            // lblDate
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblDate.Location = new Point(16, 20);
            lblDate.Margin = new Padding(0, 5, 8, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(42, 17);
            lblDate.Text = "Ngày:";

            // dtp
            dtp.Format = DateTimePickerFormat.Short;
            dtp.Location = new Point(66, 17);
            dtp.Name = "dtp";
            dtp.Size = new Size(140, 23);
            dtp.TabIndex = 1;

            // btnRunReport
            btnRunReport.BackColor = Color.FromArgb(41, 128, 185);
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.ForeColor = Color.White;
            btnRunReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRunReport.Location = new Point(220, 15);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(120, 28);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "Xem báo cáo";
            btnRunReport.UseVisualStyleBackColor = false;

            // cardsPanel (Chứa 3 thẻ KPI nằm ngang)
            cardsPanel.ColumnCount = 3;
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsPanel.Dock = DockStyle.Top;
            cardsPanel.Location = new Point(0, 60);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Padding = new Padding(16, 8, 16, 12);
            cardsPanel.RowCount = 1;
            cardsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cardsPanel.Size = new Size(800, 120);
            cardsPanel.TabIndex = 1;

            cardsPanel.Controls.Add(card1, 0, 0);
            cardsPanel.Controls.Add(card2, 1, 0);
            cardsPanel.Controls.Add(card3, 2, 0);

            // dgvReport (Bảng chi tiết bên dưới)
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(0, 180);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersVisible = false;
            dgvReport.Size = new Size(800, 320);
            dgvReport.TabIndex = 2;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // FormQuickReport
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            ClientSize = new Size(800, 500);
            Controls.Add(dgvReport);
            Controls.Add(cardsPanel);
            Controls.Add(topPanel);
            Name = "FormQuickReport";
            Text = "Báo cáo doanh thu & hiệu suất";

            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            cardsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dgvReport)).EndInit();
            ResumeLayout(false);
        }

        private static Panel MakeCard(string title, Label valueLabel, Color accentColor)
        {
            var p = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(6)
            };

            // Thanh màu trang trí bên trái card
            var strip = new Panel
            {
                Dock = DockStyle.Left,
                Width = 6,
                BackColor = accentColor
            };

            // Tiêu đề card
            var lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 30,
                ForeColor = Color.FromArgb(120, 120, 120),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 5, 0, 0)
            };

            // Giá trị số liệu
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.ForeColor = Color.FromArgb(40, 40, 40);
            valueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;

            p.Controls.Add(valueLabel);
            p.Controls.Add(lblTitle);
            p.Controls.Add(strip);

            return p;
        }

        #endregion

        private DateTimePicker dtp;
        private Button btnRunReport;
        private Label lblTotalOrders;
        private Label lblTotalRevenue;
        private Label lblBestSeller;
        private FlowLayoutPanel topPanel;
        private Label lblDate;
        private TableLayoutPanel cardsPanel;
        private DataGridView dgvReport;
        private Panel card1;
        private Panel card2;
        private Panel card3;
    }
}