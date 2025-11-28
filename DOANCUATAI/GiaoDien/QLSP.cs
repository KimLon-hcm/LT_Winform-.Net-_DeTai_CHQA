using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DOANCUOIKY.GiaoDien;

namespace DOANCUOIKY.GiaoDien
{
    public partial class QLSP : Form
    {
        DBConnection db = new DBConnection();
        private string tenFileAnhMoi = "";

        public QLSP()
        {
            InitializeComponent();
        }

        private void QLSP_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiDSSanPham();
                LoadComboBoxLoaiSanPham();
                LoadComboBoxHangSanXuat();
                LoadComboBoxTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu form. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region === CÁC HÀM TẢI DỮ LIỆU VÀ TIỆN ÍCH ===

        void HienThiDSSanPham()
        {
            string chuoitruyvan = @"
        SELECT 
            hh.IDHang,
            hh.TenHang,
            hh.MoTa,
            lh.TenLoaiHang,
            hh.ThuongHieu,
            CASE WHEN hh.TrangThai = 1 THEN 'Đang bán' ELSE 'Hết hàng' END AS TrangThai,
            hhbt.HinhAnh,
            hhbt.Gia,
            hhbt.SoLuongTon,
            hhbt.IDBienThe
        FROM HangHoa hh
        JOIN HangHoa_BThe hhbt ON hh.IDHang = hhbt.IDHang
        JOIN LoaiHang lh ON hh.IDLoaiHang = lh.IDLoaiHang";

            DataTable dt = db.getDataTable(chuoitruyvan);
            dgv_sanpham.DataSource = dt;
        }

        void LoadComboBoxLoaiSanPham()
        {
            string query = "SELECT TenLoaiHang FROM HangHoa hh,LoaiHang lh WHERE hh.IDLoaiHang=lh.IDLoaiHang";
            DataTable dt = db.getDataTable(query);
            cbb_loaisp.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbb_loaisp.Items.Add(row["TenLoaiHang"].ToString());
            }
        }

