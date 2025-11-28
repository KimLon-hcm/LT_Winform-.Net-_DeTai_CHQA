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
using System.Configuration;


namespace DOANCUATAI.GiaoDien
{
     public partial class QLKhachHang : Form
     {
          DBConnection db = new DBConnection();
          public string MaNV { get; set; }

          public QLKhachHang(string manv)
          {
               InitializeComponent();
               MaNV = manv;

          }

          void Reset()
          {
               txt_makhachhang.Clear();
               txt_hoten.Clear();
               txt_sdt.Clear();
               txt_loaiKH.Clear();
                txt_diachi.Text="";
            txt_ghichu.Text="";
            rdo_nam.Checked = false;
             rdo_nu.Checked = false;
            txt_ngaysinh.Text = "";
        }
          void HienThiDSKH()
          {
              dgv_khachhang.ReadOnly = true;
               string chuoitruyvan = "SELECT * FROM KHACHHANG";
               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_khachhang.DataSource = dt;
          }
          private void QLKhachHang_Load(object sender, EventArgs e)
          {
               HienThiDSKH();
          }



          private void btn_TrangChu_Click_1(object sender, EventArgs e)
          {
               this.Hide();


               MAIN_QL main = new MAIN_QL(MaNV);
               main.ShowDialog();
          }

          private string TaoMaSP()
          {
              int maNVTangDan = 1;
              string Lay3KiTuCuoi = Lay3KiTuCuoiTuCSDL();

              // Nếu có mã sản phẩm trong CSDL, sử dụng 3 kí tự cuối cùng của mã SP để tăng dần
              if (!string.IsNullOrEmpty(Lay3KiTuCuoi))
              {
                  maNVTangDan = int.Parse(Lay3KiTuCuoi) + 1;
              }
              string maNV = "KH" + maNVTangDan.ToString("D3");

              return maNV;
          }
          private string Lay3KiTuCuoiTuCSDL()
          {
                  db.Open();
                  string maNVToCheck = txt_makhachhang.Text;

                  string sql = "SELECT TOP 1 RIGHT(MaKhachHang, 3) FROM KhachHang ORDER BY MaKhachHang DESC";
                    
                
                      object result = db.getScalar(sql);

                      // Trả về 3 kí tự cuối hoặc chuỗi rỗng nếu không có mã SP trong CSDL
                      return result != null ? result.ToString() : string.Empty;
                
                 
            

          }

         
          private void btn_makh_Click(object sender, EventArgs e)
          {
              string maNV = TaoMaSP();
              txt_makhachhang.Text = maNV;   
          }

        bool checkKH_HD(string MaKH)
        {
            string checkKH_HD = "SELECT MaKhachHang FROM HOADON WHERE MaKhachHang = (SELECT MaKhachHang FROM KHACHHANG WHERE MaKhachHang = '"+MaKH+"' ) ";
            int kq = db.CheckData(checkKH_HD);

            if(kq!=0)
            {
                return true;
            }
            return false;

          }

         

          private void dgv_khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
          {
              
               if (e.RowIndex >= 0)
               {

                    DataGridViewRow row = dgv_khachhang.Rows[e.RowIndex];

                txt_makhachhang.Text = row.Cells["MaKhachHang"].Value.ToString();
                txt_ngaysinh.Text = row.Cells["NgaySinh"].Value.ToString();
                txt_diachi.Text = row.Cells["DiaChi"].Value.ToString();
                txt_ghichu.Text = row.Cells["GhiChu"].Value.ToString();
                txt_hoten.Text = row.Cells["TenKhachHang"].Value.ToString();
                txt_loaiKH.Text = row.Cells["LoaiKhachHang"].Value.ToString();
                txt_sdt.Text = row.Cells["SDT"].Value.ToString();
                   


                    if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                    {
                         rdo_nu.Checked = true;
                    }
                    else
                    {
                         rdo_nam.Checked = true;
                    }
                    //dt_ngaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

               }
          }



