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

            bang_ThongKe.Series["Doanh Thu"].Enabled = true;
            bang_ThongKe.Series["Doanh Thu"].ChartType = SeriesChartType.Column;
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
            // Xử lý sự kiệnbiểu đồ nếu cần
        }
        private void ThongKe_Load_1(object sender, EventArgs e)
        {
            if (cbDate.Items.Count == 0)
            {
                cbDate.Items.AddRange(new object[] {
                    "Hôm nay",
                    "Hôm qua",
                    "7 ngày qua",
                    "Tháng này",
                    "Tháng trước",
                    "Năm nay"
                });
                cbDate.SelectedIndex = 2; 
            }

            string query = @"SELECT CAST(NgayTao AS DATE) AS NgayLap, SUM(TongThanhToan) AS TongTienTongCong
                             FROM DonHang
                             WHERE NgayTao >= DATEADD(DAY, -7, GETDATE()) 
                             GROUP BY CAST(NgayTao AS DATE)
                             ORDER BY CAST(NgayTao AS DATE) ASC";

            loadChart(query);
        }

     
    }
}