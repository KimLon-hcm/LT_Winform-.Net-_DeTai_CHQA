using System;
using System.Data;
using System.Windows.Forms;
// Thêm thư viện này để có thể sử dụng SqlCommand cho các chức năng nâng cao
using System.Data.SqlClient;
using DOANCUOIKY.GiaoDien;
using System.Data.Common;
using DOANCUOIKY;

namespace DOANCUOIKY.GiaoDien
{
    public partial class QLHoaDon : Form
    {
        DBConnection db = new DBConnection();

        public QLHoaDon()
        {
            InitializeComponent();
        }

        // Sự kiện Form_Load, được chạy một lần ngay khi form được mở lên
        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            // Gọi hàm để tải và hiển thị danh sách hóa đơn
            HienThiDSHD();
        }
        void HienThiDSHD()
        {
            try
            {

                string chuoitruyvan = "SELECT * FROM DonHang";

                // Sử dụng lớp DBConnection để thực thi truy vấn và lấy về một DataTable
                DataTable dt = db.getDataTable(chuoitruyvan);

                // Gán DataTable này làm nguồn dữ liệu (DataSource) cho DataGridView
                dtg_HD.DataSource = dt;

                // (Tùy chọn) Cấu hình thêm cho DataGridView để giao diện đẹp và thân thiện hơn
                dtg_HD.ReadOnly = true; // Không cho người dùng sửa trực tiếp trên lưới
                dtg_HD.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Khi click sẽ chọn cả dòng
                dtg_HD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động co giãn các cột
            }
            catch (Exception ex)
            {
                // Nếu có bất kỳ lỗi nào xảy ra, một thông báo lỗi sẽ hiện ra.
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện này được kích hoạt khi người dùng click vào một ô trong DataGridView.
        /// </summary>
       
        /// <summary>
        /// Sự kiện xóa hóa đơn, được cải tiến để an toàn và trực tiếp hơn.
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_idnd.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn '" + lb_idnd.Text + "' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM DonHang WHERE IDDonHang = @MaHD";
                    db.Open();
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@MaHD", lb_idnd.Text);
                    int result = cmd.ExecuteNonQuery();
                    db.Close();

                    if (result > 0)
                    {
                        MessageBox.Show("Đã xóa hóa đơn thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDSHD(); // Tải lại danh sách hóa đơn sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_chitietHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_idnd.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChiTietDonHang chitietHD = new ChiTietDonHang(int.Parse(lb_madh.Text));
            this.Hide();
            chitietHD.ShowDialog();
            this.Show(); // Hiển thị lại form này sau khi form chi tiết đóng
        }

        private void dtg_HD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng đang được chọn
                DataGridViewRow row = dtg_HD.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô trong dòng đó và hiển thị lên các control bên dưới
                // Dùng ?.ToString() để tránh lỗi nếu giá trị trong ô là NULL
                lb_idnd.Text = row.Cells["IDNhanVien"].Value?.ToString();

                lb_madh.Text = row.Cells["IDDonHang"].Value?.ToString();
                lb_thanhtien.Text = row.Cells["TongThanhToan"].Value?.ToString();

                // SỬA LỖI: Gán giá trị cho DateTimePicker (dtHD) một cách chính xác
                if (row.Cells["NgayTao"].Value != null && row.Cells["NgayTao"].Value != DBNull.Value)
                {
                    dtHD.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                }
            }
        }

        private void lb_masp_Click(object sender, EventArgs e)
        {

        }
    }
}