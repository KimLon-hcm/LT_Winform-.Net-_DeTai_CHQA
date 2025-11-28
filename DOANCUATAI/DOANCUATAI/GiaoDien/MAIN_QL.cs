using System;
using System.Collections.Generic; // Thêm
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;             // Thêm
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOANCUATAI.GiaoDien;

namespace DOANCUATAI.GiaoDien
{
    public partial class MAIN_QL : Form
    {
        DBConnection db = new DBConnection();

        public string MaNV { get; set; }
        private Form currentForm; // Biến lưu trữ form hiện tại trong panelShowDesktop

        // === BẮT ĐẦU THÊM CODE SLIDESHOW ===
        private List<Image> backgroundImages = new List<Image>();
        private int currentImageIndex = 0;
        private Timer slideshowTimer = new Timer();
        // === KẾT THÚC THÊM CODE SLIDESHOW ===

        bool checkQuyen(string manv)
        {
            string chuoitruyvan = "SELECT MaNhanVien FROM NhanVien Where MaNhanVien = '" + manv + "' AND MaNhanVien= (SELECT MaNhanVien FROM NhanVien Where ChucVu = N'Quản Lý')";
            int kq = db.CheckData(chuoitruyvan);
            if (kq > 0)
            {
                return true;
            }

            return false;
        }
        public MAIN_QL(string manv)
        {

            InitializeComponent();
            MaNV = manv;
            TenNV();
        }

        private void btn_QLTour_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_LSBH.Height;
            panelFloating.Top = btn_LSBH.Top;
            OpenChildForm(new QLLichSuBaoHanh(MaNV));
            labelShowDesktop.Text = btn_LSBH.Text;
        }

        private void btn_QLNV_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_QLNV.Height;
            panelFloating.Top = btn_QLNV.Top;
            OpenChildForm(new QLNhanVien(MaNV));
            labelShowDesktop.Text = btn_QLNV.Text;
        }

        private void btn_QLKH_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_QLKH.Height;
            panelFloating.Top = btn_QLKH.Top;
            OpenChildForm(new QLKhachHang(MaNV));
            labelShowDesktop.Text = btn_QLKH.Text;
        }
        private void btn_QLSP_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_QLSP.Height;
            panelFloating.Top = btn_QLSP.Top;
            OpenChildForm(new QLSP());
            labelShowDesktop.Text = btn_QLSP.Text;
        }

      
        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelShowDesktop.Controls.Add(childForm);
            panelShowDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelFloating.Hide();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            // Khi đóng form con, ảnh nền (đang chạy) sẽ tự hiện ra
        }


        private void MAIN_QL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                DangNhap dn = new DangNhap();
                this.Hide();
                dn.ShowDialog();
            }
        }

        private void MAIN_QL_Load(object sender, EventArgs e)
        {
            if (checkQuyen(MaNV))
            {
                btn_QLNV.Enabled = true;
                
            }
           panelFloating.Hide();

            // === BẮT ĐẦU THÊM CODE SLIDESHOW ===
            //try
            //{
            //    // Nạp 5 ảnh từ Resources (Đảm bảo tên khớp)
               
                
               
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi nạp ảnh nền slideshow: " + ex.Message + "\n\nÔng đã làm Bước 1 (Thêm ảnh vào Resources) chưa?", "Lỗi Ảnh Nền");
            //}

            // Cài đặt và Bật Timer
            if (backgroundImages.Count > 0)
            {
                // Set ảnh đầu tiên
                panelShowDesktop.BackgroundImage = backgroundImages[0];
                
                // Cài đặt Timer
                slideshowTimer.Interval = 5000; // 5000ms = 5 giây
                slideshowTimer.Tick += new EventHandler(slideshowTimer_Tick); // Gắn sự kiện Tick
                slideshowTimer.Start(); // Bắt đầu chạy
            }
            // === KẾT THÚC THÊM CODE SLIDESHOW ===
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            panelFloating.Height = btnBill.Height;
            panelFloating.Top = btnBill.Top;
            OpenChildForm(new QLHoaDon());
            labelShowDesktop.Text = btnBill.Text;
        }
        void TenNV()
        {
            string sqltennv = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = '" + MaNV + "'";
            SqlDataReader reader = db.ExcuteQuery(sqltennv);
            if (reader.Read())
            {
                string tennv = reader["TenNhanVien"].ToString();
                labelTenNV.Text = tennv;
                db.Close();
            }
            else
            {
                labelTenNV.Text = "Không tìm thấy thông tin";
                db.Close();
            }
        }

        // === BẮT ĐẦU THÊM CODE SLIDESHOW ===
        // Sự kiện Tick của Timer (tự động chạy mỗi 5 giây)
        private void slideshowTimer_Tick(object sender, EventArgs e)
        {
            // Tăng chỉ số ảnh
            currentImageIndex++;

            // Nếu đi hết danh sách thì quay lại ảnh đầu tiên
            if (currentImageIndex >= backgroundImages.Count)
            {
                currentImageIndex = 0;
            }

            // Đặt ảnh nền mới cho panel
            if (backgroundImages.Count > 0)
            {
                panelShowDesktop.BackgroundImage = backgroundImages[currentImageIndex];
            }
        }

        private void btn_DatHang_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_DatHang.Height;
            panelFloating.Top = btn_DatHang.Top;

            // SỬA LẠI DÒNG NÀY: KHÔNG TRUYỀN THAM SỐ NỮA
            OpenChildForm(new DatHang());

            labelShowDesktop.Text = btn_DatHang.Text;
        }
        // === KẾT THÚC THÊM CODE SLIDESHOW ===
    }
}