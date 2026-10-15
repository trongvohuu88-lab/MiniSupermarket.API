namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            txtBarcode = new TextBox();
            dgvCart = new DataGridView();
            layoutMain = new TableLayoutPanel();
            panelLeft = new Panel();
            panelRight = new FlowLayoutPanel();
            lblPhoneTitle = new Label();
            txtCustomerPhone = new TextBox();
            lblCustomerName = new Label();
            lblTotalTitle = new Label();
            lblTotalAmount = new Label();
            lblCashTitle = new Label();
            txtCashReceived = new TextBox();
            lblChangeTitle = new Label();
            lblChange = new Label();
            btnCheckout = new Button();
            btnClearCart = new Button();

            ((System.ComponentModel.ISupportInitialize)(dgvCart)).BeginInit();
            layoutMain.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();

            // 
            // txtBarcode
            // 
            txtBarcode.Dock = DockStyle.Top;
            txtBarcode.Font = new Font("Segoe UI", 14F);
            txtBarcode.PlaceholderText = "Quét mã vạch rồi nhấn Enter...";
            txtBarcode.Name = "txtBarcode";

            // 
            // dgvCart
            // 
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(0, 38);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(dgvCart);
            panelLeft.Controls.Add(txtBarcode);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(678, 656);

            // 
            // panelRight
            // 
            panelRight.Controls.Add(lblPhoneTitle);
            panelRight.Controls.Add(txtCustomerPhone);
            panelRight.Controls.Add(lblCustomerName);
            panelRight.Controls.Add(lblTotalTitle);
            panelRight.Controls.Add(lblTotalAmount);
            panelRight.Controls.Add(lblCashTitle);
            panelRight.Controls.Add(txtCashReceived);
            panelRight.Controls.Add(lblChangeTitle);
            panelRight.Controls.Add(lblChange);
            panelRight.Controls.Add(btnCheckout);
            panelRight.Controls.Add(btnClearCart);
            panelRight.Dock = DockStyle.Fill;
            panelRight.FlowDirection = FlowDirection.TopDown;
            panelRight.Location = new Point(687, 3);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10, 0, 0, 0);
            panelRight.WrapContents = false;

            // Các Control bên cột phải
            lblPhoneTitle.AutoSize = true;
            lblPhoneTitle.Text = "SĐT khách hàng:";
            lblPhoneTitle.Margin = new Padding(0, 5, 0, 3);

            txtCustomerPhone.Font = new Font("Segoe UI", 12F);
            txtCustomerPhone.Width = 300;
            txtCustomerPhone.PlaceholderText = "Nhập SĐT...";

            lblCustomerName.AutoSize = true;
            lblCustomerName.Text = "Khách vãng lai";
            lblCustomerName.Margin = new Padding(0, 5, 0, 15);

            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalTitle.Text = "TỔNG TIỀN:";
            lblTotalTitle.Margin = new Padding(0, 10, 0, 3);

            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Firebrick;
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.Margin = new Padding(0, 0, 0, 15);

            lblCashTitle.AutoSize = true;
            lblCashTitle.Text = "Tiền khách đưa:";
            lblCashTitle.Margin = new Padding(0, 5, 0, 3);

            txtCashReceived.Font = new Font("Segoe UI", 12F);
            txtCashReceived.Width = 300;

            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Text = "Tiền thừa:";
            lblChangeTitle.Margin = new Padding(0, 15, 0, 3);

            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChange.Text = "0 đ";
            lblChange.Margin = new Padding(0, 0, 0, 20);

            btnCheckout.BackColor = Color.SeaGreen;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Height = 54;
            btnCheckout.Width = 300;
            btnCheckout.Text = "THANH TOÁN (F9)";
            btnCheckout.Margin = new Padding(0, 0, 0, 10);

            btnClearCart.BackColor = Color.Firebrick;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Height = 40;
            btnClearCart.Width = 300;
            btnClearCart.Text = "HỦY GIỎ HÀNG";

            // 
            // layoutMain
            // 
            layoutMain.ColumnCount = 2;
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutMain.Controls.Add(panelLeft, 0, 0);
            layoutMain.Controls.Add(panelRight, 1, 0);
            layoutMain.Location = new Point(0, 0);
            layoutMain.Name = "layoutMain";
            layoutMain.Padding = new Padding(10);
            layoutMain.RowCount = 1;

            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 662);
            Controls.Add(layoutMain);
            Name = "FormPOS";
            Text = "Bán hàng POS";

            ((System.ComponentModel.ISupportInitialize)(dgvCart)).EndInit();
            layoutMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBarcode;
        private DataGridView dgvCart;
        private TableLayoutPanel layoutMain;
        private Panel panelLeft;
        private FlowLayoutPanel panelRight;
        private Label lblPhoneTitle;
        private TextBox txtCustomerPhone;
        private Label lblCustomerName;
        private Label lblTotalTitle;
        private Label lblTotalAmount;
        private Label lblCashTitle;
        private TextBox txtCashReceived;
        private Label lblChangeTitle;
        private Label lblChange;
        private Button btnCheckout;
        private Button btnClearCart;
    }
}