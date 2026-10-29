namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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
            dgv = new DataGridView();
            panelRight = new TableLayoutPanel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            panelButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnReset = new Button();
            btnLock = new Button();

            ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();
            panelRight.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();

            // 
            // dgv
            // 
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;

            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Width = 320;
            panelRight.Padding = new Padding(10);
            panelRight.ColumnCount = 2;
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            panelRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            AddInputRow("Username", txtUsername, lblUsername, panelRight, 0);
            AddInputRow("Họ tên", txtFullName, lblFullName, panelRight, 1);

            txtPassword.UseSystemPasswordChar = true;
            AddInputRow("Mật khẩu", txtPassword, lblPassword, panelRight, 2);

            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Items.AddRange(new object[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1;
            AddInputRow("Vai trò", cboRole, lblRole, panelRight, 3);

            // 
            // panelButtons
            // 
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.AutoSize = true;
            panelButtons.FlowDirection = FlowDirection.TopDown;

            btnAdd.Text = "Thêm tài khoản";
            btnAdd.Width = 200;
            btnAdd.Height = 34;
            btnAdd.Margin = new Padding(0, 5, 0, 5);

            btnReset.Text = "Reset mật khẩu (123456)";
            btnReset.Width = 200;
            btnReset.Height = 34;
            btnReset.Margin = new Padding(0, 5, 0, 5);

            btnLock.Text = "Khóa / Mở khóa";
            btnLock.Width = 200;
            btnLock.Height = 34;
            btnLock.Margin = new Padding(0, 5, 0, 5);

            panelButtons.Controls.AddRange(new Control[] { btnAdd, btnReset, btnLock });
            panelRight.Controls.Add(panelButtons, 0, 4);
            panelRight.SetColumnSpan(panelButtons, 2);

            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 662);
            Controls.Add(dgv);
            Controls.Add(panelRight);
            Name = "FormUserManagement";
            Text = "Quản trị tài khoản";

            ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelButtons.ResumeLayout(false);
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

        #endregion

        private DataGridView dgv;
        private TableLayoutPanel panelRight;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private ComboBox cboRole;
        private FlowLayoutPanel panelButtons;
        private Button btnAdd;
        private Button btnReset;
        private Button btnLock;
        private Label lblUsername;
        private Label lblFullName;
        private Label lblPassword;
        private Label lblRole;
    }
}