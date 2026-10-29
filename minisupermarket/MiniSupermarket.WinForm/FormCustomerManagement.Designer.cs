#nullable enable
namespace MiniSupermarket.Client
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            lblId = new Label();
            lblName = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblPoints = new Label();
            lblRank = new Label();
            lblSearch = new Label();
            txtCustomerId = new TextBox();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtAddress = new TextBox();
            txtRewardPoints = new TextBox();
            txtMembershipRank = new TextBox();
            txtSearch = new TextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            // dgvCustomers
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Location = new Point(12, 60);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(860, 260);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;

            // Hàng tìm kiếm
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 22);
            lblSearch.Text = "Từ khóa:";

            txtSearch.Location = new Point(80, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(280, 27);
            txtSearch.PlaceholderText = "Tên hoặc số điện thoại...";

            btnSearch.Location = new Point(370, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;

            btnLoad.Location = new Point(480, 16);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 30);
            btnLoad.Text = "Tải danh sách";
            btnLoad.Click += btnLoad_Click;

            // Cột trái: Id, Tên, SĐT
            AddField(lblId, "Mã KH:", 12, 340, txtCustomerId, "txtCustomerId", 110, 340, 250);
            txtCustomerId.ReadOnly = true;
            AddField(lblName, "Tên KH:", 12, 380, txtCustomerName, "txtCustomerName", 110, 380, 250);
            AddField(lblPhone, "Số điện thoại:", 12, 420, txtPhoneNumber, "txtPhoneNumber", 110, 420, 250);

            // Cột phải: Địa chỉ, Điểm, Hạng
            AddField(lblAddress, "Địa chỉ:", 400, 340, txtAddress, "txtAddress", 490, 340, 380);
            AddField(lblPoints, "Điểm thưởng:", 400, 380, txtRewardPoints, "txtRewardPoints", 490, 380, 150);
            AddField(lblRank, "Hạng thẻ:", 400, 420, txtMembershipRank, "txtMembershipRank", 490, 420, 150);

            // Các nút chức năng
            btnAdd.Location = new Point(12, 465);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 35);
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(132, 465);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 35);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(252, 465);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 35);
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 520);
            Controls.AddRange(new Control[] {
                dgvCustomers, lblSearch, txtSearch, btnSearch, btnLoad,
                btnAdd, btnUpdate, btnDelete });
            Name = "FormCustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách hàng thành viên";
            Load += FormCustomerManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Hàm hỗ trợ đặt vị trí Label + TextBox
        private void AddField(Label lbl, string caption, int lx, int ly,
                              TextBox txt, string name, int tx, int ty, int width)
        {
            lbl.AutoSize = true;
            lbl.Location = new Point(lx, ly + 4);
            lbl.Text = caption;

            txt.Name = name;
            txt.Location = new Point(tx, ty);
            txt.Size = new Size(width, 27);

            Controls.Add(lbl);
            Controls.Add(txt);
        }

        #endregion

        private DataGridView dgvCustomers;
        private Label lblId, lblName, lblPhone, lblAddress, lblPoints, lblRank, lblSearch;
        private TextBox txtCustomerId, txtCustomerName, txtPhoneNumber,
                        txtAddress, txtRewardPoints, txtMembershipRank, txtSearch;
        private Button btnLoad, btnAdd, btnUpdate, btnDelete, btnSearch;
    }
}