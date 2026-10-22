namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            panelInputs = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            nudStock = new NumericUpDown();
            lblStock = new Label();
            nudPrice = new NumericUpDown();
            lblPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtBarcode = new TextBox();
            lblBarcode = new Label();
            txtId = new TextBox();
            lblId = new Label();

            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();

            dgvProducts = new DataGridView();

            panelPaging = new Panel();
            btnNext = new Button();
            lblPaging = new Label();
            btnPrev = new Button();

            panelInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelPaging.SuspendLayout();
            SuspendLayout();
            // 
            // panelInputs
            // 
            panelInputs.BorderStyle = BorderStyle.FixedSingle;
            panelInputs.Controls.Add(btnDelete);
            panelInputs.Controls.Add(btnUpdate);
            panelInputs.Controls.Add(btnCreate);
            panelInputs.Controls.Add(nudStock);
            panelInputs.Controls.Add(lblStock);
            panelInputs.Controls.Add(nudPrice);
            panelInputs.Controls.Add(lblPrice);
            panelInputs.Controls.Add(cboCategory);
            panelInputs.Controls.Add(lblCategory);
            panelInputs.Controls.Add(txtName);
            panelInputs.Controls.Add(lblName);
            panelInputs.Controls.Add(txtBarcode);
            panelInputs.Controls.Add(lblBarcode);
            panelInputs.Controls.Add(txtId);
            panelInputs.Controls.Add(lblId);
            panelInputs.Dock = DockStyle.Top;
            panelInputs.Location = new Point(0, 0);
            panelInputs.Name = "panelInputs";
            panelInputs.Size = new Size(964, 115);
            panelInputs.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(560, 75);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 30);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa hàng";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.RoyalBlue;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(440, 75);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 30);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.SeaGreen;
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(320, 75);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(110, 30);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "Thêm mới";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(380, 42);
            Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(150, 23);
            nudStock.TabIndex = 11;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(310, 44);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(64, 15);
            lblStock.TabIndex = 10;
            lblStock.Text = "TỒN KHO:";
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(85, 42);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(200, 23);
            nudPrice.TabIndex = 9;
            nudPrice.ThousandsSeparator = true;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 44);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 15);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "GIÁ BÁN:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(740, 10);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(210, 23);
            cboCategory.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(680, 13);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(47, 15);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "NHÓM:";
            // 
            // txtName
            // 
            txtName.Location = new Point(410, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 5;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(350, 13);
            lblName.Name = "lblName";
            lblName.Size = new Size(48, 15);
            lblName.TabIndex = 4;
            lblName.Text = "TÊN SP:";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(180, 10);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(150, 23);
            txtBarcode.TabIndex = 3;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Location = new Point(105, 13);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(65, 15);
            lblBarcode.TabIndex = 2;
            lblBarcode.Text = "MÃ VẠCH:";
            // 
            // txtId
            // 
            txtId.Location = new Point(45, 10);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(50, 23);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(12, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // panelSearch
            // 
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 115);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(964, 45);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(330, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(80, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã vạch hoặc tên sản phẩm...";
            txtSearch.Size = new Size(240, 23);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 13);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(60, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 160);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(964, 256);
            dgvProducts.TabIndex = 2;
            // 
            // panelPaging
            // 
            panelPaging.BorderStyle = BorderStyle.FixedSingle;
            panelPaging.Controls.Add(btnNext);
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Controls.Add(btnPrev);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 416);
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(964, 45);
            panelPaging.TabIndex = 3;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top;
            btnNext.Location = new Point(530, 9);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(90, 25);
            btnNext.TabIndex = 2;
            btnNext.Text = "Trang sau >>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // lblPaging
            // 
            lblPaging.Anchor = AnchorStyles.Top;
            lblPaging.AutoSize = true;
            lblPaging.Location = new Point(445, 13);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(60, 15);
            lblPaging.TabIndex = 1;
            lblPaging.Text = "Trang: 1 / 1";
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Top;
            btnPrev.Location = new Point(340, 9);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(90, 25);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "<< Trang trước";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // FormProductManagement
            // 
            ClientSize = new Size(964, 461);
            Controls.Add(dgvProducts);
            Controls.Add(panelPaging);
            Controls.Add(panelSearch);
            Controls.Add(panelInputs);
            Name = "FormProductManagement";
            Text = "Quản lý sản phẩm";
            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInputs;
        private TextBox txtId;
        private Label lblId;
        private TextBox txtBarcode;
        private Label lblBarcode;
        private TextBox txtName;
        private Label lblName;
        private ComboBox cboCategory;
        private Label lblCategory;
        private NumericUpDown nudPrice;
        private Label lblPrice;
        private NumericUpDown nudStock;
        private Label lblStock;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;

        private Panel panelSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;

        private DataGridView dgvProducts;

        private Panel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;

        public decimal Maximum { get; private set; }
    }
}