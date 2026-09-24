namespace MiniSupermarket.WinForms
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpLogin = new GroupBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            grpLogin.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpLogin
            // 
            grpLogin.Controls.Add(lblUsername);
            grpLogin.Controls.Add(txtUsername);
            grpLogin.Controls.Add(lblPassword);
            grpLogin.Controls.Add(txtPassword);
            grpLogin.Controls.Add(btnLogin);
            grpLogin.Controls.Add(btnExit);
            grpLogin.Location = new Point(45, 30);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(360, 210);
            grpLogin.TabIndex = 0;
            grpLogin.TabStop = false;
            grpLogin.Text = "Đăng nhập";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(25, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(100, 37);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Ví dụ: admin";
            txtUsername.Size = new Size(220, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(25, 80);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 77);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightSkyBlue;
            btnLogin.FlatStyle = FlatStyle.System;
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogin.Location = new Point(100, 120);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(220, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập hệ thống";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(245, 165);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 25);
            btnExit.TabIndex = 5;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 260);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(450, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(111, 17);
            lblStatus.Text = "Kết nối: Chưa xác thực";
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 282);
            Controls.Add(grpLogin);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống - FormLogin";
            grpLogin.ResumeLayout(false);
            grpLogin.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpLogin;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}