        void LoadComboBoxHangSanXuat()
        {
            string query = "SELECT DISTINCT ThuongHieu FROM HangHoa WHERE ThuongHieu IS NOT NULL AND ThuongHieu <> ''";
            DataTable dt = db.getDataTable(query);
            cbb_hangsx.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbb_hangsx.Items.Add(row["ThuongHieu"].ToString());
            }
        }

        void LoadComboBoxTrangThai()
        {
            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("Đang bán");
            cbb_trangthai.Items.Add("Hết hàng");
        }

        void ResetForm()
        {
            txt_idhang.Clear();
            txt_tensp.Clear();
            picture.Image = null;
            txt_gia.Clear();
            txt_tonkho.Clear();
            cbb_hangsx.SelectedIndex = -1;
            cbb_trangthai.SelectedIndex = 0;
            txt_chuthich.Clear();
            cbb_loaisp.SelectedIndex = -1;
            tenFileAnhMoi = "";
            txt_idhang.Enabled = true;
            txt_idhang.Focus();
        }

        bool KiemTraMaTonTai(string idhh)
        {
            string query = "SELECT hh.IDHang FROM HangHoa hh,HangHoa_BThe hhbt WHERE hh.IDHang=hhbt.IDHang And IDHang = @IDHang";
            db.Open();
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@IDHang", idhh);
            bool coTonTai = cmd.ExecuteReader().HasRows;
            db.Close();
            return coTonTai;
        }

        bool KiemTraDuLieuNhap()
        {
            if (string.IsNullOrEmpty(txt_idhang.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txt_tensp.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txt_gia.Text) || !decimal.TryParse(txt_gia.Text, out _))
            {
                MessageBox.Show("Giá bán phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txt_tonkho.Text) || !int.TryParse(txt_tonkho.Text, out _))
            {
                MessageBox.Show("Tồn kho phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbb_loaisp.SelectedIndex == -1)
            {
                MessageBox.Show("Loại sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbb_hangsx.SelectedIndex == -1)
            {
                MessageBox.Show("Hãng sản xuất không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbb_trangthai.SelectedIndex == -1)
            {
                MessageBox.Show("Trạng thái không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region === SỰ KIỆN CÁC NÚT BẤM ===

        private void btn_luu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nhấn nút 'Thêm' để thêm sản phẩm mới hoặc nút 'Xóa' để xóa sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_rs_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region === SỰ KIỆN KHÁC ===

        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_sanpham.Rows[e.RowIndex];
                txt_idhang.Text = row.Cells["IDHang"].Value?.ToString() ?? "";
                txt_tensp.Text = row.Cells["TenHang"].Value?.ToString() ?? "";
                txt_gia.Text = row.Cells["Gia"].Value?.ToString() ?? "";
                txt_tonkho.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? "";
                txt_chuthich.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                cbb_hangsx.Text = row.Cells["ThuongHieu"].Value?.ToString() ?? "";
                cbb_trangthai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
                cbb_loaisp.Text = row.Cells["TenLoaiHang"].Value?.ToString() ?? "";

                // ===== FIX: Hiển thị hình ảnh =====
                if (row.Cells["HinhAnh"].Value != null && row.Cells["HinhAnh"].Value != DBNull.Value)
                {
                    string folderAnh = Path.Combine(Application.StartupPath, "images");
                    string tenAnh = row.Cells["HinhAnh"].Value.ToString();
                    string duongDanAnh = Path.Combine(folderAnh, tenAnh);
                    try
                    {
                        if (File.Exists(duongDanAnh))
                        {
                            picture.Image = Image.FromFile(duongDanAnh);
                            picture.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            picture.Image = null;
                        }
                    }
                    catch
                    {
                        picture.Image = null;
                    }
                }
                else
                {
                    picture.Image = null;
                }
            }
        }

        

        private void picture_Click_1(object sender, EventArgs e)
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
                    picture.Image = Image.FromFile(duongDanFileDich);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idhang.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm '" + txt_tensp.Text + "' không?\n\nHành động này sẽ xóa tất cả các biến thể của sản phẩm!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.Open();
                    SqlCommand cmd = new SqlCommand("", db.conn);
                    SqlTransaction transaction = db.conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Xóa biến thể sản phẩm trước
                        string deleteBThe = "DELETE FROM HangHoa_BThe WHERE IDHang = @IDHang";
                        cmd.CommandText = deleteBThe;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDHang", txt_idhang.Text);
                        cmd.ExecuteNonQuery();

                        // Xóa hàng hóa
                        string deleteHH = "DELETE FROM HangHoa WHERE IDHang = @IDHang";
                        cmd.CommandText = deleteHH;
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDSSanPham();
                        LoadComboBoxLoaiSanPham();
                        LoadComboBoxHangSanXuat();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idhang.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy IDBienThe đầu tiên của sản phẩm này
                string query = "SELECT TOP 1 IDBienThe FROM HangHoa_BThe WHERE IDHang = @IDHang";
                db.Open();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@IDHang", int.Parse(txt_idhang.Text));

                object result = cmd.ExecuteScalar();
                db.Close();

                if (result != null)
                {
                    int idBienThe = Convert.ToInt32(result);
                    ChiTietSanPham chitietSP = new ChiTietSanPham(idBienThe);
                    this.Hide();
                    chitietSP.ShowDialog();
                    this.Show();
                    HienThiDSSanPham(); // Tải lại danh sách sau khi quay lại
                }
                else
                {
                    MessageBox.Show("Sản phẩm này không có biến thể nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            HienThiDSSanPham();
            ResetForm();
        }


        #endregion

        private void btn_them_Click(object sender, EventArgs e)
        {
            ThemSanPham themSP = new ThemSanPham();

            if (themSP.ShowDialog() == DialogResult.OK)
            {
                // Nếu thêm thành công, tải lại danh sách
                HienThiDSSanPham();
                LoadComboBoxLoaiSanPham();
                LoadComboBoxHangSanXuat();
                ResetForm();
            }
        }
    }
}