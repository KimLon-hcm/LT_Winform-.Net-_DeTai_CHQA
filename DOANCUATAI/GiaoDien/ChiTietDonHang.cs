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
using DOANCUOIKY;
using DOANCUOIKY.GiaoDien;

namespace DOANCUOIKY.GiaoDien
{
    public partial class ChiTietDonHang : Form
    {
        DBConnection db = new DBConnection();
        int IDHH { get; set; }

        // Biến lưu thành tiền từng sản phẩm để in
        private string thanhTienSanPham = "";

        public ChiTietDonHang(int iddh)
        {
            InitializeComponent();
            IDHH = iddh;
        }

        void HienThongTinHoaDon(int iddh)
        {
            try
            {
                string sql = "SELECT * FROM DonHang WHERE IDDonHang = @IDDonHang";

                db.Open();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@IDDonHang", iddh);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                db.Close();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy Đơn Hàng: " + iddh);
                    return;
                }

                DataRow row = dt.Rows[0];
                string idnd = row["IDNguoiDung"].ToString();

                // Load tên NV và KH
                string sql2 = @"SELECT 
                               (SELECT HoTen FROM NguoiDung WHERE IDNguoiDung = @IDNguoiDung) AS TenND, 
                               (SELECT TenNguoiNhan FROM DonHang WHERE IDDonHang = @IDDonHang) AS TenNN";

                db.Open();
                SqlCommand cmd2 = new SqlCommand(sql2, db.conn);
                cmd2.Parameters.AddWithValue("@IDNguoiDung", idnd);
                cmd2.Parameters.AddWithValue("@IDDonHang", iddh);

                DataTable dt2 = new DataTable();
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                adapter2.Fill(dt2);
                db.Close();

                if (dt2.Rows.Count > 0)
                {
                    txt_tennd.Text = dt2.Rows[0]["TenND"].ToString();
                    txt_tennn.Text = dt2.Rows[0]["TenNN"].ToString();
                }

                lb_madh.Text = row["IDDonHang"].ToString();
                txt_ngaytao.Text = Convert.ToDateTime(row["NgayTao"]).ToString("dd/MM/yyyy");

                // Load chi tiết đơn hàng
                LoadChiTietDonHang(iddh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void LoadChiTietDonHang(int iddh)
        {
            try
            {
                // === LẤY THÔNG TIN SẢN PHẨM TRONG ĐƠN HÀNG ===
                string sqlChiTiet = @"
                    SELECT 
                        hh.TenHang,
                        bt.Mau,
                        bt.Size,
                        ctdh.SoLuong,
                        ctdh.DonGia AS GiaBan,
                        (ctdh.SoLuong * ctdh.DonGia) AS ThanhTien
                    FROM ChiTiet_DonHang ctdh
                    JOIN HangHoa_BThe bt ON ctdh.IDBienThe = bt.IDBienThe
                    JOIN HangHoa hh ON bt.IDHang = hh.IDHang
                    WHERE ctdh.IDDonHang = @IDDonHang
                    ";

                SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, db.conn);
                cmdChiTiet.Parameters.AddWithValue("@IDDonHang", iddh);

                db.Open();
                SqlDataReader readerChiTiet = cmdChiTiet.ExecuteReader();

                StringBuilder sbTenSP = new StringBuilder();
                StringBuilder sbSoLuong = new StringBuilder();
                StringBuilder sbGia = new StringBuilder();
                StringBuilder sbThanhTien = new StringBuilder();

                while (readerChiTiet.Read())
                {
                    string ten = readerChiTiet["TenHang"].ToString();
                    string mau = readerChiTiet["Mau"].ToString();
                    string size = readerChiTiet["Size"].ToString();
                    decimal giaBan = Convert.ToDecimal(readerChiTiet["GiaBan"]);
                    int soLuong = Convert.ToInt32(readerChiTiet["SoLuong"]);
                    decimal thanhTien = Convert.ToDecimal(readerChiTiet["ThanhTien"]);

                    sbTenSP.AppendLine($"{ten} ({mau}/{size})");
                    sbSoLuong.AppendLine(soLuong.ToString());
                    sbGia.AppendLine(giaBan.ToString("N0") + " VNĐ");
                    sbThanhTien.AppendLine(thanhTien.ToString("N0") + " VNĐ");
                }

                readerChiTiet.Close();

                // Lưu thành tiền vào biến để dùng khi in
                thanhTienSanPham = sbThanhTien.ToString();

                // === LẤY THÔNG TIN ĐƠN HÀNG ===
                string sqlDonHang = @"
                    SELECT 
                        IDDonHang,
                        DiaChiGiao,
                        SoDienThoai,
                        TongTienHang,
                        GiamGia,
                        PhiVanChuyen,
                        TrangThai
                    FROM DonHang
                    WHERE IDDonHang = @IDDonHang";

                SqlCommand cmdDonHang = new SqlCommand(sqlDonHang, db.conn);
                cmdDonHang.Parameters.AddWithValue("@IDDonHang", iddh);

                SqlDataReader readerDonHang = cmdDonHang.ExecuteReader();

                if (readerDonHang.Read())
                {
                    // Thông tin khách hàng
                    txt_diachi.Text = readerDonHang["DiaChiGiao"].ToString();
                    txt_sdt.Text = readerDonHang["SoDienThoai"].ToString();

                    // Thông tin tiền
                    decimal tongTienHang = Convert.ToDecimal(readerDonHang["TongTienHang"]);
                    decimal giamGia = readerDonHang["GiamGia"] != DBNull.Value
                        ? Convert.ToDecimal(readerDonHang["GiamGia"])
                        : 0;
                    decimal phiVanChuyen = readerDonHang["PhiVanChuyen"] != DBNull.Value
                        ? Convert.ToDecimal(readerDonHang["PhiVanChuyen"])
                        : 0;
                    decimal thanhTienTong = tongTienHang - giamGia + phiVanChuyen;

                    txt_tongtien.Text = tongTienHang.ToString("N0") + " VNĐ";
                    txt_gg.Text = giamGia.ToString("N0") + " VNĐ";
                    txt_phivanchuyen.Text = phiVanChuyen.ToString("N0") + " VNĐ";
                    txt_thanhtien.Text = thanhTienTong.ToString("N0") + " VNĐ";

                    // Trạng thái
                    string trangThai = readerDonHang["TrangThai"].ToString();
                    if (trangThai == "0")
                        txt_trangthai.Text = "Chờ xác nhận";
                    else if (trangThai == "1")
                        txt_trangthai.Text = "Đã xác nhận";
                    else if (trangThai == "2")
                        txt_trangthai.Text = "Đang giao";
                    else if (trangThai == "3")
                        txt_trangthai.Text = "Đã giao";
                    else
                        txt_trangthai.Text = "Hủy";
                }
                readerDonHang.Close();

                db.Close();

                // === HIỂN THỊ THÔNG TIN SẢN PHẨM ===
                lb_ten.Text = sbTenSP.ToString();
                lb_soluong.Text = sbSoLuong.ToString();
                lb_gia.Text = sbGia.ToString();
            }
            catch (Exception ex)
            {
                if (db.conn.State == ConnectionState.Open)
                    db.Close();
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message);
            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            HienThongTinHoaDon(IDHH);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float y = 80;

            // Tiêu đề
            e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.DarkRed, new PointF(150, y));

