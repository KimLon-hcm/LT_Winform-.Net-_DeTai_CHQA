namespace DOANCUOIKY.GiaoDien
{
    partial class QLHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLHoaDon));
            this.dtHD = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtg_HD = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_chitietHD = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_idnd = new System.Windows.Forms.Label();
            this.lb_thanhtien = new System.Windows.Forms.Label();
            this.lb_madh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HD)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtHD
            // 
            this.dtHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.dtHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHD.Location = new System.Drawing.Point(756, 59);
            this.dtHD.Margin = new System.Windows.Forms.Padding(4);
            this.dtHD.Name = "dtHD";
            this.dtHD.Size = new System.Drawing.Size(480, 30);
            this.dtHD.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "ID DonHang";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Thành Tiền";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(619, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ngày lập HD";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(619, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "IDNguoiDung";
            // 
            // dtg_HD
            // 
            this.dtg_HD.BackgroundColor = System.Drawing.Color.White;
            this.dtg_HD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_HD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_HD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_HD.Location = new System.Drawing.Point(0, 123);
            this.dtg_HD.Margin = new System.Windows.Forms.Padding(4);
            this.dtg_HD.Name = "dtg_HD";
            this.dtg_HD.RowHeadersWidth = 62;
            this.dtg_HD.Size = new System.Drawing.Size(1298, 551);
            this.dtg_HD.TabIndex = 29;
            this.dtg_HD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_HD_CellContentClick);
            this.dtg_HD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_HD_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(196, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 46);
            this.label7.TabIndex = 44;
            this.label7.Text = "Đơn Hàng";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1298, 123);
            this.panelTop.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.flowLayoutPanel1);
            this.panelBottom.Controls.Add(this.tableLayoutPanel1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 674);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1298, 206);
            this.panelBottom.TabIndex = 50;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_chitietHD);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 131);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1298, 75);
            this.flowLayoutPanel1.TabIndex = 50;
            // 
            // btn_chitietHD
            // 
            this.btn_chitietHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(185)))), ((int)(((byte)(239)))));
            this.btn_chitietHD.FlatAppearance.BorderSize = 0;
            this.btn_chitietHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chitietHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chitietHD.ForeColor = System.Drawing.Color.White;
            this.btn_chitietHD.Image = ((System.Drawing.Image)(resources.GetObject("btn_chitietHD.Image")));
            this.btn_chitietHD.Location = new System.Drawing.Point(1056, 4);
            this.btn_chitietHD.Margin = new System.Windows.Forms.Padding(4);
            this.btn_chitietHD.Name = "btn_chitietHD";
            this.btn_chitietHD.Size = new System.Drawing.Size(238, 66);
            this.btn_chitietHD.TabIndex = 30;
            this.btn_chitietHD.UseVisualStyleBackColor = false;
            this.btn_chitietHD.Click += new System.EventHandler(this.btn_chitietHD_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(835, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(213, 66);
            this.btnXoa.TabIndex = 31;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lb_idnd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtHD, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_thanhtien, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_madh, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1240, 110);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // lb_idnd
            // 
            this.lb_idnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lb_idnd.AutoSize = true;
            this.lb_idnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_idnd.Location = new System.Drawing.Point(914, 0);
            this.lb_idnd.Name = "lb_idnd";
            this.lb_idnd.Size = new System.Drawing.Size(164, 55);
            this.lb_idnd.TabIndex = 50;
            this.lb_idnd.Text = "ID NguoiDung";
            this.lb_idnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_thanhtien
            // 
            this.lb_thanhtien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lb_thanhtien.AutoSize = true;
            this.lb_thanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thanhtien.Location = new System.Drawing.Point(303, 55);
            this.lb_thanhtien.Name = "lb_thanhtien";
            this.lb_thanhtien.Size = new System.Drawing.Size(136, 55);
            this.lb_thanhtien.TabIndex = 49;
            this.lb_thanhtien.Text = "Thành Tiền";
            this.lb_thanhtien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_madh
            // 
            this.lb_madh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lb_madh.AutoSize = true;
            this.lb_madh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_madh.Location = new System.Drawing.Point(302, 0);
            this.lb_madh.Name = "lb_madh";
            this.lb_madh.Size = new System.Drawing.Size(137, 55);
            this.lb_madh.TabIndex = 48;
            this.lb_madh.Text = "IDDonHang";
            this.lb_madh.Click += new System.EventHandler(this.lb_masp_Click);
            // 
            // QLHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 880);
            this.Controls.Add(this.dtg_HD);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLHoaDon";
            this.Text = "QLHoaDon";
            this.Load += new System.EventHandler(this.QLHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HD)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_chitietHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dtg_HD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lb_thanhtien;
        private System.Windows.Forms.Label lb_madh;
        private System.Windows.Forms.Label lb_idnd;
    }
}