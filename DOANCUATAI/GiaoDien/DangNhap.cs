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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        // Đã xóa hàm checkChucVu() vì không cần thiết nữa

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            string mk = txt_MK.Text;

            if ( string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu");
                return;
            }

            NguoiDung userObj = new NguoiDung();
            // Gọi hàm tìm tài khoản 1 lần duy nhất
            NguoiDung userResult = userObj.TimTaiKhoan(email);

            if (userResult != null)
            {
                // Kiểm tra mật khẩu (Lưu ý: CSDL đang lưu pass thường, thực tế nên mã hóa)
                if (userResult.MatKhau == mk)
                {
                    string quyen = userResult.LoaiTK;
                    int idnd = int.Parse(userResult.IDNguoiDung.ToString());

                    // Xử lý phân quyền dựa trên dữ liệu CSDL (ADMIN, SALE, KHO)
                    if (quyen == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Quản Trị (ADMIN)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    else if (quyen == "Customer")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Quyền hạn không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Mở Form Main và truyền Mã nhân viên vào
                    // Giả sử Form MAIN_QL của bạn có constructor nhận vào (string manv, string quyen) thì càng tốt
                    MAIN_QL main = new MAIN_QL(idnd);
                    this.Hide();
                    main.ShowDialog();
                    this.Show(); // Hiện lại form đăng nhập khi form Main đóng
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    this.Hide();
        //    DangKy dk = new DangKy();
        //    dk.ShowDialog();
        //    this.Show();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ hỏi thoát khi người dùng bấm nút X hoặc Alt+F4, không hỏi khi chuyển form
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    e.Cancel = true;
                else
                    Application.Exit();
            }
        }

        private void pictureBoxShowPass_Click(object sender, EventArgs e)
        {
            txt_MK.UseSystemPasswordChar = false;
            pictureBoxShowPass.Hide();
            pictureBoxHidePass.Show();
        }

        private void pictureBoxHidePass_Click(object sender, EventArgs e)
        {
            txt_MK.UseSystemPasswordChar = true;
            pictureBoxHidePass.Hide();
            pictureBoxShowPass.Show();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txt_MK.UseSystemPasswordChar = true;
            pictureBoxHidePass.Hide();
        }

        private void btn_dki_Click(object sender, EventArgs e)
        {
     
                DangKyMoi dk = new DangKyMoi();
                dk.ShowDialog();
                

        }
    }
}