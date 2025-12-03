using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DOANCUOIKY.GiaoDien;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace DOANCUOIKY.GiaoDien
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        DBConnection db = new DBConnection();

        void loadTongDoanhThu()
        {
            double tong = 0;

            // Chỉ tính tổng khi Series "Doanh  Thu" đang bật
            if (bang_ThongKe.Series["Doanh Thu"].Enabled)
            {
                foreach (var item in bang_ThongKe.Series["Doanh Thu"].Points)
                {
                    double value = item.YValues[0];
                    tong += value;
                }
            }

            string temp = string.Format("Tổng Doanh Thu: {0:N0} VNĐ", tong);
            lblTongDoanhThu.Text = temp;
        }

        void loadChart(string query)
        {
            // Bật Series Doanh Thu
            bang_ThongKe.Series["Doanh Thu"].Enabled = true;
            lblTongDoanhThu.Visible = true;
            label5.Visible = true;

            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {
                bang_ThongKe.Series["Doanh Thu"].XValueType = ChartValueType.Auto;
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";

                if (cbDate.SelectedItem != null && cbDate.SelectedItem.ToString() == "Năm nay")
                {
                    bang_ThongKe.Series["Doanh Thu"].XValueType = ChartValueType.String;
                    bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                }

                bang_ThongKe.ChartAreas["ChartArea1"].AxisY.Title = "Số tiền (VNĐ)";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                bang_ThongKe.Series["Doanh Thu"]["DrawingStyle"] = "Cylinder";
                bang_ThongKe.Series["Doanh Thu"].LabelFormat = "{0:N0} VNĐ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bang_ThongKe.Series["Doanh Thu"].Points.AddXY(dt.Rows[i]["NgayLap"], dt.Rows[i]["TongTienTongCong"]);
                }
                loadTongDoanhThu();
            }
        }

        void loadChart_SanPham(string query)
        {
            // Bật Series Doanh Thu
            bang_ThongKe.Series["Doanh Thu"].Enabled = true;
            lblTongDoanhThu.Visible = true;
            label5.Visible = true;

            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {
                bang_ThongKe.Series["Doanh Thu"].XValueType = ChartValueType.String;
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Sản Phẩm";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu (VNĐ)";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                bang_ThongKe.Series["Doanh Thu"]["DrawingStyle"] = "Cylinder";
                bang_ThongKe.Series["Doanh Thu"].LabelFormat = "{0:N0} VNĐ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bang_ThongKe.Series["Doanh Thu"].Points.AddXY(dt.Rows[i]["TenHang"], dt.Rows[i]["TongDoanh"]);
                }
                loadTongDoanhThu();
            }
        }

        void loadChart_LoaiHang(string query)
        {
            // Bật Series Doanh Thu
            bang_ThongKe.Series["Doanh Thu"].Enabled = true;
            lblTongDoanhThu.Visible = true;
            label5.Visible = true;

            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {
                bang_ThongKe.Series["Doanh Thu"].XValueType = ChartValueType.String;
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Loại Hàng";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu (VNĐ)";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                bang_ThongKe.Series["Doanh Thu"]["DrawingStyle"] = "Cylinder";
                bang_ThongKe.Series["Doanh Thu"].LabelFormat = "{0:N0} VNĐ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bang_ThongKe.Series["Doanh Thu"].Points.AddXY(dt.Rows[i]["TenLoaiHang"], dt.Rows[i]["TongDoanh"]);
                }
                loadTongDoanhThu();
            }
        }

        void loadChart_TrangThai(string query)
        {
            // Bật Series Doanh Thu
            bang_ThongKe.Series["Doanh Thu"].Enabled = true;
            lblTongDoanhThu.Visible = true;
            label5.Visible = true;

            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {
                bang_ThongKe.Series["Doanh Thu"].XValueType = ChartValueType.String;
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Title = "Trạng Thái Đơn Hàng";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu (VNĐ)";
                bang_ThongKe.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                bang_ThongKe.Series["Doanh Thu"]["DrawingStyle"] = "Cylinder";
                bang_ThongKe.Series["Doanh Thu"].LabelFormat = "{0:N0} VNĐ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bang_ThongKe.Series["Doanh Thu"].Points.AddXY(dt.Rows[i]["TrangThai"], dt.Rows[i]["TongDoanh"]);
                }
                loadTongDoanhThu();
            }
        }

        void clearChart()
        {
            bang_ThongKe.Series["Doanh Thu"].Points.Clear();
        }

     

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearChart();
            string query = "";

            if (cbDate.SelectedItem == null) return;

            switch (cbDate.SelectedItem.ToString())
            {
                case "Hôm nay":
                    query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE CAST(NgayTao AS DATE) = CAST(GETDATE() AS DATE)
                              GROUP BY CAST(NgayTao AS DATE)
                              ORDER BY CAST(NgayTao AS DATE) ASC";
                    break;

                case "Hôm qua":
                    query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE CAST(NgayTao AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                              GROUP BY CAST(NgayTao AS DATE)
                              ORDER BY CAST(NgayTao AS DATE) ASC";
                    break;

                case "7 ngày qua":
                    query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE NgayTao >= DATEADD(DAY, -7, GETDATE()) AND NgayTao <= GETDATE()
                              GROUP BY CAST(NgayTao AS DATE)
                              ORDER BY CAST(NgayTao AS DATE) ASC";
                    break;

                case "Tháng này":
                    query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE DATEPART(YEAR, NgayTao) = DATEPART(YEAR, GETDATE())
                              AND DATEPART(MONTH, NgayTao) = DATEPART(MONTH, GETDATE())
                              GROUP BY CAST(NgayTao AS DATE)
                              ORDER BY CAST(NgayTao AS DATE) ASC";
                    break;

                case "Tháng trước":
                    query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE DATEPART(YEAR, NgayTao) = DATEPART(YEAR, DATEADD(MONTH, -1, GETDATE()))
                              AND DATEPART(MONTH, NgayTao) = DATEPART(MONTH, DATEADD(MONTH, -1, GETDATE()))
                              GROUP BY CAST(NgayTao AS DATE)
                              ORDER BY CAST(NgayTao AS DATE) ASC";
                    break;

                case "Năm nay":
                    query = @"SELECT MONTH(NgayTao) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                              FROM DonHang
                              WHERE YEAR(NgayTao) = YEAR(GETDATE())
                              GROUP BY MONTH(NgayTao)
                              ORDER BY MONTH(NgayTao) ASC";
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                loadChart(query);
            }
        }

      

        private void chart_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click biểu đồ nếu cần
        }

        //private void cbb_thongketour_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    clearChart();
        //    string query = "";

        //    if (cbb_thongketour.SelectedItem == null) return;

        //    switch (cbb_thongketour.SelectedItem.ToString())
        //    {
        //        case "Sản Phẩm":
        //            query = @"SELECT TOP 10 HG.TenHang, SUM(CTD.SoLuong * CTD.DonGia) AS TongDoanh
        //                      FROM ChiTiet_DonHang CTD
        //                      JOIN HangHoa_BThe HB ON CTD.IDBienThe = HB.IDBienThe
        //                      JOIN HangHoa HG ON HB.IDHang = HG.IDHang
        //                      GROUP BY HG.TenHang
        //                      ORDER BY TongDoanh DESC";
        //            loadChart_SanPham(query);
        //            break;

        //        case "Loại Hàng":
        //            query = @"SELECT LH.TenLoaiHang, SUM(CTD.SoLuong * CTD.DonGia) AS TongDoanh
        //                      FROM ChiTiet_DonHang CTD
        //                      JOIN HangHoa_BThe HB ON CTD.IDBienThe = HB.IDBienThe
        //                      JOIN HangHoa HG ON HB.IDHang = HG.IDHang
        //                      JOIN LoaiHang LH ON HG.IDLoaiHang = LH.IDLoaiHang
        //                      GROUP BY LH.TenLoaiHang
        //                      ORDER BY TongDoanh DESC";
        //            loadChart_LoaiHang(query);
        //            break;

        //        case "Trạng Thái":
        //            query = @"SELECT TrangThai, SUM(TongThanhToan) AS TongDoanh
        //                      FROM DonHang
        //                      GROUP BY TrangThai
        //                      ORDER BY TongDoanh DESC";
        //            loadChart_TrangThai(query);
        //            break;
        //    }
        //}

        private void ThongKe_Load_1(object sender, EventArgs e)
        {
            string query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                             FROM DonHang
                             WHERE NgayTao >= DATEADD(DAY, -7, GETDATE()) 
                             GROUP BY CAST(NgayTao AS DATE)
                             ORDER BY CAST(NgayTao AS DATE) ASC";

            loadChart(query);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {

        }
    }
}