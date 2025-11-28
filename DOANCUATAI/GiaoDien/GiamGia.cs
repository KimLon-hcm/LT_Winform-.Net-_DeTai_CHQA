using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOANCUOIKY.GiaoDien;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DOANCUOIKY
{
    public partial class GiamGia : Form
    {
        public GiamGia()
        {
            InitializeComponent();
        }

        DBConnection db = new DBConnection();
        public int IDGG { get; set; }
        public GiamGia(int idgg)
        {
            InitializeComponent();
            IDGG = idgg;
            txt_ID.Enabled = false;
        }

        private bool KiemTraThongTinHopLe()
        {
            // Kiểm tra mã giảm giá
            if (string.IsNullOrWhiteSpace(txt_ID.Text))
            {
                MessageBox.Show("Mã giảm giá không được để trống!");
                return false;
            }

            // Kiểm tra loại
            if (string.IsNullOrWhiteSpace(txt_loai.Text) || !int.TryParse(txt_loai.Text, out _))
            {
                MessageBox.Show("Loại phải là số nguyên!");
                return false;
            }

            // Kiểm tra giá trị
            if (string.IsNullOrWhiteSpace(txt_gia.Text) || !decimal.TryParse(txt_gia.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá trị phải là số dương!");
                return false;
            }

            // Kiểm tra đơn hàng tối thiểu
            if (string.IsNullOrWhiteSpace(txt_dontoithieu.Text) || !decimal.TryParse(txt_dontoithieu.Text, out decimal dontoithieu) || dontoithieu < 0)
            {
                MessageBox.Show("Đơn hàng tối thiểu phải là số dương!");
                return false;
            }

            // Kiểm tra giảm tối đa
            if (string.IsNullOrWhiteSpace(txt_giamtoida.Text) || !decimal.TryParse(txt_giamtoida.Text, out decimal giamtoida) || giamtoida < 0)
            {
                MessageBox.Show("Giảm tối đa phải là số dương!");
                return false;
            }

            // Kiểm tra số lượng
            if (string.IsNullOrWhiteSpace(txt_soluong.Text) || !int.TryParse(txt_soluong.Text, out int soluong) || soluong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return false;
            }

            // Kiểm tra ngày bắt đầu
            if (string.IsNullOrWhiteSpace(txt_ngaybd.Text) || !DateTime.TryParse(txt_ngaybd.Text, out DateTime ngaybd))
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ (định dạng: yyyy-MM-dd)!");
                return false;
            }

            // Kiểm tra ngày kết thúc
            if (string.IsNullOrWhiteSpace(txt_ngaykt.Text) || !DateTime.TryParse(txt_ngaykt.Text, out DateTime ngaykt))
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ (định dạng: yyyy-MM-dd)!");
                return false;
            }

            // Kiểm tra ngày kết thúc >= ngày bắt đầu
            if (ngaykt < ngaybd)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!");
                return false;
            }

            // Kiểm tra trạng thái
            if (cbb_trangthai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return false;
            }

            return true;
        }

        void Reset()
        {
            txt_ID.Clear();
            txt_ma.Clear();
            txt_gia.Clear();
            txt_giamtoida.Text = "";
            txt_soluong.Text = "";
            txt_dontoithieu.Text = "";
            txt_sudung.Text = "";
            txt_loai.Text = "";
            cbb_trangthai.SelectedIndex = -1;
            txt_ngaybd.Text = "";
            txt_ngaykt.Text = "";
        }

        void HienThiDSKH()
        {
            dgv_khachhang.ReadOnly = true;
            string chuoitruyvan = "SELECT * FROM GiamGia";
            DataTable dt = db.getDataTable(chuoitruyvan);
            dgv_khachhang.DataSource = dt;
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MAIN_QL main = new MAIN_QL(IDGG);
            main.ShowDialog();
        }

        void LoadComboBoxTrangThai()
        {
            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("Hoạt Động");
            cbb_trangthai.Items.Add("Không Hoạt Động");
            cbb_trangthai.SelectedIndex = -1;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            string sql = "SELECT * FROM GiamGia";

            int kq = db.updateDataTable(dt, sql);

            if (kq > 0)
            {
                MessageBox.Show("Đã lưu thay đổi thành công!");
                btn_luu.Visible = false;
                HienThiDSKH();
                Reset();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void LoadDataBySearch(string searchName)
        {
            string chuoitruyvan = "SELECT * FROM GiamGia " +
                "WHERE MaGiamGia COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" +
                txt_timnpp.Text.Trim().Replace("'", "''") + "%'";
            DataTable dt = db.getDataTable(chuoitruyvan);
            dgv_khachhang.DataSource = dt;
        }

        bool checkMa(int ma)
        {
            string checkMa = "SELECT IDGiamGia FROM GiamGia WHERE IDGiamGia = '" + ma + "'";
            int kq = db.CheckData(checkMa);
            return kq != 0;
        }

        private void QLNPP_Load_1(object sender, EventArgs e)
        {
            HienThiDSKH();
            LoadComboBoxTrangThai();
        }

        private void txt_timnpp_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (string.IsNullOrWhiteSpace(txt_ID.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
                return;
            }

            // Kiểm tra thông tin hợp lệ
            if (!KiemTraThongTinHopLe())
            {
                return;
            }

            // Kiểm tra mã giảm giá có bị trùng không (ngoại trừ bản ghi hiện tại)
            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            string currentId = txt_ID.Text;
            string newCode = txt_ma.Text;

            bool isDuplicate = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["IDGiamGia"].ToString() != currentId &&
                    row["MaGiamGia"].ToString() == newCode)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (isDuplicate)
            {
                MessageBox.Show("Mã giảm giá này đã tồn tại!");
                return;
            }

            dt.PrimaryKey = new DataColumn[] { dt.Columns["IDGiamGia"] };
            DataRow dr = dt.Rows.Find(currentId);

            if (dr == null)
            {
                MessageBox.Show("Không tìm thấy bản ghi để sửa.");
                return;
            }

            try
            {
                dr["MaGiamGia"] = txt_ma.Text;
                dr["Loai"] = int.Parse(txt_loai.Text);
                dr["GiaTri"] = decimal.Parse(txt_gia.Text);
                dr["DonHangToiThieu"] = decimal.Parse(txt_dontoithieu.Text);
                dr["GiamToiDa"] = decimal.Parse(txt_giamtoida.Text);
                dr["SoLuong"] = int.Parse(txt_soluong.Text);
                dr["DaSuDung"] = int.Parse(txt_sudung.Text);
                dr["TrangThai"] = (cbb_trangthai.Text == "Hoạt Động");
                dr["NgayBatDau"] = DateTime.Parse(txt_ngaybd.Text);
                dr["NgayKetThuc"] = DateTime.Parse(txt_ngaykt.Text);

                btn_luu.Visible = true;
                MessageBox.Show("Đã sửa thông tin, nhấn Lưu để cập nhật CSDL.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (string.IsNullOrWhiteSpace(txt_ID.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["IDGiamGia"] };

            DataRow dr = dt.Rows.Find(txt_ID.Text);

            if (dr == null)
            {
                MessageBox.Show("Không tìm thấy bản ghi để xóa.");
                return;
            }

            try
            {
                dr.Delete();
                btn_luu.Visible = true;
                MessageBox.Show("Đã xóa khỏi danh sách, nhấn Lưu để ghi vào CSDL.");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin hợp lệ
            if (!KiemTraThongTinHopLe())
            {
                return;
            }

            DataTable dt = (DataTable)dgv_khachhang.DataSource;

            // Kiểm tra mã giảm giá có bị trùng không
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState != DataRowState.Deleted &&
                    row["MaGiamGia"].ToString() == txt_ma.Text)
                {
                    MessageBox.Show("Mã giảm giá này đã tồn tại!");
                    return;
                }
            }

            try
            {
                DataRow dr = dt.NewRow();

                dr["MaGiamGia"] = txt_ma.Text;
                dr["Loai"] = int.Parse(txt_loai.Text);
                dr["GiaTri"] = decimal.Parse(txt_gia.Text);
                dr["DonHangToiThieu"] = decimal.Parse(txt_dontoithieu.Text);
                dr["GiamToiDa"] = decimal.Parse(txt_giamtoida.Text);
                dr["SoLuong"] = int.Parse(txt_soluong.Text);
                dr["DaSuDung"] = int.Parse(txt_sudung.Text);
                dr["TrangThai"] = (cbb_trangthai.Text == "Hoạt Động");
                dr["NgayBatDau"] = DateTime.Parse(txt_ngaybd.Text);
                dr["NgayKetThuc"] = DateTime.Parse(txt_ngaykt.Text);

                dt.Rows.Add(dr);

                btn_luu.Visible = true;
                MessageBox.Show("Đã thêm vào danh sách, nhấn Lưu để ghi vào CSDL.");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            HienThiDSKH();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string searchName = txt_timnpp.Text.Trim();
            LoadDataBySearch(searchName);
        }

        private void dgv_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgv_khachhang.Rows[e.RowIndex];

                    txt_ID.Text = row.Cells["IDGiamGia"].Value?.ToString() ?? "";
                    txt_ma.Text = row.Cells["MaGiamGia"].Value?.ToString() ?? "";
                    txt_loai.Text = row.Cells["Loai"].Value?.ToString() ?? "";
                    txt_gia.Text = row.Cells["GiaTri"].Value?.ToString() ?? "";
                    txt_dontoithieu.Text = row.Cells["DonHangToiThieu"].Value?.ToString() ?? "";
                    txt_giamtoida.Text = row.Cells["GiamToiDa"].Value?.ToString() ?? "";
                    txt_soluong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
                    txt_sudung.Text = row.Cells["DaSuDung"].Value?.ToString() ?? "";

                    string tt = row.Cells["TrangThai"].Value?.ToString() ?? "False";
                    cbb_trangthai.Text = (tt == "True" || tt == "1") ? "Hoạt Động" : "Không Hoạt Động";

                    txt_ngaybd.Text = row.Cells["NgayBatDau"].Value?.ToString() ?? "";
                    txt_ngaykt.Text = row.Cells["NgayKetThuc"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}

