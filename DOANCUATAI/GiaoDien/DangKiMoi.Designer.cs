namespace DOANCUOIKY.GiaoDien
{
    partial class DangKyMoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKyMoi));
            this.panelControls = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_DangKy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_hoten = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.cbShowPass = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_XNMK = new System.Windows.Forms.TextBox();
            this.panelControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panelControls.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelControls.BackgroundImage")));
            this.panelControls.Controls.Add(this.panel1);
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(4);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1034, 794);
            this.panelControls.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txt_XNMK);
            this.panel1.Controls.Add(this.txt_MK);
            this.panel1.Controls.Add(this.btn_DangKy);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_hoten);
            this.panel1.Controls.Add(this.txt_email);
            this.panel1.Controls.Add(this.txt_sdt);
            this.panel1.Controls.Add(this.cbShowPass);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(232, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 582);
            this.panel1.TabIndex = 26;
            // 
            // btn_DangKy
            // 
            this.btn_DangKy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DangKy.BackColor = System.Drawing.Color.Red;
            this.btn_DangKy.FlatAppearance.BorderSize = 0;
            this.btn_DangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangKy.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btn_DangKy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_DangKy.Location = new System.Drawing.Point(119, 496);
            this.btn_DangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DangKy.Name = "btn_DangKy";
            this.btn_DangKy.Size = new System.Drawing.Size(378, 53);
            this.btn_DangKy.TabIndex = 6;
            this.btn_DangKy.Text = "Đăng Ký";
            this.btn_DangKy.UseVisualStyleBackColor = false;
            this.btn_DangKy.Click += new System.EventHandler(this.btn_DangKy_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 21;
            this.label7.Text = "Họ và Tên";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Location = new System.Drawing.Point(517, 69);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 63);
            this.exitButton.TabIndex = 7;
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 46);
            this.label4.TabIndex = 12;
            this.label4.Text = "Đăng Ký";
            // 
            // txt_hoten
            // 
            this.txt_hoten.Location = new System.Drawing.Point(195, 139);
            this.txt_hoten.Multiline = true;
            this.txt_hoten.Name = "txt_hoten";
            this.txt_hoten.Size = new System.Drawing.Size(397, 35);
            this.txt_hoten.TabIndex = 22;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(194, 208);
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(398, 35);
            this.txt_email.TabIndex = 23;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(194, 274);
            this.txt_sdt.Multiline = true;
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(398, 35);
            this.txt_sdt.TabIndex = 25;
            // 
            // cbShowPass
            // 
            this.cbShowPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.BackColor = System.Drawing.Color.Transparent;
            this.cbShowPass.FlatAppearance.BorderSize = 0;
            this.cbShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowPass.Location = new System.Drawing.Point(239, 450);
            this.cbShowPass.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Size = new System.Drawing.Size(163, 28);
            this.cbShowPass.TabIndex = 5;
            this.cbShowPass.Text = "Show Password";
            this.cbShowPass.UseVisualStyleBackColor = false;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.cbShowPass_CheckedChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 285);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 413);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 348);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 19;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // txt_MK
            // 
            this.txt_MK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_MK.Location = new System.Drawing.Point(195, 336);
            this.txt_MK.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.Size = new System.Drawing.Size(397, 41);
            this.txt_MK.TabIndex = 26;
            this.txt_MK.UseSystemPasswordChar = true;
            // 
            // txt_XNMK
            // 
            this.txt_XNMK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_XNMK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_XNMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_XNMK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_XNMK.Location = new System.Drawing.Point(194, 401);
            this.txt_XNMK.Margin = new System.Windows.Forms.Padding(4);
            this.txt_XNMK.Name = "txt_XNMK";
            this.txt_XNMK.Size = new System.Drawing.Size(398, 41);
            this.txt_XNMK.TabIndex = 27;
            this.txt_XNMK.UseSystemPasswordChar = true;
            // 
            // DangKyMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 794);
            this.Controls.Add(this.panelControls);
            this.Name = "DangKyMoi";
            this.Text = "DangKiMoi";
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbShowPass;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button btn_DangKy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_hoten;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_XNMK;
        private System.Windows.Forms.TextBox txt_MK;
    }
}