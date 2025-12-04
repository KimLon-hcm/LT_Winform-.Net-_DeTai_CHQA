using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DOANCUOIKY;

namespace DOANCUOIKY.GiaoDien
{
    public partial class ThemSanPham : Form
    {
        DBConnection db = new DBConnection();
        private string tenFileAnhMoi = "";

        public ThemSanPham()
        {
            InitializeComponent();
        }



        void LoadLoaiHang()
        {
            try
            {
                string sql = "SELECT IDLoaiHang, TenLoaiHang FROM LoaiHang";
                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                db.Close();

                cbb_loai.DataSource = dt;
                cbb_loai.DisplayMember = "TenLoaiHang";
                cbb_loai.ValueMember = "IDLoaiHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại sản phẩm: " + ex.Message);
            }
        }

        void LoadThuongHieu()
        {
            try
            {
                string sql = "SELECT DISTINCT ThuongHieu FROM HangHoa WHERE ThuongHieu IS NOT NULL AND ThuongHieu <> ''";
                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                db.Close();

                cbb_thuonghieu.DataSource = dt;
                cbb_thuonghieu.DisplayMember = "ThuongHieu";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thương hiệu: " + ex.Message);
            }
        }

        void LoadTrangThai()
        {
            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("Đang bán");
            cbb_trangthai.Items.Add("Hết hàng");
            cbb_trangthai.SelectedIndex = 0;
        }