        private void btn_luu_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            string sql = "SELECT * FROM KhachHang";

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
            string chuoitruyvan =
 "SELECT * FROM KHACHHANG " +
 "WHERE TenKhachHang COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%" +
 txt_timkh.Text.Trim().Replace("'", "''") +
 "%'";
            DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_khachhang.DataSource = dt;

          }
          private void btn_tim_Click(object sender, EventArgs e)
          {

               string searchName = txt_timkh.Text.Trim();
               LoadDataBySearch(searchName);
          }

          bool checkMa(string ma)
          {
              string checkMa = "SELECT MaKhachHang FROM KHACHHANG Where MaKhachHang = '" + ma + "'";
              int kq = db.CheckData(checkMa);
              if (kq != 0)
              {
                  return true;
              }
              return false;
          }





        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaKhachHang"] };

            DataRow dr = dt.Rows.Find(txt_makhachhang.Text);

            if (dr == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
                return;
            }

            string gioiTinh = rdo_nam.Checked ? "Nam" :
                              rdo_nu.Checked ? "Nữ" : "Khác";

            dr["TenKhachHang"] = txt_hoten.Text;
            dr["NgaySinh"] = txt_ngaysinh.Text;
            dr["GioiTinh"] = gioiTinh;
            dr["DiaChi"] = txt_diachi.Text;
            dr["SDT"] = txt_sdt.Text;
            dr["LoaiKhachHang"] = txt_loaiKH.Text;
            dr["GhiChu"] = txt_ghichu.Text;

            btn_luu.Visible = true;
            MessageBox.Show("Đã sửa thông tin, nhấn Lưu để cập nhật CSDL.");
        }


        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            if (checkKH_HD(txt_makhachhang.Text))
            {
                MessageBox.Show("Khách hàng đang có hóa đơn, không thể xóa!");
                return;
            }

            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaKhachHang"] };

            DataRow dr = dt.Rows.Find(txt_makhachhang.Text);

            if (dr == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
                return;
            }

            dr.Delete();

            btn_luu.Visible = true;
            MessageBox.Show("Đã xóa khỏi danh sách, nhấn Lưu để ghi vào CSDL.");
        }


        private void btn_them_Click_1(object sender, EventArgs e)
        {
            if (checkMa(txt_makhachhang.Text))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông Báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_makhachhang.Text))
            {
                MessageBox.Show("Hãy tạo mã khách hàng trước!");
                return;
            }

            string gioiTinh = rdo_nam.Checked ? "Nam" :
                              rdo_nu.Checked ? "Nữ" : "Khác";

            DataTable dt = (DataTable)dgv_khachhang.DataSource;
            DataRow dr = dt.NewRow();

            dr["MaKhachHang"] = txt_makhachhang.Text;
            dr["TenKhachHang"] = txt_hoten.Text;
            DateTime ngaySinh;
            if (!DateTime.TryParse(txt_ngaysinh.Text, out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Định dạng: dd/MM/yyyy");
                return;
            }

            dr["NgaySinh"] = ngaySinh;


            dr["GioiTinh"] = gioiTinh;
            dr["DiaChi"] = txt_diachi.Text;
            dr["SDT"] = txt_sdt.Text;
            dr["LoaiKhachHang"] = txt_loaiKH.Text;
            dr["GhiChu"] = txt_ghichu.Text;

            dt.Rows.Add(dr);

            btn_luu.Visible = true;
            MessageBox.Show("Đã thêm vào danh sách, nhấn Lưu để ghi vào CSDL.");
        }


        private void btn_all_Click_1(object sender, EventArgs e)
        {
            HienThiDSKH();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                return;
            }

            string selectedStatus = comboBox1.SelectedItem.ToString();
            if (selectedStatus == "Tất cả")
            {
                HienThiDSKH();
                return;
            }

            string sanitizedStatus = selectedStatus.Replace("'", "''");

            string sql = $@"
        SELECT *
        FROM KhachHang kh
        WHERE LoaiKhachHang = N'{sanitizedStatus}'
    ";

            try
            {
                // Dùng lại hàm getDataTable của bạn
                DataTable dt = db.getDataTable(sql);
                dgv_khachhang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc theo trạng thái: " + ex.Message);
            }
        }


    
    }
}
