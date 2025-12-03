using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOANCUOIKY.GiaoDien;

namespace DOANCUOIKY.GiaoDien
{
    public partial class QuanLyND : Form
    {
        public int ID { get; set; } // ID của người đăng nhập

        DBConnection db = new DBConnection();

        public QuanLyND(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                Load_DSNV();
                //Load_CbbTrangThai();
                Load_CbbChucVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Load danh sách nhân viên
        void Load_DSNV()
        {
            try
            {
                string sql = "SELECT IDNguoiDung, HoTen, Email, SoDienThoai, TrangThai, VaiTro, NgayTao FROM NguoiDung ORDER BY IDNguoiDung DESC";
                DataTable dt = db.getDataTable(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhân viên!");
                    return;
                }

                dgv_NguoiDung.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách: " + ex.Message);
            }
        }

        private bool KiemTraSDT()
        {
            string sdt = txt_sdt.Text.Trim();

            // Reset lỗi cũ
            errorProvider1.SetError(txt_sdt, "");

            // Kiểm tra độ dài 10
            if (sdt.Length != 10)
            {
                errorProvider1.SetError(txt_sdt, "Số điện thoại phải đủ 10 chữ số!");
                return false;
            }

            // Kiểm tra chỉ toàn số
            if (!sdt.All(char.IsDigit))
            {
                errorProvider1.SetError(txt_sdt, "Số điện thoại chỉ được chứa chữ số!");
                return false;
            }

            return true;
        }

        //Load Combobox Chức vụ
        void Load_CbbChucVu()
        {
            try
            {
                string sql = "SELECT DISTINCT VaiTro FROM NguoiDung";
                DataTable dt = db.getDataTable(sql);
                cbb_loaitk.DataSource = dt;
                cbb_loaitk.DisplayMember = "VaiTro";
                cbb_loaitk.ValueMember = "VaiTro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load loại tài khoản: " + ex.Message);
            }
        }

        //void Load_CbbTrangThai()
        //{
        //    cbb_trangthai.Items.Clear();
        //    cbb_trangthai.Items.Add("Hoạt động");
        //    cbb_trangthai.Items.Add("Không hoạt động");
        //    cbb_trangthai.SelectedIndex = true; 
        //}

        // Reset form
        private void Reset()
        {
            txt_idnd.Text = "";
            txt_tennd.Text = "";
            cbb_trangthai.Text = "";
            txt_sdt.Text = "";
            dtp_ngaylap.Value = DateTime.Now;
            txt_email.Text = "";
           cbb_loaitk.SelectedIndex = -1;
            errorProvider1.SetError(txt_sdt, "");
        }

        // Kiểm tra thông tin trước khi lưu
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(txt_tennd.Text))
            {
                MessageBox.Show("Vui lòng điền tên nhân viên.");
                txt_tennd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                MessageBox.Show("Vui lòng điền số điện thoại.");
                txt_sdt.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show("Vui lòng điền email.");
                txt_email.Focus();
                return false;
            }
            if (cbb_loaitk.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản.");
                return false;
            }

            if (!KiemTraSDT())
                return false;