        bool KiemTraDuLieuNhap()
        {
            if (string.IsNullOrEmpty(txt_tenhang.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenhang.Focus();
                return false;
            }

            if (cbb_loai.SelectedIndex == -1)
            {
                MessageBox.Show("Loại sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_loai.Focus();
                return false;
            }

            if (cbb_thuonghieu.SelectedIndex == -1)
            {
                MessageBox.Show("Thương hiệu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_thuonghieu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_mau.Text))
            {
                MessageBox.Show("Màu sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mau.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_size.Text))
            {
                MessageBox.Show("Size sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_size.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_Gia.Text) || !decimal.TryParse(txt_Gia.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá bán phải là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Gia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_soluongton.Text) || !int.TryParse(txt_soluongton.Text, out int tonkho) || tonkho < 0)
            {
                MessageBox.Show("Tồn kho phải là số không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluongton.Focus();
                return false;
            }

            if (cbb_trangthai.SelectedIndex == -1)
            {
                MessageBox.Show("Trạng thái không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

       


        private void ThemSanPham_Load_1(object sender, EventArgs e)
        {
            try
            {
                LoadLoaiHang();
                LoadThuongHieu();
                LoadTrangThai();
                loadSizeComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_chonanh_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string duongDanFileGoc = openFile.FileName;
                tenFileAnhMoi = Path.GetFileName(duongDanFileGoc);
                string duongDanFileDich = Path.Combine(Application.StartupPath, "images", tenFileAnhMoi);
                try
                {
                    File.Copy(duongDanFileGoc, duongDanFileDich, true);
                    Anh.Image = Image.FromFile(duongDanFileDich);
                    btn_luu.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void LOADCBB_IDHANG()
        {
            try
            {
                string sql = "SELECT DISTINCT IDHang FROM HangHoa";
                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                db.Close();
                cbb_idhang.DataSource = dt;
                cbb_idhang.DisplayMember = "IDHang";
                cbb_idhang.ValueMember = "IDHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ID hàng: " + ex.Message);
            }
        }
        void loadSizeComboBox()
        {
            txt_size.Items.Clear();
            List<string> sizes = new List<string> { "XS", "S", "M", "L", "XL", "XXL" };
            txt_size.Items.AddRange(sizes.ToArray());
        }
        private void btn_thembienthe_Click(object sender, EventArgs e)
        {
            cbb_idhang.Enabled = true;
            LOADCBB_IDHANG();



        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuNhap())
                return;
            if (cbb_idhang.Enabled == false)
            {
                try
                {
                    db.Open();
                    SqlCommand cmd = new SqlCommand("", db.conn);
                    SqlTransaction transaction = db.conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // ===== INSERT VÀO BẢNG HangHoa =====
                        string query1 = @"
                INSERT INTO HangHoa(TenHang, MoTa, IDLoaiHang, ThuongHieu, TrangThai) 
                VALUES (@TenHang, @MoTa, @IDLoaiHang, @ThuongHieu, @TrangThai); 
                SELECT SCOPE_IDENTITY();";

                        cmd.CommandText = query1;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@TenHang", txt_tenhang.Text);
                        cmd.Parameters.AddWithValue("@MoTa", txt_mota.Text);
                        cmd.Parameters.AddWithValue("@IDLoaiHang", cbb_loai.SelectedValue);
                        cmd.Parameters.AddWithValue("@ThuongHieu", cbb_thuonghieu.Text);

                        // ===== FIX: Chuyển trạng thái từ chuỗi sang BIT =====
                        bool trangThai = cbb_trangthai.SelectedItem.ToString() == "Đang bán" ? true : false;
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                        object result = cmd.ExecuteScalar();
                        int idHang = Convert.ToInt32(result);

                        // ===== INSERT VÀO BẢNG HangHoa_BThe =====
                        string query2 = @"
                INSERT INTO HangHoa_BThe(IDHang, Mau, Size, HinhAnh, Gia, GiaKhuyenMai, SoLuongTon) 
                VALUES (@IDHang, @Mau, @Size, @HinhAnh, @Gia, @GiaKhuyenMai, @SoLuongTon)";

                        cmd.CommandText = query2;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDHang", idHang);
                        cmd.Parameters.AddWithValue("@Mau", txt_mau.Text);
                        cmd.Parameters.AddWithValue("@Size", txt_size.Text);
                        cmd.Parameters.AddWithValue("@HinhAnh", tenFileAnhMoi);
                        cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txt_Gia.Text));


                        decimal? giaKM = null;
                        if (!string.IsNullOrEmpty(txt_giakm.Text) && decimal.TryParse(txt_giakm.Text, out decimal gkm))
                            giaKM = gkm;
                        cmd.Parameters.AddWithValue("@GiaKhuyenMai", (object)giaKM ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(txt_soluongton.Text));

                        int kq = cmd.ExecuteNonQuery();

                        if (kq > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Thêm sản phẩm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        db.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                // THÊM BIẾN THỂ CHO SẢN PHẨM ĐÃ TỒN TẠI
                try
                {
                    // Kiểm tra đã chọn sản phẩm chưa
                    if (cbb_idhang.SelectedIndex <= 0 || cbb_idhang.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbb_idhang.Focus();
                        return;
                    }

                    int idHang = Convert.ToInt32(cbb_idhang.SelectedValue);

                    // Kiểm tra biến thể đã tồn tại chưa (cùng màu và size cho cùng sản phẩm)
                    try
                    {
                        db.Open();
                        SqlCommand cmd = new SqlCommand("", db.conn);

                        string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM HangHoa_BThe 
                    WHERE IDHang = @IDHang 
                    AND Mau = @Mau 
                    AND Size = @Size";

                        cmd.CommandText = checkQuery;
                        cmd.Connection = db.conn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDHang", idHang);
                        cmd.Parameters.AddWithValue("@Mau", txt_mau.Text);
                        cmd.Parameters.AddWithValue("@Size", txt_size.Text);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Biến thể với màu '" + txt_mau.Text + "' và size '" + txt_size.Text + "' đã tồn tại cho sản phẩm này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            db.Close();
                            return;
                        }

                        // Bắt đầu transaction
                        SqlTransaction transaction = db.conn.BeginTransaction();
                        cmd.Transaction = transaction;

                        try
                        {
                            // ===== INSERT VÀO BẢNG HangHoa_BThe =====
                            string insertQuery = @"
                        INSERT INTO HangHoa_BThe(IDHang, Mau, Size, HinhAnh, Gia, GiaKhuyenMai, SoLuongTon) 
                        VALUES (@IDHang, @Mau, @Size, @HinhAnh, @Gia, @GiaKhuyenMai, @SoLuongTon)";

                            cmd.CommandText = insertQuery;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@IDHang", idHang);
                            cmd.Parameters.AddWithValue("@Mau", txt_mau.Text);
                            cmd.Parameters.AddWithValue("@Size", txt_size.Text);
                            cmd.Parameters.AddWithValue("@HinhAnh", tenFileAnhMoi);
                            cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txt_Gia.Text));

                            decimal? giaKM = null;
                            if (!string.IsNullOrEmpty(txt_giakm.Text) && decimal.TryParse(txt_giakm.Text, out decimal gkm))
                                giaKM = gkm;
                            cmd.Parameters.AddWithValue("@GiaKhuyenMai", (object)giaKM ?? DBNull.Value);

                            cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(txt_soluongton.Text));

                            int kq = cmd.ExecuteNonQuery();

                            if (kq > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Thêm biến thể thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Thêm biến thể không thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi thêm biến thể: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            db.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kiểm tra biến thể: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}