            // Thông tin chung
            y = 130;
            e.Graphics.DrawString("Mã Hóa Đơn: " + lb_madh.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("Khách Hàng: " + txt_tennn.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("Nhân viên bán: " + txt_tennd.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("Ngày lập: " + txt_ngaytao.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("Địa chỉ giao: " + txt_diachi.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("SĐT: " + txt_sdt.Text, new Font("Arial", 11), Brushes.Black, new PointF(50, y));

            // Danh sách sản phẩm
            y += 35;
            e.Graphics.DrawString("DANH SÁCH SẢN PHẨM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(50, y));

            // Tiêu đề cột
            y += 25;
            e.Graphics.DrawString("Sản phẩm", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(50, y));
            e.Graphics.DrawString("SL", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(250, y));
            e.Graphics.DrawString("Giá", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(300, y));
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(380, y));

            // Dữ liệu
            string[] tenSP = lb_ten.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] soLuong = lb_soluong.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] gia = lb_gia.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] thanhTien = thanhTienSanPham.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            y += 20;
            for (int i = 0; i < tenSP.Length; i++)
            {
                e.Graphics.DrawString(tenSP[i], new Font("Arial", 9), Brushes.Black, new PointF(50, y));
                if (i < soLuong.Length)
                    e.Graphics.DrawString(soLuong[i], new Font("Arial", 9), Brushes.Black, new PointF(250, y));
                if (i < gia.Length)
                    e.Graphics.DrawString(gia[i], new Font("Arial", 9), Brushes.Black, new PointF(300, y));
                if (i < thanhTien.Length)
                    e.Graphics.DrawString(thanhTien[i], new Font("Arial", 9), Brushes.Black, new PointF(380, y));
                y += 20;
            }

            // Tổng tiền
            y += 15;
            e.Graphics.DrawString("Tổng tiền hàng: " + txt_tongtien.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(50, y));
            y += 20;
            e.Graphics.DrawString("Giảm giá: " + txt_gg.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(50, y));
            y += 20;
            e.Graphics.DrawString("Phí vận chuyển: " + txt_phivanchuyen.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(50, y));
            y += 25;
            e.Graphics.DrawString("TỔNG THANH TOÁN: " + txt_thanhtien.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.DarkRed, new PointF(50, y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in: " + ex.Message);
            }
        }

        private void lb_gia_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}