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
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            layoutMain.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // txtBarcode
            // 
            txtBarcode.Dock = DockStyle.Top;
            txtBarcode.Font = new Font("Segoe UI", 14F);
            txtBarcode.Location = new Point(0, 0);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Quét mã vạch rồi nhấn Enter...";
            txtBarcode.Size = new Size(670, 32);
            txtBarcode.TabIndex = 1;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 32);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(670, 604);
            dgvCart.TabIndex = 0;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // layoutMain
            // 
            layoutMain.ColumnCount = 2;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layoutMain.Controls.Add(panelLeft, 0, 0);
            layoutMain.Controls.Add(panelRight, 1, 0);
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.Location = new Point(0, 0);
            layoutMain.Name = "layoutMain";
            layoutMain.Padding = new Padding(10);
            layoutMain.RowCount = 1;
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMain.Size = new Size(1060, 662);
            layoutMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(dgvCart);
            panelLeft.Controls.Add(txtBarcode);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(13, 13);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(670, 636);
            panelLeft.TabIndex = 0;
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
            panelRight.Location = new Point(689, 13);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10, 0, 0, 0);
            panelRight.Size = new Size(358, 636);
            panelRight.TabIndex = 1;
            panelRight.WrapContents = false;
            // 
            // lblPhoneTitle
            // 
            lblPhoneTitle.AutoSize = true;
            lblPhoneTitle.Location = new Point(10, 5);
            lblPhoneTitle.Margin = new Padding(0, 5, 0, 3);
            lblPhoneTitle.Name = "lblPhoneTitle";
            lblPhoneTitle.Size = new Size(95, 15);
            lblPhoneTitle.TabIndex = 0;
            lblPhoneTitle.Text = "SĐT khách hàng:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Font = new Font("Segoe UI", 12F);
            txtCustomerPhone.Location = new Point(13, 26);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "Nhập SĐT...";
            txtCustomerPhone.Size = new Size(300, 29);
            txtCustomerPhone.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(10, 63);
            lblCustomerName.Margin = new Padding(0, 5, 0, 15);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(84, 15);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Khách vãng lai";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(10, 103);
            lblTotalTitle.Margin = new Padding(0, 10, 0, 3);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(87, 19);
            lblTotalTitle.TabIndex = 3;
            lblTotalTitle.Text = "TỔNG TIỀN:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Firebrick;
            lblTotalAmount.Location = new Point(10, 125);
            lblTotalAmount.Margin = new Padding(0, 0, 0, 15);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(67, 45);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "0 đ";
            // 
            // lblCashTitle
            // 
            lblCashTitle.AutoSize = true;
            lblCashTitle.Location = new Point(10, 190);
            lblCashTitle.Margin = new Padding(0, 5, 0, 3);
            lblCashTitle.Name = "lblCashTitle";
            lblCashTitle.Size = new Size(90, 15);
            lblCashTitle.TabIndex = 5;
            lblCashTitle.Text = "Tiền khách đưa:";
            // 
            // txtCashReceived
            // 
            txtCashReceived.Font = new Font("Segoe UI", 12F);
            txtCashReceived.Location = new Point(13, 211);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.Size = new Size(300, 29);
            txtCashReceived.TabIndex = 6;
            // 
            // lblChangeTitle
            // 
            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Location = new Point(10, 258);
            lblChangeTitle.Margin = new Padding(0, 15, 0, 3);
            lblChangeTitle.Name = "lblChangeTitle";
            lblChangeTitle.Size = new Size(59, 15);
            lblChangeTitle.TabIndex = 7;
            lblChangeTitle.Text = "Tiền thừa:";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChange.Location = new Point(10, 276);
            lblChange.Margin = new Padding(0, 0, 0, 20);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(40, 25);
            lblChange.TabIndex = 8;
            lblChange.Text = "0 đ";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.SeaGreen;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(10, 321);
            btnCheckout.Margin = new Padding(0, 0, 0, 10);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(300, 54);
            btnCheckout.TabIndex = 9;
            btnCheckout.Text = "THANH TOÁN (F9)";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.Firebrick;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(13, 388);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(300, 40);
            btnClearCart.TabIndex = 10;
            btnClearCart.Text = "HỦY GIỎ HÀNG";
            btnClearCart.UseVisualStyleBackColor = false;
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 662);
            Controls.Add(layoutMain);
            Name = "FormPOS";
            Text = "Bán hàng POS";
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            layoutMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
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