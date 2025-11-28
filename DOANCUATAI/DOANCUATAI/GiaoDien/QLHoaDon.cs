using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANCUATAI.GiaoDien
{
    public partial class QLHoaDon : Form
    {
        DBConnection db = new DBConnection();
        public QLHoaDon()
        {
            InitializeComponent();
        }
        void HienThiDSHD()
        {
            //string chuoitruyvan = "SELECT SoHD, KHACHHANG.HoTen as TenKH, NhanVien.HoTen as TenNV, NgayLapHD, THONGTINTOUR.TenTour, ThanhTien FROM HOADON join KHACHHANG on HOADON.MaKH = KHACHHANG.MaKH join NhanVien on HOADON.MaNV = NhanVien.MaNV join THONGTINTOUR on HOADON.MaTour = THONGTINTOUR.MaTour";
            string chuoitruyvan = "SELECT * FROM HOADON";
            DataTable dt = db.getDataTable(chuoitruyvan);
            dtg_HD.ReadOnly = true;
            dtg_HD.DataSource = dt;
        }

        //bool checkhuyve()
        //{
        //    // Giả sử bạn có DateTimePicker để chọn ngày bắt đầu tour và ngày hủy vé
        //    DateTime ngayBatDauTour = dtpNgayBatDauTour.Value;
        //    DateTime ngayHuyVe = dtpNgayHuyVe.Value;

        //    // Kiểm tra nếu ngày hủy vé ít hơn ngày bắt đầu tour
        //    if (ngayHuyVe < ngayBatDauTour)
        //    {
        //        MessageBox.Show("Ngày hủy vé phải ít hơn ngày bắt đầu tour.");
        //    }
        //    else
        //    {
               
        //    }
        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)dtg_HD.DataSource;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaHoaDon"] };
            DataRow dr = dt.Rows.Find(lb_mahd.Text);
            //Xóa
            if (dr != null)
            {
                dr.Delete();
                //cap nhat csdl
                string chuoitruyvan = "SELECT * FROM HoaDon ";
                int k = db.updateDataTable(dt, chuoitruyvan);
                if (k != 0)
                {
                    MessageBox.Show("Da xoa");
                }
                else
                    MessageBox.Show("Chua xoa");
            }
            else
            {
                MessageBox.Show("Khong tim thay Khoa");
            }
        }

       

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHD();
        }

        private void dtg_HD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtg_HD.ReadOnly = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_HD.Rows[e.RowIndex];
                lb_mahd.Text = row.Cells["MaHoaDon"].Value.ToString();
                lb_mahd.Visible = true;
                lb_masp.Text = row.Cells["MaKhachHang"].Value.ToString();
                lb_masp.Visible = true;
                lb_thanhtien.Text = row.Cells["TongTien"].Value.ToString();
                lb_thanhtien.Visible = true;
                dtHD.Text = row.Cells["NgayLap"].Value.ToString();
            }
              
            
        }

        private void btn_chitietHD_Click(object sender, EventArgs e)
        {
            ChiTietHD chitietHD = new ChiTietHD(lb_masp.Text, lb_mahd.Text);
            this.Hide();
            chitietHD.ShowDialog();

        }


       
    }
}
