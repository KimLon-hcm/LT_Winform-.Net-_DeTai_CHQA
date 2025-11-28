using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DOANCUATAI.GiaoDien
{
    public partial class SanPham : Form
    {
        DBConnection db = new DBConnection();

        public SanPham()
        {
            InitializeComponent();
        }

        // Sự kiện được kích hoạt khi form được tải lên
        private void DatHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
            AnChiTietSanPham();
        }

        // --- CÁC HÀM XỬ LÝ GIAO DIỆN ---

        // Ẩn và reset thông tin ở panel chi tiết bên phải
        void AnChiTietSanPham()
        {
            ptb_anhminhhoa.Image = null;
            lb_tensp.Text = "Tên sản phẩm"; // Tên control mới
            lb_masp.Text = "";
            lb_loai.Text = "";
            lb_hang.Text = "";
            lb_gia.Text = "";
            lb_tonkho.Text = "";
            btn_datHang.Visible = false; // Tên control mới
        }

        // --- HÀM TẢI DỮ LIỆU ---

        // Tải danh sách sản phẩm ban đầu
        void HienThiDanhSachSanPham()
        {
            try
            {
                string query = "SELECT MaSanPham, TenSanPham, GiaBan, TonKho, HangSanXuat, LoaiSanPham, HinhAnh, ChuThich FROM SanPham WHERE TonKho > 0 AND TrangThai = N'Đang bán'";
                LoadDataToGrid(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm chung để đổ dữ liệu từ câu truy vấn vào DataGridView
        private void LoadDataToGrid(string query)
        {
            DataTable dt = db.getDataTable(query);

            if (dt == null)
            {
                MessageBox.Show("Không thể kết nối đến CSDL. Vui lòng kiểm tra chuỗi kết nối.", "Lỗi Nghiêm Trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sử dụng tên control mới: dgv_thongtinsanpham
            dgv_thongtinsanpham.DataSource = dt;

            // Cấu hình hiển thị cho DataGridView
            dgv_thongtinsanpham.ReadOnly = true;
            dgv_thongtinsanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_thongtinsanpham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgv_thongtinsanpham.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgv_thongtinsanpham.Columns["TonKho"].HeaderText = "Tồn Kho";
            dgv_thongtinsanpham.Columns["HangSanXuat"].HeaderText = "Hãng";
            dgv_thongtinsanpham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgv_thongtinsanpham.Columns["MaSanPham"].Visible = false;
            dgv_thongtinsanpham.Columns["HinhAnh"].Visible = false;
            dgv_thongtinsanpham.Columns["ChuThich"].Visible = false;
            dgv_thongtinsanpham.Columns["LoaiSanPham"].Visible = false;
        }

        // --- CÁC SỰ KIỆN CLICK ---

        // Sự kiện khi click vào một dòng trong DataGridView
        private void dgv_thongtinsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào một dòng dữ liệu hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ dữ liệu của dòng đã click
                DataGridViewRow row = this.dgv_thongtinsanpham.Rows[e.RowIndex];

                // Gán dữ liệu vào các Label chi tiết
                lb_masp.Text = row.Cells["MaSanPham"].Value.ToString();
                lb_tensp.Text = row.Cells["TenSanPham"].Value.ToString();
                lb_loai.Text = row.Cells["LoaiSanPham"].Value.ToString();
                lb_hang.Text = row.Cells["HangSanXuat"].Value.ToString();
                lb_tonkho.Text = row.Cells["TonKho"].Value.ToString();

                // --- PHẦN ĐÃ SỬA LỖI ---
                try
                {
                    // Sử dụng Convert.ToDecimal để chuyển đổi an toàn hơn
                    decimal giaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value);
                    // Gán chuỗi đã định dạng vào thuộc tính .Text của Label
                    lb_gia.Text = giaBan.ToString("N0") + " VNĐ";
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi khi chuyển đổi giá, hiển thị thông báo
                    lb_gia.Text = "Lỗi giá";
                    MessageBox.Show("Không thể định dạng giá sản phẩm: " + ex.Message);
                }

                // Xử lý và hiển thị hình ảnh
                try
                {
                    string tenFileAnh = row.Cells["HinhAnh"].Value.ToString();
                    string duongDanDayDu = Path.Combine(Application.StartupPath, "Images", tenFileAnh);

                    if (File.Exists(duongDanDayDu))
                    {
                        ptb_anhminhhoa.Image = Image.FromFile(duongDanDayDu);
                    }
                    else
                    {
                        ptb_anhminhhoa.Image = null;
                    }
                }
                catch
                {
                    ptb_anhminhhoa.Image = null;
                }

                // Hiển thị nút đặt hàng
                btn_datHang.Visible = true;
            }
        }

        // Sự kiện cho nút Tìm
        private void btn_tim_Click(object sender, EventArgs e)
        {
            // Sử dụng tên control mới: txt_timsanpham
            string tuKhoa = txt_timsanpham.Text.Trim();
            string query = "SELECT * FROM SanPham WHERE TenSanPham COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" + tuKhoa + "%' AND TonKho > 0 AND TrangThai = N'Đang bán'";
            LoadDataToGrid(query);
        }

        // Sự kiện cho nút Tất cả
        private void btn_all_Click(object sender, EventArgs e)
        {
            HienThiDanhSachSanPham();
            txt_timsanpham.Clear();
        }

        // Sự kiện cho nút Đặt hàng
        private void btn_datHang_Click(object sender, EventArgs e)
        {
            if (dgv_thongtinsanpham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo");
                return;
            }
            string maSanPham = lb_masp.Text;
            MessageBox.Show("Chuẩn bị tạo hóa đơn cho sản phẩm có mã: " + maSanPham);
        }

    }
}