namespace DOANCUATAI.GiaoDien
{
    partial class SanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanPham));
            this.btn_tim = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_thongtinsanpham = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lb_tensp = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_timsanpham = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTen = new System.Windows.Forms.Label();
            this.lbtonkho = new System.Windows.Forms.Label();
            this.lb_ten = new System.Windows.Forms.Label();
            this.lbgia = new System.Windows.Forms.Label();
            this.lb_gia = new System.Windows.Forms.Label();
            this.lb_hang = new System.Windows.Forms.Label();
            this.lbhang = new System.Windows.Forms.Label();
            this.lnLoai = new System.Windows.Forms.Label();
            this.lb_masp = new System.Windows.Forms.Label();
            this.lb_valuexp = new System.Windows.Forms.Label();
            this.lb_loai = new System.Windows.Forms.Label();
            this.lb_tonkho = new System.Windows.Forms.Label();
            this.ptb_anhminhhoa = new System.Windows.Forms.PictureBox();
            this.btn_datHang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinsanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_anhminhhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_tim
            // 
            this.btn_tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_tim.Location = new System.Drawing.Point(144, 97);
            this.btn_tim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(100, 32);
            this.btn_tim.TabIndex = 6;
            this.btn_tim.Text = "Tìm";
            this.btn_tim.UseVisualStyleBackColor = true;
            this.btn_tim.Click += new System.EventHandler(this.btn_tim_Click);
            // 
            // btn_all
            // 
            this.btn_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_all.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_all.FlatAppearance.BorderSize = 0;
            this.btn_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_all.ForeColor = System.Drawing.Color.White;
            this.btn_all.Location = new System.Drawing.Point(519, 667);
            this.btn_all.Margin = new System.Windows.Forms.Padding(4);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(140, 32);
            this.btn_all.TabIndex = 28;
            this.btn_all.Text = "Tất cả";
            this.btn_all.UseVisualStyleBackColor = false;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhập tên sản phẩm cần tìm";
            // 
            // dgv_thongtinsanpham
            // 
            this.dgv_thongtinsanpham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_thongtinsanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thongtinsanpham.BackgroundColor = System.Drawing.Color.White;
            this.dgv_thongtinsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thongtinsanpham.Location = new System.Drawing.Point(21, 154);
            this.dgv_thongtinsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_thongtinsanpham.Name = "dgv_thongtinsanpham";
            this.dgv_thongtinsanpham.RowHeadersWidth = 62;
            this.dgv_thongtinsanpham.Size = new System.Drawing.Size(731, 501);
            this.dgv_thongtinsanpham.TabIndex = 0;
            this.dgv_thongtinsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thongtinsanpham_CellClick);
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
            // lb_tensp
            // 
            this.lb_tensp.AutoSize = true;
            this.lb_tensp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_tensp.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tensp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_tensp.Location = new System.Drawing.Point(4, 19);
            this.lb_tensp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tensp.Name = "lb_tensp";
            this.lb_tensp.Size = new System.Drawing.Size(269, 42);
            this.lb_tensp.TabIndex = 0;
            this.lb_tensp.Text = "Tên sản phẩm";
            this.lb_tensp.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(1277, 707);
            this.splitContainer1.SplitterDistance = 760;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgv_thongtinsanpham);
            this.groupBox1.Controls.Add(this.btn_tim);
            this.groupBox1.Controls.Add(this.txt_timsanpham);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(760, 707);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // txt_timsanpham
            // 
            this.txt_timsanpham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_timsanpham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_timsanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txt_timsanpham.Location = new System.Drawing.Point(23, 94);
            this.txt_timsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.txt_timsanpham.Name = "txt_timsanpham";
            this.txt_timsanpham.Size = new System.Drawing.Size(98, 31);
            this.txt_timsanpham.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Controls.Add(this.ptb_anhminhhoa);
            this.groupBox4.Controls.Add(this.lb_tensp);
            this.groupBox4.Controls.Add(this.btn_datHang);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(512, 707);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi tiết sản phẩm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbTen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbtonkho, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lb_ten, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbgia, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_gia, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_hang, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbhang, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lnLoai, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_masp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_valuexp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_loai, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_tonkho, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 379);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 214);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // lbTen
            // 
            this.lbTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.ForeColor = System.Drawing.Color.Black;
            this.lbTen.Location = new System.Drawing.Point(4, 23);
            this.lbTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(133, 23);
            this.lbTen.TabIndex = 19;
            this.lbTen.Text = "Tên sản phẩm";
            this.lbTen.Visible = false;
            // 
            // lbtonkho
            // 
            this.lbtonkho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbtonkho.AutoSize = true;
            this.lbtonkho.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtonkho.ForeColor = System.Drawing.Color.Black;
            this.lbtonkho.Location = new System.Drawing.Point(4, 115);
            this.lbtonkho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtonkho.Name = "lbtonkho";
            this.lbtonkho.Size = new System.Drawing.Size(79, 23);
            this.lbtonkho.TabIndex = 16;
            this.lbtonkho.Text = "Tồn kho";
            this.lbtonkho.Visible = false;
            // 
            // lb_ten
            // 
            this.lb_ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_ten.AutoSize = true;
            this.lb_ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_ten.Location = new System.Drawing.Point(152, 23);
            this.lb_ten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ten.Name = "lb_ten";
            this.lb_ten.Size = new System.Drawing.Size(138, 23);
            this.lb_ten.TabIndex = 14;
            this.lb_ten.Text = "Tên sản phẩm";
            this.lb_ten.Visible = false;
            // 
            // lbgia
            // 
            this.lbgia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbgia.AutoSize = true;
            this.lbgia.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgia.ForeColor = System.Drawing.Color.Black;
            this.lbgia.Location = new System.Drawing.Point(4, 92);
            this.lbgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbgia.Name = "lbgia";
            this.lbgia.Size = new System.Drawing.Size(77, 23);
            this.lbgia.TabIndex = 12;
            this.lbgia.Text = "Giá bán";
            this.lbgia.Visible = false;
            // 
            // lb_gia
            // 
            this.lb_gia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_gia.AutoSize = true;
            this.lb_gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_gia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_gia.Location = new System.Drawing.Point(152, 92);
            this.lb_gia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_gia.Name = "lb_gia";
            this.lb_gia.Size = new System.Drawing.Size(80, 23);
            this.lb_gia.TabIndex = 11;
            this.lb_gia.Text = "Giá bán";
            this.lb_gia.Visible = false;
            // 
            // lb_hang
            // 
            this.lb_hang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_hang.AutoSize = true;
            this.lb_hang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hang.Location = new System.Drawing.Point(152, 69);
            this.lb_hang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_hang.Name = "lb_hang";
            this.lb_hang.Size = new System.Drawing.Size(138, 23);
            this.lb_hang.TabIndex = 10;
            this.lb_hang.Text = "Hãng sản xuất";
            this.lb_hang.Visible = false;
            // 
            // lbhang
            // 
            this.lbhang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbhang.AutoSize = true;
            this.lbhang.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhang.ForeColor = System.Drawing.Color.Black;
            this.lbhang.Location = new System.Drawing.Point(4, 69);
            this.lbhang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbhang.Name = "lbhang";
            this.lbhang.Size = new System.Drawing.Size(138, 23);
            this.lbhang.TabIndex = 9;
            this.lbhang.Text = "Hãng sản xuất";
            this.lbhang.Visible = false;
            // 
            // lnLoai
            // 
            this.lnLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnLoai.AutoSize = true;
            this.lnLoai.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnLoai.ForeColor = System.Drawing.Color.Black;
            this.lnLoai.Location = new System.Drawing.Point(4, 46);
            this.lnLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnLoai.Name = "lnLoai";
            this.lnLoai.Size = new System.Drawing.Size(140, 23);
            this.lnLoai.TabIndex = 8;
            this.lnLoai.Text = "Loại sản phẩm";
            this.lnLoai.Visible = false;
            // 
            // lb_masp
            // 
            this.lb_masp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_masp.AutoSize = true;
            this.lb_masp.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_masp.ForeColor = System.Drawing.Color.Black;
            this.lb_masp.Location = new System.Drawing.Point(4, 0);
            this.lb_masp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_masp.Name = "lb_masp";
            this.lb_masp.Size = new System.Drawing.Size(129, 23);
            this.lb_masp.TabIndex = 7;
            this.lb_masp.Text = "Mã sản phẩm";
            this.lb_masp.Visible = false;
            // 
            // lb_valuexp
            // 
            this.lb_valuexp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_valuexp.AutoSize = true;
            this.lb_valuexp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_valuexp.Location = new System.Drawing.Point(152, 0);
            this.lb_valuexp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_valuexp.Name = "lb_valuexp";
            this.lb_valuexp.Size = new System.Drawing.Size(131, 23);
            this.lb_valuexp.TabIndex = 6;
            this.lb_valuexp.Text = "Mã sản phẩm";
            this.lb_valuexp.Visible = false;
            // 
            // lb_loai
            // 
            this.lb_loai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_loai.AutoSize = true;
            this.lb_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_loai.Location = new System.Drawing.Point(152, 46);
            this.lb_loai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_loai.Name = "lb_loai";
            this.lb_loai.Size = new System.Drawing.Size(140, 23);
            this.lb_loai.TabIndex = 5;
            this.lb_loai.Text = "Loại sản phẩm";
            this.lb_loai.Visible = false;
            // 
            // lb_tonkho
            // 
            this.lb_tonkho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_tonkho.AutoSize = true;
            this.lb_tonkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_tonkho.Location = new System.Drawing.Point(152, 115);
            this.lb_tonkho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tonkho.Name = "lb_tonkho";
            this.lb_tonkho.Size = new System.Drawing.Size(84, 23);
            this.lb_tonkho.TabIndex = 4;
            this.lb_tonkho.Text = "Tồn kho";
            this.lb_tonkho.Visible = false;
            // 
            // ptb_anhminhhoa
            // 
            this.ptb_anhminhhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptb_anhminhhoa.Location = new System.Drawing.Point(4, 61);
            this.ptb_anhminhhoa.Margin = new System.Windows.Forms.Padding(4);
            this.ptb_anhminhhoa.Name = "ptb_anhminhhoa";
            this.ptb_anhminhhoa.Size = new System.Drawing.Size(504, 318);
            this.ptb_anhminhhoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_anhminhhoa.TabIndex = 15;
            this.ptb_anhminhhoa.TabStop = false;
            this.ptb_anhminhhoa.Visible = false;
            // 
            // btn_datHang
            // 
            this.btn_datHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_datHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_datHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_datHang.Location = new System.Drawing.Point(4, 593);
            this.btn_datHang.Margin = new System.Windows.Forms.Padding(4);
            this.btn_datHang.Name = "btn_datHang";
            this.btn_datHang.Size = new System.Drawing.Size(504, 110);
            this.btn_datHang.TabIndex = 2;
            this.btn_datHang.Text = "Đặt hàng";
            this.btn_datHang.UseVisualStyleBackColor = true;
            this.btn_datHang.Visible = false;
            this.btn_datHang.Click += new System.EventHandler(this.btn_datHang_Click);
            // 
            // DatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 707);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DatHang";
            this.Text = "DatHang";
            this.Load += new System.EventHandler(this.DatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtinsanpham)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_anhminhhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_thongtinsanpham;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lb_tensp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_timsanpham;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox ptb_anhminhhoa;
        private System.Windows.Forms.Button btn_datHang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbtonkho;
        private System.Windows.Forms.Label lb_ten;
        private System.Windows.Forms.Label lbgia;
        private System.Windows.Forms.Label lb_gia;
        private System.Windows.Forms.Label lb_hang;
        private System.Windows.Forms.Label lbhang;
        private System.Windows.Forms.Label lnLoai;
        private System.Windows.Forms.Label lb_masp;
        private System.Windows.Forms.Label lb_valuexp;
        private System.Windows.Forms.Label lb_loai;
        private System.Windows.Forms.Label lb_tonkho;
    }
}