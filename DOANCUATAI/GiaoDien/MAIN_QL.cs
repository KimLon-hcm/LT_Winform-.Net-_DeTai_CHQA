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
// Thêm dòng này để truy cập vào Resources
using DOANCUOIKY.Properties;
using DOANCUOIKY.GiaoDien;

namespace DOANCUOIKY.GiaoDien
{
    public partial class MAIN_QL : Form
    {
        DBConnection db = new DBConnection();
        public int IDND { get; set; }
        private Form currentChildForm;

        // --- CÁC BIẾN DÀNH CHO SLIDESHOW ---
        private List<Image> backgroundImages = new List<Image>();
        private int currentImageIndex = 0;
        private Timer slideshowTimer = new Timer();

        public MAIN_QL(int idnd)
        {
            InitializeComponent();
            IDND = idnd;
            TenNV();
        }

        private void MAIN_QL_Load(object sender, EventArgs e)
        {
            if (checkQuyen(IDND))
            {
                btn_QLNV.Enabled = true;
            }
            panelFloating.Hide();

            // === BẮT ĐẦU THÊM CODE SLIDESHOW ===
            InitializeSlideshow();
            // === KẾT THÚC THÊM CODE SLIDESHOW ===
        }

        #region === SLIDESHOW LOGIC ===

        /// <summary>
        /// Hàm này khởi tạo tất cả mọi thứ cho slideshow.
        /// </summary>
        private void InitializeSlideshow()
        {
            try
            {
                // Nạp các ảnh từ Resources vào danh sách.
                // Đảm bảo tên trong code (ví dụ: Resources.nen1) khớp với tên ảnh trong Resources.
                backgroundImages.Add(Resources.h00); // THAY "nen1" BẰNG TÊN ẢNH CỦA BẠN
                backgroundImages.Add(Resources.h77); // THAY "nen2" BẰNG TÊN ẢNH CỦA BẠN
                backgroundImages.Add(Resources.h88); // THAY "nen3" BẰNG TÊN ẢNH CỦA BẠN
                backgroundImages.Add(Resources.h99); // THAY "nen4" BẰNG TÊN ẢNH CỦA BẠN
                // Thêm bao nhiêu ảnh tùy ý...
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp ảnh nền slideshow: " + ex.Message + "\n\nVui lòng kiểm tra lại tên ảnh trong code và trong Project -> Properties -> Resources.", "Lỗi Ảnh Nền");
            }

            // Cài đặt và Bật Timer chỉ khi có ảnh trong danh sách
            if (backgroundImages.Count > 0)
            {
                // Set ảnh đầu tiên làm nền cho panel
                panelShowDesktop.BackgroundImage = backgroundImages[0];
                panelShowDesktop.BackgroundImageLayout = ImageLayout.Stretch; // Căng ảnh cho vừa panel

                // Cài đặt Timer
                slideshowTimer.Interval = 3000; // 3000ms = 3 giây, bạn có thể thay đổi
                slideshowTimer.Tick += new EventHandler(slideshowTimer_Tick); // Gắn sự kiện Tick
                slideshowTimer.Start(); // Bắt đầu chạy
            }
        }

        /// <summary>
        /// Sự kiện Tick của Timer, tự động chạy sau mỗi khoảng thời gian đã định.
        /// </summary>
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

        #endregion

        #region === FORM NAVIGATION AND EVENTS ===

        private void OpenChildForm(Form childForm)
        {
            // Khi mở form con, dừng slideshow và xóa ảnh nền
            slideshowTimer.Stop();
            panelShowDesktop.BackgroundImage = null;

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
                currentChildForm = null;
            }
            // Khi đóng form con, khởi động lại slideshow
            InitializeSlideshow();
        }

        // --- CÁC SỰ KIỆN CLICK NÚT (Giữ nguyên code cũ của bạn) ---

        private void btn_QLNV_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_QLNV.Height;
            panelFloating.Top = btn_QLNV.Top;
            OpenChildForm(new QuanLyND(IDND));
            labelShowDesktop.Text = btn_QLNV.Text;
        }



        private void btn_QLSP_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = btn_QLSP.Height;
            panelFloating.Top = btn_QLSP.Top;
            OpenChildForm(new QLSP());
            labelShowDesktop.Text = btn_QLSP.Text;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            panelFloating.Show(); // Thêm dòng này để thanh trượt hiện ra
            panelFloating.Height = btnBill.Height;
            panelFloating.Top = btnBill.Top;
            OpenChildForm(new QLHoaDon());
            labelShowDesktop.Text = btnBill.Text;
        }


        private void QL_NPP_Click(object sender, EventArgs e)
        {
            panelFloating.Show();
            panelFloating.Height = QL_GiamGia.Height;
            panelFloating.Top = QL_GiamGia.Top;
            OpenChildForm(new GiamGia(IDND));
            labelShowDesktop.Text = QL_GiamGia.Text;
        }



        // --- CÁC HÀM KHÁC (Giữ nguyên code cũ của bạn) ---

        bool checkQuyen(int idnd)
        {
            // ... (code cũ)
            string chuoitruyvan = "SELECT IDNguoiDung FROM NguoiDung Where IDNguoiDung = '" + idnd + "' AND LoaiTK = N'Admin'";
            int kq = db.CheckData(chuoitruyvan);
            return kq > 0;
        }

        void TenNV()
        {
            // ... (code cũ)
            string sqltennv = "SELECT HoTen FROM NguoiDung WHERE IDNguoiDung = '" + IDND + "'";
            SqlDataReader reader = db.ExcuteQuery(sqltennv);
            if (reader.Read())
            {
                labelTenNV.Text = reader["HoTen"].ToString();
            }
            else
            {
                labelTenNV.Text = "Không tìm thấy";
            }
            db.Close(); // Đảm bảo đóng kết nối
        }

        private void MAIN_QL_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ... (code cũ)
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            // ... (code cũ)
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại sẽ kích hoạt sự kiện FormClosing
            }
        }

        #endregion
    }
}