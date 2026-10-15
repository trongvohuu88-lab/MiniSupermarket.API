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

            // Khởi tạo các nút bấm chức năng
            btnNew = MakeBtn("Làm mới", Color.Gray);
            btnAdd = MakeBtn("Thêm", Color.SeaGreen);
            btnUpdate = MakeBtn("Sửa", Color.RoyalBlue);
            btnDelete = MakeBtn("Xóa", Color.Firebrick);

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
            cboFilter.Location = new Point(239, 13);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(160, 23);
            cboFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(405, 13);
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
            dgv.Size = new Size(624, 413);
            dgv.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.ColumnCount = 2;
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(624, 48);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10);
            panelRight.RowCount = 8;
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelRight.Size = new Size(340, 413);
            panelRight.TabIndex = 1;

            // Đưa các dòng nhập liệu vào panelRight theo từng hàng
            AddInputRow("Mã ID:", txtId, lblId, panelRight, 0);
            AddInputRow("Mã vạch:", txtBarcode, lblBarcode, panelRight, 1);
            AddInputRow("Tên SP:", txtName, lblName, panelRight, 2);
            AddInputRow("Đơn giá:", nudPrice, lblPrice, panelRight, 3);
            AddInputRow("Tồn kho:", nudStock, lblStock, panelRight, 4);
            AddInputRow("Đơn vị:", txtUnit, lblUnit, panelRight, 5);
            AddInputRow("Nhóm hàng:", cboCategory, lblCategory, panelRight, 6);

            // 
            // panelButtons
            // 
            panelButtons.AutoSize = true;
            panelButtons.Controls.Add(btnNew);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(13, 255);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(314, 145);
            panelButtons.TabIndex = 0;

            panelRight.Controls.Add(panelButtons, 0, 7);
            panelRight.SetColumnSpan(panelButtons, 2);

            // Cấu hình thuộc tính cho các control riêng lẻ
            txtId.ReadOnly = true;
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.ThousandsSeparator = true;
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

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
            topPanel.Size = new Size(964, 48);
            topPanel.TabIndex = 2;
            // 
            // FormProductManagement
            // 
            ClientSize = new Size(964, 461);
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
            Width = 72,
            Height = 34,
            Margin = new Padding(3, 3, 3, 3)
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