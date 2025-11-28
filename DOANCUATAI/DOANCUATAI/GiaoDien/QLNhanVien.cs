using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using System.Data; // Ông bị lặp dòng này
using System.Data.SqlClient;
using DOANCUATAI.GiaoDien;
namespace DOANCUATAI.GiaoDien
{
    public partial class QLNhanVien : Form
    {
        public string MaNV { get; set; } // MaNV của người đăng nhập

        DBConnection db = new DBConnection();

        public QLNhanVien(string manv)
        {
            InitializeComponent();
            MaNV = manv;
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            Load_DSNV();
            Load_CbbChucVu();
        }

        // Load danh sách nhân viên
        void Load_DSNV()
        {
            string sql = "SELECT * FROM NhanVien";
            DataTable dt = db.getDataTable(sql);
            dgv_NhanVien.DataSource = dt;
        }

        // Load Combobox Chức vụ
        void Load_CbbChucVu()
        {
            string sql = "SELECT DISTINCT ChucVu FROM NhanVien";
            DataTable dt = db.getDataTable(sql);
            cbb_chucvu.DataSource = dt;
            cbb_chucvu.DisplayMember = "ChucVu";
            cbb_chucvu.ValueMember = "ChucVu";
        }

        // Reset form
        private void Reset()
        {
            txt_manv.Text = "";
            txt_tennv.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";
            rdo_nam.Checked = false;
            rdo_nu.Checked = false;
            dtp_ngaysinh.Value = DateTime.Now;
            txt_ghichu.Text = "";
            cbb_chucvu.SelectedIndex = -1;
        }

