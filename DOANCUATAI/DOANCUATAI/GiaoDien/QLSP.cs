using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DOANCUATAI.GiaoDien;

namespace DOANCUATAI.GiaoDien
{
    public partial class QLSP : Form
    {
        DBConnection db = new DBConnection();

        public QLSP()
        {
            InitializeComponent();
        }

        // Reset tất cả textbox
        void Reset()
        {
            txt_masp.Clear();
            txt_tensp.Clear();
            txt_hinhanh.Clear();
            txt_gia.Clear();
            txt_tonkho.Clear();
            cbb_hangsx.Text = "";
            cbb_trangthai.Text = "";
            txt_chuthich.Clear();

            cbb_loaisp.Text = "";
        }

        // Hiển thị danh sách sản phẩm
        void HienThiDSSanPham()
        {
           
                string chuoitruyvan = "SELECT * FROM SanPham";
                DataTable dt = db.getDataTable(chuoitruyvan);
                dgv_sanpham.DataSource = dt;
            
        }
        private void QLSP_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiDSSanPham();
            }
            catch (Exception ex)
            {
                // Đây là bước quan trọng nhất: Hiển thị lỗi ra màn hình
                MessageBox.Show("Không thể tải danh sách sản phẩm. Lỗi: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Kiểm tra mã sản phẩm đã tồn tại chưa
        bool CheckMa(string MaSP)
        {
            // Sử dụng @MaSP làm tham số
            string query = "SELECT MaSanPham FROM SanPham WHERE MaSanPham = @MaSP";

            // Mở kết nối
            db.Open();
            SqlCommand cmd = new SqlCommand(query, db.conn);

            // Thêm tham số và giá trị của nó
            cmd.Parameters.AddWithValue("@MaSP", MaSP);

            // Thực thi
            SqlDataReader dta = cmd.ExecuteReader();
            bool coTonTai = dta.HasRows; // Kiểm tra xem có dòng nào không

            // Đóng
            dta.Close();
            db.Close();

            return coTonTai;
            // db.CheckData của bạn cũng cần được viết lại để hỗ trợ tham số
        }

        // Kiểm tra sản phẩm đang tồn tại trong đơn hàng hay không
        bool CheckSanPhamHoatDong()
        {
            string maSP = txt_masp.Text; // lấy mã sản phẩm từ textbox
            string query = "SELECT MaSanPham FROM HOADON WHERE MaSanPham = '" + maSP + "'";

            db.Open();
            SqlCommand cmd = new SqlCommand(query, db.conn);

            SqlDataReader dta = cmd.ExecuteReader();
            bool coTonTai = dta.HasRows;

            dta.Close();
            db.Close();

            return coTonTai;
        }

  

        private string Lay3KiTuCuoiTuCSDL()
        {
           
            string sql = "SELECT TOP 1 RIGHT(MaSanPham, 3) FROM SanPham ORDER BY MaSanPham DESC";
            object result = db.getScalar(sql); 
            return result != null ? result.ToString() : string.Empty;
        }


        // Click trên DataGridView để hiển thị thông tin lên textbox
        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_sanpham.Rows[e.RowIndex];

                txt_masp.Text = row.Cells["MaSanPham"].Value.ToString();
                txt_tensp.Text = row.Cells["TenSanPham"].Value.ToString();
                txt_hinhanh.Text = row.Cells["HinhAnh"].Value.ToString();
                cbb_loaisp.Text = row.Cells["LoaiSanPham"].Value.ToString();
                txt_gia.Text = row.Cells["GiaBan"].Value.ToString();
                txt_tonkho.Text = row.Cells["TonKho"].Value.ToString();
                cbb_hangsx.Text = row.Cells["HangSanXuat"].Value.ToString();
                txt_chuthich.Text = row.Cells["ChuThich"].Value.ToString();
                cbb_trangthai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgv_sanpham.DataSource;
                int kq = db.updateDataTable(dt, "SELECT * FROM SanPham");

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_luu.Visible = false;
                    //btn_them.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgv_sanpham.DataSource;
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MaSanPham"] };
                DataRow dr = dt.Rows.Find(txt_masp.Text);

                if (dr != null)
                {
                    dr["TenSanPham"] = txt_tensp.Text;
                    dr["LoaiSanPham"] = cbb_loaisp.Text;
                    dr["GiaBan"] = decimal.TryParse(txt_gia.Text, out decimal gia) ? gia : 0;
                    dr["TonKho"] = int.TryParse(txt_tonkho.Text, out int ton) ? ton : 0;
                    dr["HinhAnh"] = txt_hinhanh.Text;
                    dr["HangSanXuat"] = cbb_hangsx.Text;
                    dr["TrangThai"] = cbb_trangthai.Text;
                    dr["ChuThich"] = txt_chuthich.Text;
                    dgv_sanpham.Refresh();
                    btn_luu.Visible = true;
                    btn_luu.Enabled = true;
                    //btn_them.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (CheckSanPhamHoatDong())
            {
                MessageBox.Show("Sản phẩm đang có đơn hàng. Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = (DataTable)dgv_sanpham.DataSource;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaSanPham"] };
            DataRow dr = dt.Rows.Find(txt_masp.Text);

            if (dr != null)
            {
                dr.Delete();
                int kq = db.updateDataTable(dt, "SELECT * FROM SanPham");
                if (kq > 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckMa(txt_masp.Text))
                {
                    MessageBox.Show("Mã sản phẩm này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = (DataTable)dgv_sanpham.DataSource;
                DataRow dr = dt.NewRow();

                dr["MaSanPham"] = txt_masp.Text;
                dr["TenSanPham"] = txt_tensp.Text;
                dr["LoaiSanPham"] = cbb_loaisp.Text;

                dr["GiaBan"] = decimal.TryParse(txt_gia.Text, out decimal gia) ? gia : 0;
                dr["TonKho"] = int.TryParse(txt_tonkho.Text, out int ton) ? ton : 0;
                dr["HinhAnh"] = txt_hinhanh.Text;
                dr["HangSanXuat"] = cbb_hangsx.Text;
                dr["TrangThai"] = cbb_trangthai.Text;
                dr["ChuThich"] = txt_chuthich.Text;

                dt.Rows.Add(dr);
                dgv_sanpham.Refresh();

                btn_luu.Visible = true;
                btn_luu.Enabled = true;

                MessageBox.Show("Đã thêm sản phẩm mới. Nhấn Lưu để cập nhật CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
