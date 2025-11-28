namespace DOANCUATAI.GiaoDien
{
    partial class QLLichSuBaoHanh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLLichSuBaoHanh));
            this.txt_tim = new System.Windows.Forms.TextBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_all = new System.Windows.Forms.Button();
            this.comboBoxLichSu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_LichSuBaoHanh = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lb_TrangThai = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_TenKhachHang = new System.Windows.Forms.Label();
            this.lb_TenSP = new System.Windows.Forms.Label();
            this.lb_NgayBH = new System.Windows.Forms.Label();
            this.lb_NoiDung = new System.Windows.Forms.Label();
            this.lb_ChiPhi = new System.Windows.Forms.Label();
            this.lb_NVTH = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaBH = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_tentour = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichSuBaoHanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_tim
            // 
            this.txt_tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txt_tim.Location = new System.Drawing.Point(23, 95);
            this.txt_tim.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tim.Name = "txt_tim";
            this.txt_tim.Size = new System.Drawing.Size(20, 31);
            this.txt_tim.TabIndex = 5;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Tim.Location = new System.Drawing.Point(52, 95);
            this.btn_Tim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(100, 32);
            this.btn_Tim.TabIndex = 6;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.comboBoxLichSu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgv_LichSuBaoHanh);
            this.groupBox1.Controls.Add(this.btn_Tim);
            this.groupBox1.Controls.Add(this.txt_tim);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(756, 560);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Lịch Sử Bảo Hành";
            // 
            // btn_all
            // 
            this.btn_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_all.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_all.FlatAppearance.BorderSize = 0;
            this.btn_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.ForeColor = System.Drawing.Color.White;
            this.btn_all.Location = new System.Drawing.Point(580, 505);
            this.btn_all.Margin = new System.Windows.Forms.Padding(4);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(140, 32);
            this.btn_all.TabIndex = 28;
            this.btn_all.Text = "Tất cả";
            this.btn_all.UseVisualStyleBackColor = false;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click_1);
            // 
            // comboBoxLichSu
            // 
            this.comboBoxLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.comboBoxLichSu.FormattingEnabled = true;
            this.comboBoxLichSu.Items.AddRange(new object[] {
            "Đang xử lý",
            "Hoàn Thành"});
            this.comboBoxLichSu.Location = new System.Drawing.Point(287, 95);
            this.comboBoxLichSu.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLichSu.Name = "comboBoxLichSu";
            this.comboBoxLichSu.Size = new System.Drawing.Size(431, 32);
            this.comboBoxLichSu.TabIndex = 8;
            this.comboBoxLichSu.Text = "Lọc theo loại ";
            this.comboBoxLichSu.SelectedIndexChanged += new System.EventHandler(this.comboBoxLichSu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhập Ten Khách Hàng cần tìm";
            // 
            // dgv_LichSuBaoHanh
            // 
            this.dgv_LichSuBaoHanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LichSuBaoHanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_LichSuBaoHanh.BackgroundColor = System.Drawing.Color.White;
            this.dgv_LichSuBaoHanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LichSuBaoHanh.Location = new System.Drawing.Point(23, 134);
            this.dgv_LichSuBaoHanh.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_LichSuBaoHanh.Name = "dgv_LichSuBaoHanh";
            this.dgv_LichSuBaoHanh.RowHeadersWidth = 62;
            this.dgv_LichSuBaoHanh.Size = new System.Drawing.Size(697, 350);
            this.dgv_LichSuBaoHanh.TabIndex = 0;
            this.dgv_LichSuBaoHanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_LichSuBaoHanh_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(157, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(346, 46);
            this.label6.TabIndex = 26;
            this.label6.Text = "LichSuaBaoHanh";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dalat1.jpg");
            this.imageList1.Images.SetKeyName(1, "japan1.jpg");
            this.imageList1.Images.SetKeyName(2, "korea1.jpg");
            this.imageList1.Images.SetKeyName(3, "malaysia1.jpg");
            this.imageList1.Images.SetKeyName(4, "phuquoc1.jpg");
            this.imageList1.Images.SetKeyName(5, "sapa1.jpg");
            this.imageList1.Images.SetKeyName(6, "sp1.jpg");
            this.imageList1.Images.SetKeyName(7, "danang1.jpg");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 148);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(1383, 560);
            this.splitContainer1.SplitterDistance = 756;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 28;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lb_TrangThai);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lb_TenKhachHang);
            this.groupBox4.Controls.Add(this.lb_TenSP);
            this.groupBox4.Controls.Add(this.lb_NgayBH);
            this.groupBox4.Controls.Add(this.lb_NoiDung);
            this.groupBox4.Controls.Add(this.lb_ChiPhi);
            this.groupBox4.Controls.Add(this.lb_NVTH);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.MaBH);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lb_tentour);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(622, 560);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi tiết TOUR";
            // 
            // lb_TrangThai
            // 
            this.lb_TrangThai.AutoSize = true;
            this.lb_TrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TrangThai.Location = new System.Drawing.Point(254, 508);
            this.lb_TrangThai.Name = "lb_TrangThai";
            this.lb_TrangThai.Size = new System.Drawing.Size(0, 29);
            this.lb_TrangThai.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 503);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 32);
            this.label11.TabIndex = 16;
            this.label11.Text = "Trang Thái";
            // 
            // lb_TenKhachHang
            // 
            this.lb_TenKhachHang.AutoSize = true;
            this.lb_TenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenKhachHang.Location = new System.Drawing.Point(254, 137);
            this.lb_TenKhachHang.Name = "lb_TenKhachHang";
            this.lb_TenKhachHang.Size = new System.Drawing.Size(0, 29);
            this.lb_TenKhachHang.TabIndex = 15;
            // 
            // lb_TenSP
            // 
            this.lb_TenSP.AutoSize = true;
            this.lb_TenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenSP.Location = new System.Drawing.Point(254, 201);
            this.lb_TenSP.Name = "lb_TenSP";
            this.lb_TenSP.Size = new System.Drawing.Size(0, 29);
            this.lb_TenSP.TabIndex = 14;
            // 
            // lb_NgayBH
            // 
            this.lb_NgayBH.AutoSize = true;
            this.lb_NgayBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayBH.Location = new System.Drawing.Point(254, 266);
            this.lb_NgayBH.Name = "lb_NgayBH";
            this.lb_NgayBH.Size = new System.Drawing.Size(0, 29);
            this.lb_NgayBH.TabIndex = 13;
            // 
            // lb_NoiDung
            // 
            this.lb_NoiDung.AutoSize = true;
            this.lb_NoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NoiDung.Location = new System.Drawing.Point(254, 336);
            this.lb_NoiDung.Name = "lb_NoiDung";
            this.lb_NoiDung.Size = new System.Drawing.Size(0, 29);
            this.lb_NoiDung.TabIndex = 12;
            // 
            // lb_ChiPhi
            // 
            this.lb_ChiPhi.AutoSize = true;
            this.lb_ChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ChiPhi.Location = new System.Drawing.Point(254, 399);
            this.lb_ChiPhi.Name = "lb_ChiPhi";
            this.lb_ChiPhi.Size = new System.Drawing.Size(0, 29);
            this.lb_ChiPhi.TabIndex = 11;
            // 
            // lb_NVTH
            // 
            this.lb_NVTH.AutoSize = true;
            this.lb_NVTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NVTH.Location = new System.Drawing.Point(254, 455);
            this.lb_NVTH.Name = "lb_NVTH";
            this.lb_NVTH.Size = new System.Drawing.Size(0, 29);
            this.lb_NVTH.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 32);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tên Khach Hàng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 32);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tên Sản Phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(226, 32);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ngày Bảo Hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "Nội Dung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chi Phí";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã NV thực Hiện ";
            // 
            // MaBH
            // 
            this.MaBH.AutoSize = true;
            this.MaBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaBH.Location = new System.Drawing.Point(254, 80);
            this.MaBH.Name = "MaBH";
            this.MaBH.Size = new System.Drawing.Size(0, 29);
            this.MaBH.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Bảo Hành";
        
            // 
            // lb_tentour
            // 
            this.lb_tentour.AutoSize = true;
            this.lb_tentour.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_tentour.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tentour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_tentour.Location = new System.Drawing.Point(4, 19);
            this.lb_tentour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tentour.Name = "lb_tentour";
            this.lb_tentour.Size = new System.Drawing.Size(342, 42);
            this.lb_tentour.TabIndex = 0;
            this.lb_tentour.Text = "Chi Tiết Đơn Hàng";
            this.lb_tentour.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1383, 148);
            this.panelTop.TabIndex = 29;
            // 
            // QLLichSuBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 708);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLLichSuBaoHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Tour";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LichSuBaoHanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_tim;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_LichSuBaoHanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLichSu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lb_tentour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MaBH;
        private System.Windows.Forms.Label lb_TenKhachHang;
        private System.Windows.Forms.Label lb_TenSP;
        private System.Windows.Forms.Label lb_NgayBH;
        private System.Windows.Forms.Label lb_NoiDung;
        private System.Windows.Forms.Label lb_ChiPhi;
        private System.Windows.Forms.Label lb_NVTH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_TrangThai;
        private System.Windows.Forms.Label label11;
    }
}