            return true;
        }

      

        // Thêm nhân viên mới
        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraThongTin())
                    return;

                string sqlInsert = @"INSERT INTO NguoiDung (HoTen, NgayTao, TrangThai, SoDienThoai, VaiTro, Email) 
                                    VALUES (@HoTen, @NgayTao, @TrangThai, @SoDienThoai, @VaiTro, @Email)";

                db.Open();
                SqlCommand cmd = new SqlCommand(sqlInsert, db.conn);
                cmd.Parameters.AddWithValue("@HoTen", txt_tennd.Text);
                cmd.Parameters.AddWithValue("@NgayTao", dtp_ngaylap.Value);
                cmd.Parameters.AddWithValue("@TrangThai", cbb_trangthai.SelectedItem);
                cmd.Parameters.AddWithValue("@SoDienThoai", txt_sdt.Text);
                cmd.Parameters.AddWithValue("@VaiTro", cbb_loaitk.SelectedValue);
                cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                cmd.ExecuteNonQuery();
                db.Close();

                MessageBox.Show("Thêm người dùng thành công.");
                Load_DSNV();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        // Sửa nhân viên
        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_idnd.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để sửa.");
                    return;
                }

                if (!KiemTraThongTin())
                    return;

                string sqlUpdate = @"UPDATE NguoiDung SET 
                                    HoTen = @HoTen, 
                                    NgayTao = @NgayTao, 
                                    TrangThai = @TrangThai, 
                                    SoDienThoai = @SoDienThoai, 
                                    VaiTro = @VaiTro, 
                                    Email = @Email 
                                    WHERE IDNguoiDung = @IDNguoiDung";

                db.Open();
                SqlCommand cmd = new SqlCommand(sqlUpdate, db.conn);
                cmd.Parameters.AddWithValue("@HoTen", txt_tennd.Text);
                cmd.Parameters.AddWithValue("@NgayTao", dtp_ngaylap.Value);
                cmd.Parameters.AddWithValue("@TrangThai", cbb_trangthai.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txt_sdt.Text);
                cmd.Parameters.AddWithValue("@VaiTro", cbb_loaitk.SelectedValue);
                cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                cmd.Parameters.AddWithValue("@IDNguoiDung", txt_idnd.Text);
                cmd.ExecuteNonQuery();
                db.Close();

                MessageBox.Show("Cập nhật nhân viên thành công.");
                Load_DSNV();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        // Xóa nhân viên
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_idnd.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
                    return;
                }

                int maXoa = int.Parse(txt_idnd.Text);
                if (maXoa == ID)
                {
                    MessageBox.Show("Không thể xóa chính mình.");
                    return;
                }

                DialogResult r = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên có ID {maXoa}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    db.Open();

                    // Chuyển giao hóa đơn nếu NV đã lập HD
                    string sqlChuyenHD = "UPDATE DonHang SET IDNguoiDung = @IDMoi WHERE IDNguoiDung = @IDCu";
                    SqlCommand cmdChuyen = new SqlCommand(sqlChuyenHD, db.conn);
                    cmdChuyen.Parameters.AddWithValue("@IDMoi", ID);
                    cmdChuyen.Parameters.AddWithValue("@IDCu", maXoa);
                    cmdChuyen.ExecuteNonQuery();

                    // Xóa nhân viên
                    string sqlXoa = "DELETE FROM NguoiDung WHERE IDNguoiDung = @ID";
                    SqlCommand cmdXoa = new SqlCommand(sqlXoa, db.conn);
                    cmdXoa.Parameters.AddWithValue("@ID", maXoa);
                    cmdXoa.ExecuteNonQuery();

                    db.Close();

                    MessageBox.Show("Xóa nhân viên thành công.");
                    Load_DSNV();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

       

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                bool coThayDoi = false;

                foreach (DataGridViewRow row in dgv_NguoiDung.Rows)
                {
                    if (row.IsNewRow) continue;

                    string idNV = row.Cells["IDNguoiDung"].Value?.ToString();

                    if (string.IsNullOrEmpty(idNV))
                        continue;

                    string sqlUpdate = @"UPDATE NguoiDung SET 
                                        HoTen = N'" + row.Cells["HoTen"].Value?.ToString()?.Replace("'", "''") + @"',
                                        Email = N'" + row.Cells["Email"].Value?.ToString()?.Replace("'", "''") + @"',
                                        SoDienThoai = '" + row.Cells["SoDienThoai"].Value?.ToString() + @"',
                                        TrangThai = N'" + row.Cells["TrangThai"].Value?.ToString()?.Replace("'", "''") + @"',
                                        VaiTro = N'" + row.Cells["VaiTro"].Value?.ToString() + @"'
                                        WHERE IDNguoiDung = " + idNV;

                    try
                    {
                        db.getNonQuery(sqlUpdate);
                        coThayDoi = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu nhân viên {idNV}: {ex.Message}");
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //private void btn_dangky_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DangKy dk = new DangKy();
        //        dk.ShowDialog();
        //        Load_DSNV();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}

        private void cbb_loaitk_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi loại tài khoản
        }

        private void dgv_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgv_NguoiDung.Rows.Count)
                    return;

                DataGridViewRow row = dgv_NguoiDung.Rows[e.RowIndex];
                txt_idnd.Text = row.Cells["IDNguoiDung"].Value?.ToString() ?? "";
                txt_tennd.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                cbb_trangthai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
                txt_sdt.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txt_email.Text = row.Cells["Email"].Value?.ToString() ?? "";

                if (row.Cells["NgayTao"].Value != null)
                    dtp_ngaylap.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);

                if (row.Cells["VaiTro"].Value != null)
                    cbb_loaitk.SelectedValue = row.Cells["VaiTro"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_TimNV_Click(object sender, EventArgs e)
        {
            try
            {
                string key = txt_TimNV.Text.Trim();

                if (string.IsNullOrEmpty(key))
                {
                    Load_DSNV();
                    return;
                }

                string sql = "SELECT IDNguoiDung, HoTen, Email, SoDienThoai, TrangThai, VaiTro, NgayTao FROM NguoiDung WHERE HoTen LIKE N'%" + key + "%' ORDER BY IDNguoiDung DESC";
                DataTable dt = db.getDataTable(sql);
                dgv_NguoiDung.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void txt_TimNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            Load_DSNV();
        }


    }
}