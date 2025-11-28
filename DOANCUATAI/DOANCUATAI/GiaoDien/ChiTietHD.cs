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

namespace DOANCUATAI.GiaoDien
{
    public partial class ChiTietHD : Form
    {
        DBConnection db = new DBConnection();
        string MaHD { get; set; }
        // string MaTour { get; set; } // Không cần cái này nữa

        public ChiTietHD(string maTour, string mahd)
        {
            InitializeComponent();
            MaHD = mahd;

        }

        void HienThongTinHoaDon(string maHD)
        {
            string sql = "SELECT * FROM HoaDon WHERE MaHoaDon = '" + maHD + "'";
            DataTable dt = db.getDataTable(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Hóa đơn: " + maHD);
                return;
            }

            DataRow row = dt.Rows[0];

            string maNV = row["MaNhanVien"].ToString();
            string maKH = row["MaKhachHang"].ToString();

            // Load tên NV và tên KH
            string sql2 =
                "SELECT (SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = '" + maNV + "') AS TenNV, " +
                "       (SELECT TenKhachHang FROM KhachHang WHERE MaKhachHang = '" + maKH + "') AS TenKH";

            DataTable dt2 = db.getDataTable(sql2);

            if (dt2.Rows.Count > 0)
            {
                lb_tennv.Text = dt2.Rows[0]["TenNV"].ToString();
                lb_tenkh.Text = dt2.Rows[0]["TenKH"].ToString();
            }

            // Load thông tin hóa đơn
            lb_mahd.Text = row["MaHoaDon"].ToString();
            lb_ngaylaphd.Text = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy");
            lb_thanhtien.Text = Convert.ToDecimal(row["TongTien"]).ToString("N0") + " VNĐ";

            // Load danh sách sản phẩm
            LoadSanPhamTrongHoaDon(maHD);
           LoadChiTietHoaDon(MaHD);
        }

        void LoadSanPhamTrongHoaDon(string maHD)
        {

            string sql = "SELECT cthd.MaSanPham, sp.TenSanPham, cthd.SoLuong, cthd.GiaBan " +
                         "FROM ChiTietHoaDon cthd " +
                         "JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham " +
                         "WHERE cthd.MaHoaDon = '" + maHD + "'";

            DataTable dt = db.getDataTable(sql);
           
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            HienThongTinHoaDon(MaHD);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hóa Đơn Bán Hàng", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.DarkRed, new PointF(80, 80));
            e.Graphics.DrawString("Mã Hóa Đơn: " + lb_mahd.Text, new Font("Arial", 12), Brushes.Black, new PointF(50, 130));
            e.Graphics.DrawString("Khách Hàng: " + lb_tenkh.Text, new Font("Arial", 12), Brushes.Black, new PointF(50, 160));
            e.Graphics.DrawString("Nhân viên bán: " + lb_tennv.Text, new Font("Arial", 12), Brushes.Black, new PointF(50, 190));
            e.Graphics.DrawString("Ngày lập: " + lb_ngaylaphd.Text, new Font("Arial", 12), Brushes.Black, new PointF(50, 220));
            e.Graphics.DrawString("Tổng tiền: " + lb_tongtien.Text, new Font("Arial", 12), Brushes.Black, new PointF(50, 250));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // (Không dùng)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // (Không dùng)
        }

        private void lb_mahd_Click(object sender, EventArgs e)
        {

        }
        void LoadChiTietHoaDon(string maHD)
        {
            string sql = $@"
        SELECT 
            sp.TenSanPham,
            cthd.SoLuong,
            cthd.GiaBan,
            (cthd.SoLuong * cthd.GiaBan) AS ThanhTien,
            hd.GhiChu
        FROM ChiTietHoaDon cthd
        JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
        JOIN HoaDon hd ON cthd.MaHoaDon = hd.MaHoaDon
        WHERE cthd.MaHoaDon = '{maHD}'";  // <-- nối trực tiếp

            using (SqlConnection conn = new SqlConnection(db.chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    lb_tensp.Text = rd["TenSanPham"].ToString();
                    lb_soluong.Text = rd["SoLuong"].ToString();
                    lb_gia.Text = Convert.ToDecimal(rd["GiaBan"]).ToString("N0") + " VNĐ";
                    lb_tongtien.Text = Convert.ToDecimal(rd["ThanhTien"]).ToString("N0") + " VNĐ";
                    lb_ghichu.Text = rd["GhiChu"].ToString();
                }

                rd.Close();
            }
        }

    }
}