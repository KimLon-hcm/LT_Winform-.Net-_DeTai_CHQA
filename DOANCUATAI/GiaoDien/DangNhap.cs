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



        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            string mk = txt_MK.Text;
            string sdt = txt_email.Text;

            if ( string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu");
                return;
            }

            NguoiDung userObj = new NguoiDung();
  
            NguoiDung userResult = userObj.TimTaiKhoan(email);
            NguoiDung user =userObj.TimTaiKhoanSDT(sdt);

            if (userResult != null)
            {

                if (userResult.MatKhau == mk)
                {
                    string quyen = userResult.VaiTro;

                    int idnd = int.Parse(userResult.IDNguoiDung.ToString());


                    if (quyen == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Quản Trị (Admin)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (quyen == "Staff")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Quyền hạn không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MAIN_QL main = new MAIN_QL(idnd);
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (user != null)
            {

                if (user.MatKhau == mk)
                {

                    string quyen = user.VaiTro;
                    int idnd = int.Parse(user.IDNguoiDung.ToString());




                    if (quyen == "Admin")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Quản Trị (Admin)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (quyen == "Staff")
                    {
                        MessageBox.Show("Đăng nhập thành công quyền Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Quyền hạn không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MAIN_QL main = new MAIN_QL(idnd);
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
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