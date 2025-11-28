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
    public partial class ChiTietSanPham : Form
    {
        DBConnection db = new DBConnection();
        int IDHang { get; set; }
        int IDBienThe { get; set; }
        bool isEditing = false;
        string currentImagePath = "";

        public ChiTietSanPham(int idBienThe)
        {
            InitializeComponent();
            IDBienThe = idBienThe;
        }

        void LoadBienTheComboBox(int idHang, int idBienTheCurrent)
        {
            try
            {
                isEditing = true;  // Ngăn SelectedIndexChanged chạy

                string sql = @"
        SELECT IDBienThe, (Mau + ' - ' + Size) AS TenBienThe
        FROM HangHoa_BThe
        WHERE IDHang = @IDHang
        ORDER BY Mau, Size";

                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@IDHang", idHang);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                db.Close();

                cbb_Bienthe.DataSource = dt;
                cbb_Bienthe.DisplayMember = "TenBienThe";
                cbb_Bienthe.ValueMember = "IDBienThe";

                cbb_Bienthe.SelectedValue = idBienTheCurrent;
            }
            finally
            {
                isEditing = false; // Cho SelectedIndexChanged chạy lại
            }
        }

       
        void LoadChiTietSanPham(int idBienThe)
        {
            try
            {
                string sql = @"
            SELECT 
                bt.IDBienThe,
                bt.IDHang,
                hh.TenHang,
                hh.MoTa,
                lh.TenLoaiHang,
                lh.IDLoaiHang,
                hh.ThuongHieu,
                bt.Mau,
                bt.Size,
                bt.HinhAnh,
                bt.Gia,
                bt.GiaKhuyenMai,
                bt.SoLuongTon
            FROM HangHoa_BThe bt
            JOIN HangHoa hh ON bt.IDHang = hh.IDHang
            JOIN LoaiHang lh ON hh.IDLoaiHang = lh.IDLoaiHang
            WHERE bt.IDBienThe = @IDBienThe";

                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@IDBienThe", idBienThe);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // ===== LƯU TẤT CẢ DỮ LIỆU VÀO BIẾN =====
                    int idHang = Convert.ToInt32(reader["IDHang"]);
                    int idBienTheCurrent = Convert.ToInt32(reader["IDBienThe"]);
                    int idLoaiHang = Convert.ToInt32(reader["IDLoaiHang"]);
                    string tenHang = reader["TenHang"].ToString();
                    string moTa = reader["MoTa"].ToString();
                    string mau = reader["Mau"].ToString();
                    string size = reader["Size"].ToString();
                    string gia = reader["Gia"].ToString();
                    string giaKhuyenMai = reader["GiaKhuyenMai"] != DBNull.Value ? reader["GiaKhuyenMai"].ToString() : "";
                    string soLuongTon = reader["SoLuongTon"].ToString();
                    string hinhAnh = reader["HinhAnh"].ToString();
                    string thuongHieu = reader["ThuongHieu"].ToString();

                    // ===== ĐÓNG READER NGAY =====
                    reader.Close();
                    db.Close();

                    // ===== GÁN DỮ LIỆU VÀO CONTROLS SAU KHI ĐÓNG CONNECTION =====
                    IDHang = idHang;
                    IDBienThe = idBienTheCurrent;

                    txt_idhang.Text = idHang.ToString();
                    txt_tenhang.Text = tenHang;
                    txt_mota.Text = moTa;
                    txt_mau.Text = mau;
                    txt_size.Text = size;
                    txt_Gia.Text = gia;
                    txt_giakm.Text = giaKhuyenMai;
                    txt_soluongton.Text = soLuongTon;

                    // Load hình ảnh
                    currentImagePath = hinhAnh;
                    LoadImage(currentImagePath);

                    // Gán ComboBox
                    if (cbb_loai.DataSource != null)
                    {
                        cbb_loai.SelectedValue = idLoaiHang;
                    }

                    if (cbb_thuonghieu.DataSource != null)
                    {
                        cbb_thuonghieu.SelectedItem = thuongHieu;
                    }

                    // Load ComboBox biến thể - DÙNG SqlDataAdapter (không dùng DataReader)
                    LoadBienTheComboBox(idHang, idBienTheCurrent);
                }
                else
                {
                    reader.Close();
                    db.Close();
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (db.conn.State == ConnectionState.Open)
                    db.Close();
                MessageBox.Show("Lỗi khi tải chi tiết sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Lỗi khi tải loại hàng: " + ex.Message);
            }
        }

        void LoadThuongHieu()
        {
            try
            {
                string sql = "SELECT DISTINCT ThuongHieu FROM HangHoa";
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

        void LoadImage(string imageName)
        {
            try
            {
                // Ghép thư mục Images (tùy chỉnh theo cấu trúc project của bạn)
                string fullPath = Path.Combine(Application.StartupPath, "Images", imageName);

                if (!string.IsNullOrEmpty(imageName) && File.Exists(fullPath))
                {
                    Anh.Image = Image.FromFile(fullPath);
                    Anh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    Anh.Image = null;
                    Anh.Text = "Chưa có hình ảnh";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
            }
        }

        void EnableEditMode(bool enable)
        {
            isEditing = enable;
            txt_tenhang.ReadOnly = !enable;
            txt_mota.ReadOnly = !enable;
            cbb_loai.Enabled = enable;
            cbb_thuonghieu.Enabled = enable;
            txt_mau.ReadOnly = !enable;
            
            txt_Gia.ReadOnly = !enable;
            txt_giakm.ReadOnly = !enable;
            txt_soluongton.ReadOnly = !enable;

            btn_chonanh.Enabled = enable;
            btn_Sua.Visible = !enable;
            btn_Xoa.Visible = !enable;
            btn_luu.Visible = enable;
            //btn_Huy.Visible = enable;
            cbb_Bienthe.Enabled = !enable;
        }

        void SaveChanges()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_tenhang.Text))
                {
                    MessageBox.Show("Tên hàng không được để trống!");
                    return;
                }

                if (!decimal.TryParse(txt_Gia.Text, out decimal gia))
                {
                    MessageBox.Show("Giá không hợp lệ!");
                    return;
                }

                decimal? giaKhuyenMai = null;
                if (!string.IsNullOrWhiteSpace(txt_giakm.Text))
                {
                    if (decimal.TryParse(txt_giakm.Text, out decimal gkm))
                        giaKhuyenMai = gkm;
                    else
                    {
                        MessageBox.Show("Giá khuyến mại không hợp lệ!");
                        return;
                    }
                }

                if (!int.TryParse(txt_soluongton.Text, out int soLuong))
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!");
                    return;
                }

                db.Open();

                // Cập nhật HangHoa
                string sqlHangHoa = @"
            UPDATE HangHoa 
            SET TenHang = @TenHang, 
                MoTa = @MoTa, 
                ThuongHieu = @ThuongHieu,
                IDLoaiHang = @IDLoaiHang
            WHERE IDHang = @IDHang";

                SqlCommand cmdHangHoa = new SqlCommand(sqlHangHoa, db.conn);
                cmdHangHoa.Parameters.AddWithValue("@TenHang", txt_tenhang.Text);
                cmdHangHoa.Parameters.AddWithValue("@MoTa", txt_mota.Text);
                cmdHangHoa.Parameters.AddWithValue("@ThuongHieu", cbb_thuonghieu.Text);
                cmdHangHoa.Parameters.AddWithValue("@IDLoaiHang", cbb_loai.SelectedValue ?? 0);
                cmdHangHoa.Parameters.AddWithValue("@IDHang", IDHang);
                cmdHangHoa.ExecuteNonQuery();

                // Cập nhật HangHoa_BThe
                string sqlBThe = @"
            UPDATE HangHoa_BThe 
            SET Mau = @Mau, 
                Size = @Size, 
                Gia = @Gia, 
                GiaKhuyenMai = @GiaKhuyenMai, 
                SoLuongTon = @SoLuongTon,
                HinhAnh = @HinhAnh
            WHERE IDBienThe = @IDBienThe";

                SqlCommand cmdBThe = new SqlCommand(sqlBThe, db.conn);
                cmdBThe.Parameters.AddWithValue("@Mau", txt_mau.Text);
                cmdBThe.Parameters.AddWithValue("@Size", txt_size.Text);
                cmdBThe.Parameters.AddWithValue("@Gia", gia);
                cmdBThe.Parameters.AddWithValue("@GiaKhuyenMai", (object)giaKhuyenMai ?? DBNull.Value);
                cmdBThe.Parameters.AddWithValue("@SoLuongTon", soLuong);
                cmdBThe.Parameters.AddWithValue("@HinhAnh", Path.GetFileName(currentImagePath));
                cmdBThe.Parameters.AddWithValue("@IDBienThe", IDBienThe);
                cmdBThe.ExecuteNonQuery();

                db.Close();

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableEditMode(false);
                LoadChiTietSanPham(IDBienThe);
            }
            catch (Exception ex)
            {
                if (db.conn.State == ConnectionState.Open)
                    db.Close();
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DeleteBienThe()
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa biến thể này? Hành động này không thể hoàn tác!",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    db.Open();

                    string sql = "DELETE FROM HangHoa_BThe WHERE IDBienThe = @IDBienThe";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    cmd.Parameters.AddWithValue("@IDBienThe", IDBienThe);
                    cmd.ExecuteNonQuery();

                    db.Close();

                    MessageBox.Show("Xóa biến thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (db.conn.State == ConnectionState.Open)
                    db.Close();
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_huy_Click(object sender, EventArgs e)
        {
            EnableEditMode(false);
            LoadChiTietSanPham(IDBienThe);
        }




        private void ChiTietSanPham_Load_1(object sender, EventArgs e)
        {
            LoadLoaiHang();
            LoadThuongHieu();
          
            // Load thông tin sản phẩm
            LoadChiTietSanPham(IDBienThe);

            // Chế độ xem (không chỉnh sửa)
            EnableEditMode(false);
        }

        private void btn_chonanh_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    LoadImage(currentImagePath);
                }
            }
        }

        private void btn_Thoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Sua_Click_1(object sender, EventArgs e)
        {
            EnableEditMode(true);
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            DeleteBienThe();
        }

        private void cbb_Bienthe_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (isEditing) return;

            if (cbb_Bienthe.SelectedValue == null) return;

            // Nếu Value là DataRowView → bỏ qua (đang loading datasource)
            if (cbb_Bienthe.SelectedValue is DataRowView)
                return;

            string rawValue = cbb_Bienthe.SelectedValue.ToString();
           
            if (!int.TryParse(rawValue, out int idBienTheChon))
                return;

            if (idBienTheChon != IDBienThe)
            {
                IDBienThe = idBienTheChon;
                LoadChiTietSanPham(IDBienThe);
            }
        }

        private void txt_size_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
   }
