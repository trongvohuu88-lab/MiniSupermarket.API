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
            txtSearch = new TextBox();
            cboFilter = new ComboBox();
            btnSearch = new Button();
            dgv = new DataGridView();
            panelRight = new TableLayoutPanel();
            panelButtons = new FlowLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblPrice = new Label();
            nudPrice = new NumericUpDown();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            topPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(13, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Mã vạch / tên sản phẩm";
            txtSearch.Size = new Size(220, 23);
            txtSearch.TabIndex = 0;
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Location = new Point(13, 42);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(180, 23);
            cboFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(199, 42);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 48);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(0, 221);
            dgv.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.ColumnCount = 2;
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelRight.Controls.Add(panelButtons);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(-48, 48);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10);
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelRight.Size = new Size(340, 221);
            panelRight.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.AutoSize = true;
            panelRight.SetColumnSpan(panelButtons, 2);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(13, 13);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(314, 195);
            panelButtons.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.Location = new Point(0, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(0, 0);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            // 
            // lblBarcode
            // 
            lblBarcode.Location = new Point(0, 0);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(100, 23);
            lblBarcode.TabIndex = 0;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(0, 0);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(100, 23);
            txtBarcode.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(0, 0);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(0, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 0;
            // 
            // nudPrice
            // 
            nudPrice.Location = new Point(0, 0);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(120, 23);
            nudPrice.TabIndex = 0;
            nudPrice.ThousandsSeparator = true;
            // 
            // lblStock
            // 
            lblStock.Location = new Point(0, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 0;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(0, 0);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 0;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(0, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(100, 23);
            lblUnit.TabIndex = 0;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(0, 0);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(100, 23);
            txtUnit.TabIndex = 0;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(0, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 0;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(0, 0);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(121, 23);
            cboCategory.TabIndex = 0;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(txtSearch);
            topPanel.Controls.Add(cboFilter);
            topPanel.Controls.Add(btnSearch);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10, 10, 0, 0);
            topPanel.Size = new Size(292, 48);
            topPanel.TabIndex = 2;
            // 
            // FormProductManagement
            // 
            ClientSize = new Size(292, 269);
            Controls.Add(dgv);
            Controls.Add(panelRight);
            Controls.Add(topPanel);
            Name = "FormProductManagement";
            Text = "Quản lý sản phẩm";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        private void AddInputRow(string labelText, Control c, Label lbl, TableLayoutPanel container, int rowIndex)
        {
            lbl.Text = labelText;
            lbl.Anchor = AnchorStyles.Left;
            lbl.AutoSize = true;
            lbl.Margin = new Padding(0, 8, 0, 8);

            c.Dock = DockStyle.Fill;
            container.Controls.Add(lbl, 0, rowIndex);
            container.Controls.Add(c, 1, rowIndex);
        }

        private static Button MakeBtn(string text, Color color) => new()
        {
            Text = text,
            BackColor = color,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Width = 75,
            Height = 34
        };

        #endregion

        private TextBox txtSearch;
        private ComboBox cboFilter;
        private Button btnSearch;
        private DataGridView dgv;
        private TableLayoutPanel panelRight;
        private TextBox txtId;
        private TextBox txtBarcode;
        private TextBox txtName;
        private NumericUpDown nudPrice;
        private NumericUpDown nudStock;
        private TextBox txtUnit;
        private ComboBox cboCategory;
        private FlowLayoutPanel panelButtons;
        private FlowLayoutPanel topPanel;
        private Label lblId, lblBarcode, lblName, lblPrice, lblStock, lblUnit, lblCategory;
        private Button btnNew, btnAdd, btnUpdate, btnDelete;
    }
}