        // Kiểm tra thông tin trước khi lưu
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(txt_tennv.Text))
            {
                MessageBox.Show("Vui lòng điền tên nhân viên.");
                txt_tennv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_diachi.Text))
            {
                MessageBox.Show("Vui lòng điền địa chỉ.");
                txt_diachi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                MessageBox.Show("Vui lòng điền số điện thoại.");
                txt_sdt.Focus();
                return false;
            }
            if (!rdo_nam.Checked && !rdo_nu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                MessageBox.Show("Vui lòng điền mã nhân viên.");
                txt_manv.Focus();
                return false;
            }
            return true;
        }

        // Khi click 1 dòng trên DataGridView
        private void dgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_NhanVien.Rows.Count) return;

            DataGridViewRow row = dgv_NhanVien.Rows[e.RowIndex];
            txt_manv.Text = row.Cells["MaNhanVien"].Value.ToString();
            txt_tennv.Text = row.Cells["TenNhanVien"].Value.ToString();
            txt_diachi.Text = row.Cells["DiaChi"].Value.ToString();
            txt_sdt.Text = row.Cells["SDT"].Value.ToString();
            dtp_ngaysinh.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

            string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
            rdo_nam.Checked = gioiTinh == "Nam";
            rdo_nu.Checked = gioiTinh == "Nữ";

            cbb_chucvu.SelectedValue = row.Cells["ChucVu"].Value.ToString();
            txt_ghichu.Text =row.Cells["GhiChu"].Value.ToString();
        }

        // Thêm nhân viên mới
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin()) return;

            // Kiểm tra mã NV có tồn tại
            string ma = txt_manv.Text.Trim();
            string sqlCheck = $"SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien='{ma}'";
            int count = Convert.ToInt32(db.getScalar(sqlCheck));
            if (count > 0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.");
                return;
            }

            // Thêm vào database
            string gioiTinh = rdo_nam.Checked ? "Nam" : "Nữ";
            string sqlInsert = $"INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgayVaoLam, DiaChi, SDT, ChucVu,GhiChu) " +
                               $"VALUES('{ma}', N'{txt_tennv.Text}', N'{gioiTinh}', '{dtp_ngaysinh.Value:yyyy-MM-dd}', N'{txt_diachi.Text}', '{txt_sdt.Text}', N'{cbb_chucvu.SelectedValue}',N'{txt_ghichu.Text}')";
            db.getNonQuery(sqlInsert);

            MessageBox.Show("Thêm nhân viên thành công.");
            Load_DSNV();
            btn_luu.Visible = true;
            Reset();
        }

        // Sửa nhân viên
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin()) return;

            string gioiTinh = rdo_nam.Checked ? "Nam" : "Nữ";
            string sqlUpdate = $"UPDATE NhanVien SET TenNhanVien=N'{txt_tennv.Text}', GioiTinh=N'{gioiTinh}', " +
                               $"NgayVaoLam='{dtp_ngaysinh.Value:yyyy-MM-dd}', DiaChi=N'{txt_diachi.Text}', SDT='{txt_sdt.Text}', " +
                               $"ChucVu=N'{cbb_chucvu.SelectedValue}' , GhiChu=N'{txt_ghichu.Text}' " +
                               $"WHERE MaNhanVien='{txt_manv.Text}'";
            db.getNonQuery(sqlUpdate);

            MessageBox.Show("Cập nhật nhân viên thành công.");
            Load_DSNV();
            btn_luu.Visible = true;
        }

        // Xóa nhân viên
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
                return;
            }

            string maXoa = txt_manv.Text.Trim();
            if (maXoa == MaNV)
            {
                MessageBox.Show("Không thể xóa chính mình.");
                return;
            }

            DialogResult r = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maXoa}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                // Chuyển giao hóa đơn nếu NV đã lập HD
                string sqlChuyenHD = $"UPDATE HoaDon SET MaNhanVien='{MaNV}' WHERE MaNhanVien='{maXoa}'";
                db.getNonQuery(sqlChuyenHD);

                // Xóa Users
                string sqlXoaUser = $"DELETE FROM Users WHERE MaNhanVien='{maXoa}'";
                db.getNonQuery(sqlXoaUser);

                // Xóa NhanVien
                string sqlXoaNV = $"DELETE FROM NhanVien WHERE MaNhanVien='{maXoa}'";
                db.getNonQuery(sqlXoaNV);

                MessageBox.Show("Xóa nhân viên thành công.");
                Load_DSNV();
                btn_luu.Visible = true;
                Reset();
            }
        }

        // Tìm kiếm nhân viên
        private void txt_TimNV_TextChanged(object sender, EventArgs e)
        {
            string key = txt_TimNV.Text.Trim();
            string sql = $"SELECT * FROM NhanVien WHERE TenNhanVien LIKE N'%{key}%'";
            DataTable dt = db.getDataTable(sql);
            dgv_NhanVien.DataSource = dt;
        }


        private void btn_luu_Click(object sender, EventArgs e)
        {
            bool coThayDoi = false;
            foreach (DataGridViewRow row in dgv_NhanVien.Rows)
            {
                if (row.IsNewRow) continue;

                string maNV = row.Cells["MaNhanVien"].Value?.ToString();
                string tenNV = row.Cells["TenNhanVien"].Value?.ToString();
                string diaChi = row.Cells["DiaChi"].Value?.ToString();
                string sdt = row.Cells["SDT"].Value?.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                string chucVu = row.Cells["ChucVu"].Value?.ToString();
                string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                DateTime ngayVaoLam;

                if (!DateTime.TryParse(row.Cells["NgayVaoLam"].Value?.ToString(), out ngayVaoLam))
                    ngayVaoLam = DateTime.Now;

                // Kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt))
                    continue;

                // Cập nhật
                string sqlUpdate = $"UPDATE NhanVien SET " +
                                   $"TenNhanVien=N'{tenNV}', GioiTinh=N'{gioiTinh}', NgayVaoLam='{ngayVaoLam:yyyy-MM-dd}', " +
                                   $"DiaChi=N'{diaChi}', SDT='{sdt}', ChucVu=N'{chucVu}', GhiChu=N'{ghiChu}' " +
                                   $"WHERE MaNhanVien='{maNV}'";

                try
                {
                    db.getNonQuery(sqlUpdate);
                    coThayDoi = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu nhân viên {maNV}: {ex.Message}");
                }
            }

            if (coThayDoi)
            {
                MessageBox.Show("Đã lưu thay đổi thành công!");
                btn_luu.Visible = false;
                Load_DSNV();
                Reset();
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được lưu.");
            }
        }


        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
