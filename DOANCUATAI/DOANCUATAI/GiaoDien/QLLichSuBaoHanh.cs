using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DOANCUATAI.GiaoDien
{
    public partial class QLLichSuBaoHanh : Form
    {
        DBConnection db = new DBConnection();
        public string MaNV { get; set; } // Mã nhân viên đang đăng nhập

        public QLLichSuBaoHanh(string manv)
        {
            InitializeComponent();
            MaNV = manv;
            LoadLichSuBaoHanh();
        }

        private void QLLichSuBaoHanh_Load(object sender, EventArgs e)
        {
            LoadLichSuBaoHanh();
            
        }

        // Hiển thị toàn bộ lịch sử bảo hành
        void LoadLichSuBaoHanh()
        {
            string sql = @"
                SELECT lh.MaBaoHanh, kh.TenKhachHang, sp.TenSanPham, lh.NgayBaoHanh, lh.NoiDungBaoHanh, 
                       lh.ChiPhi, nv.TenNhanVien AS NhanVienThucHien, lh.TrangThai
                FROM LichSuBaoHanh lh
                JOIN KhachHang kh ON lh.MaKhachHang = kh.MaKhachHang
                JOIN SanPham sp ON lh.MaSanPham = sp.MaSanPham
                JOIN NhanVien nv ON lh.MaNhanVienThucHien = nv.MaNhanVien
                ORDER BY lh.NgayBaoHanh DESC
            ";

            DataTable dt = db.getDataTable(sql);
            dgv_LichSuBaoHanh.DataSource = dt;

            dgv_LichSuBaoHanh.ReadOnly = true;
            dgv_LichSuBaoHanh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_LichSuBaoHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Tìm kiếm theo tên khách hàng hoặc tên sản phẩm
        
    

        private void btn_all_Click_1(object sender, EventArgs e)
        {
            LoadLichSuBaoHanh();
        }


      
        
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            // Lấy nội dung tìm kiếm và "làm sạch" nó một chút để tránh lỗi SQL
            string search = txt_tim.Text.Trim().Replace("'", "''");

            // Tạo câu SQL bằng cách ghép chuỗi
            // Code này đã bao gồm logic tìm kiếm THEO CẢ TÊN KHÁCH HÀNG VÀ TÊN SẢN PHẨM
            string sql = $@"
        SELECT lh.MaBaoHanh, kh.TenKhachHang, sp.TenSanPham, lh.NgayBaoHanh, lh.NoiDungBaoHanh, 
               lh.ChiPhi, nv.TenNhanVien AS NhanVienThucHien, lh.TrangThai
        FROM LichSuBaoHanh lh
        JOIN KhachHang kh ON lh.MaKhachHang = kh.MaKhachHang
        JOIN SanPham sp ON lh.MaSanPham = sp.MaSanPham
        JOIN NhanVien nv ON lh.MaNhanVienThucHien = nv.MaNhanVien
        WHERE (kh.TenKhachHang COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" + search + "%'" +
                "   OR sp.TenSanPham COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" + search + "%')" +
                " ORDER BY lh.NgayBaoHanh DESC";

            try
            {
                // Dùng lại hàm getDataTable của bạn
                DataTable dt = db.getDataTable(sql);
                dgv_LichSuBaoHanh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void comboBoxLichSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLichSu.SelectedItem == null)
            {
                return;
            }

            string selectedStatus = comboBoxLichSu.SelectedItem.ToString();
            if (selectedStatus == "Tất cả")
            {
                LoadLichSuBaoHanh(); 
                return;
            }

            string sanitizedStatus = selectedStatus.Replace("'", "''");

            string sql = $@"
        SELECT lh.MaBaoHanh, kh.TenKhachHang, sp.TenSanPham, lh.NgayBaoHanh, lh.NoiDungBaoHanh, 
               lh.ChiPhi, nv.TenNhanVien AS NhanVienThucHien, lh.TrangThai
        FROM LichSuBaoHanh lh
        JOIN KhachHang kh ON lh.MaKhachHang = kh.MaKhachHang
        JOIN SanPham sp ON lh.MaSanPham = sp.MaSanPham
        JOIN NhanVien nv ON lh.MaNhanVienThucHien = nv.MaNhanVien
        WHERE lh.TrangThai = N'{sanitizedStatus}'
        ORDER BY lh.NgayBaoHanh DESC
    ";

            try
            {
                // Dùng lại hàm getDataTable của bạn
                DataTable dt = db.getDataTable(sql);
                dgv_LichSuBaoHanh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo trạng thái: " + ex.Message);
            }
        }
  
        private void dgv_LichSuBaoHanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_LichSuBaoHanh.Rows[e.RowIndex];

                // Lấy mã bảo hành
                string mabh = row.Cells["MaBaoHanh"].Value.ToString();

                // Truyền vào hàm load chi tiết
                loadchitiet(mabh);
            }
        }
        void loadchitiet(string mabh)
        {
            string sql = "SELECT * FROM LichSuBaoHanh ls , KhachHang kh,SanPham sp WHERE ls.MaBaoHanh = '" + mabh + "' AND ls.MaSanPham=sp.MaSanPham And ls.MaKhachHang=kh.MaKhachHang";

            using (SqlConnection conn = new SqlConnection(db.chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    MaBH.Text = rd["MaBaoHanh"].ToString();
                    lb_TenKhachHang.Text = rd["TenKhachHang"].ToString();
                    lb_TenSP.Text = rd["TenSanPham"].ToString();
                    lb_ChiPhi.Text = rd["MaSanPham"].ToString();
                    lb_NoiDung.Text = rd["NoiDungBaoHanh"].ToString();
                    string trangThai = rd["TrangThai"].ToString();
                    lb_TrangThai.Text = trangThai;

                   
                    if (trangThai == "Hoàn thành")
                    {
                        lb_TrangThai.ForeColor = Color.Green;  
                    }
                    else 
                    {
                        lb_TrangThai.ForeColor = Color.Red;    
                    }
                  


                    lb_NgayBH.Text = Convert.ToDateTime(rd["NgayBaoHanh"])
                                               .ToString("dd/MM/yyyy");
                    lb_NVTH.Text = rd["MaNhanVienThucHien"].ToString();
                }

                rd.Close();
            }
        }

  
    }
}

