using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DOANCUOIKY.GiaoDien;

namespace DOANCUOIKY.GiaoDien
{
    public partial class DangKyMoi : Form
    {
        DBConnection db = new DBConnection();

        public DangKyMoi()
        {
            InitializeComponent();
        }

        // Kiểm tra mật khẩu 6–24 kí tự, gồm chữ + số
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            txt_MK.UseSystemPasswordChar = true;
            txt_XNMK.UseSystemPasswordChar = true;
        }

 



        private void cbShowPass_CheckedChanged_1(object sender, EventArgs e)
        {
            txt_MK.UseSystemPasswordChar = !cbShowPass.Checked;
            txt_XNMK.UseSystemPasswordChar = !cbShowPass.Checked;
        }

        private void btn_DangKy_Click_1(object sender, EventArgs e)
        {
            try
            {
                string hoten = txt_hoten.Text.Trim();
                string email = txt_email.Text.Trim();
                string sdt = txt_sdt.Text.Trim();
         
                string mk = txt_MK.Text.Trim();
                string xnmk = txt_XNMK.Text.Trim();

                // Kiểm tra dữ liệu
                if (string.IsNullOrWhiteSpace(hoten))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_hoten.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email) ||
                    !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(mk))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MK.Focus();
                    return;
                }

                if (!checkAccount(mk))
                {
                    MessageBox.Show("Mật khẩu phải 6–24 ký tự (chữ và số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MK.Focus();
                    return;
                }

                if (mk != xnmk)
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_XNMK.Focus();
                    return;
                }

                // Kiểm tra email đã tồn tại chưa
                string sqlCheck = "SELECT COUNT(*) FROM NguoiDung WHERE Email = '" + email + "'";
                int exist = Convert.ToInt32(db.getScalar(sqlCheck));

                if (exist > 0)
                {
                    MessageBox.Show("Email này đã được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }
                // Thêm người dùng mới - Mặc định LoaiTK là 'Khách hàng'
                string sqlInsert = string.Format(@"
                    INSERT INTO NguoiDung (HoTen, Email, SoDienThoai, MatKhau, VaiTro, TrangThai, NgayTao)
                    VALUES (N'{0}', '{1}', '{2}', '{3}',  N'Staff',1, GETDATE())
                ", hoten, email, sdt, mk);

                int kq = db.getNonQuery(sqlInsert);

                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu trong form
                    txt_hoten.Clear();
                    txt_email.Clear();
                    txt_sdt.Clear();
                   
                    txt_MK.Clear();
                    txt_XNMK.Clear();

                    // Đóng form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}