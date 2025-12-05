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
using DOANCUATAI.GiaoDien;

using DOANCUOIKY;

namespace DOANCUATAI.GiaoDien
{
    public partial class DatHang : Form
    {

        DBConnection db = new DBConnection();
        int IDND { get; set; }

        int IDHang { get; set; }
        int IDBienThe { get; set; }
       
        public DatHang(int idND, int idHang, int idBienThe)
        {
            InitializeComponent();
            IDND = idND;
            IDHang = idHang;
            IDBienThe = idBienThe;
        }

        private void HienThiThongTinSanPham()
        {
            try
            {
                string sql = @"SELECT hh.IDHang, hh.TenHang, hhbt.IDBienThe, hhbt.Gia, 
              hhbt.GiaKhuyenMai, hhbt.SoLuongTon 
       FROM HangHoa hh 
       JOIN HangHoa_BThe hhbt ON hh.IDHang = hhbt.IDHang 
       WHERE hh.IDHang = '" + IDHang + "' AND hhbt.IDBienThe = '" + IDBienThe + "'";
                DataTable dt = db.getDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txt_masp.Text = dr["IDHang"].ToString();
                    txt_mabt.Text = dr["IDBienThe"].ToString();
                    txt_tenhang.Text = dr["TenHang"].ToString();
                    txt_Gia.Text = dr["Gia"].ToString();
                    txt_soluongton.Text = dr["SoLuongTon"].ToString();
                    txt_giakm.Text = dr["GiaKhuyenMai"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
            }
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                string sql = "SELECT IDKhachHang, HoTen FROM KhachHang ORDER BY HoTen";
                DataTable dt = db.getDataTable(sql);

                cbb_khachhang.DataSource = dt;
                cbb_khachhang.DisplayMember = "HoTen";
                cbb_khachhang.ValueMember = "IDKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách khách hàng: " + ex.Message);
            }
        }
        



        private bool KiemTraSoLuong()
        {
            if (!int.TryParse(txt_soluong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương!");
                txt_soluong.Focus();
                return false;
            }

            int soLuongTon = int.Parse(txt_soluongton.Text.Replace("Số lượng tồn: ", ""));
            if (soLuong > soLuongTon)
            {
                MessageBox.Show($"Số lượng không được vượt quá {soLuongTon}!");
                txt_soluong.Focus();
                return false;
            }

            return true;
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
          
            if (!KiemTraSoLuong())
                return;

            try
            {
                // Lấy thông tin từ form
                if (cbb_khachhang.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!");
                    return;
                }
                string maKH = cbb_khachhang.SelectedValue.ToString().Trim();

                DateTime ngayLap = dtp_ngaylap.Value.Date;
                string ghiChu = txt_ghichu.Text.Trim().Replace("'", "''");

                // Số lượng đặt
                int soLuong = int.Parse(txt_soluong.Text.Trim());

                // Lấy giá sản phẩm
                decimal giaGoc = decimal.Parse(txt_Gia.Text.Trim());
                decimal giaKhuyenMai = txt_giakm.Text.Trim() != "" ?
                                      decimal.Parse(txt_giakm.Text.Trim()) : giaGoc;

                decimal donGia = giaKhuyenMai;

                // Phí vận chuyển
                decimal phiVanChuyen = txt_phivanchuyen.Text.Trim() != "" ?
                                      decimal.Parse(txt_phivanchuyen.Text.Trim()) : 0;

                // Tính tổng tiền hàng
                decimal tongTienHang = donGia * soLuong;

                // Tính tổng thanh toán
                decimal tongThanhToan = tongTienHang + phiVanChuyen;

                // Lấy thông tin khách hàng cho đơn hàng
                string sqlGetKH = "SELECT HoTen, SoDienThoai, DiaChi FROM KhachHang WHERE IDKhachHang = '" + maKH + "'";
                DataTable dtKH = db.getDataTable(sqlGetKH);

                if (dtKH.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!");
                    return;
                }

                string tenNguoiNhan = dtKH.Rows[0]["HoTen"].ToString().Replace("'", "''");
                string sdt = dtKH.Rows[0]["SoDienThoai"].ToString().Replace("'", "''");
                string diaChi = dtKH.Rows[0]["DiaChi"].ToString().Replace("'", "''");

                // ✅ CHÍNH: Thêm đơn hàng VÀ LẤY IDDonHang NGAY
                string sqlInsertDH = @"INSERT INTO DonHang (
            IDKhachHang, IDNhanVien,
            TenNguoiNhan, DiaChiGiao, SoDienThoai,
            TongTienHang, PhiVanChuyen, TongThanhToan,
            TrangThai, NgayTao
        ) VALUES (
            '" + maKH + "', " +
                            "'" + IDND + "', " +
                            "N'" + tenNguoiNhan + "', " +
                            "N'" + diaChi + "', " +
                            "'" + sdt + "', " +
                            tongTienHang.ToString().Replace(",", ".") + ", " +
                            phiVanChuyen.ToString().Replace(",", ".") + ", " +
                            tongThanhToan.ToString().Replace(",", ".") + ", " +
                            "N'Đang xử lý', " +
                            "'" + ngayLap.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                        ");";

                // ✅ LẤY IDDonHang VỪA TẠO
                string sqlGetLastID = "SELECT IDENT_CURRENT('DonHang') AS LastID;";
                sqlInsertDH += sqlGetLastID;

                db.getNonQuery(sqlInsertDH);

                // ✅ LẤY IDDonHang (cách 2: nếu cách trên không hoạt động)
                object result = db.getScalar("SELECT IDENT_CURRENT('DonHang')");
                int idDonHang = Convert.ToInt32(result);

                if (idDonHang == 0)
                {
                    MessageBox.Show("Lỗi: Không thể lấy mã đơn hàng!");
                    return;
                }


                string sqlInsertCT = @"INSERT INTO ChiTiet_DonHang (
            IDDonHang, IDBienThe, SoLuong, DonGia
        ) VALUES (
            " + idDonHang + ", " +
                    "'" + IDBienThe + "', " +
                    soLuong + ", " +
                    donGia.ToString().Replace(",", ".") +
                ")";

                db.getNonQuery(sqlInsertCT);

                // ✅ Cập nhật số lượng tồn kho
                string sqlUpdateSL = "UPDATE HangHoa_BThe SET SoLuongTon = SoLuongTon - " + soLuong + " WHERE IDBienThe = '" + IDBienThe + "'";

                int rowsAffected = db.getNonQuery(sqlUpdateSL);

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy sản phẩm để cập nhật kho!");
                    return;
                }

                MessageBox.Show($"Lưu hóa đơn thành công!\n" +
                               $"Mã hóa đơn: {idDonHang}\n" +
                               $"Tổng tiền hàng: {tongTienHang:N0} VND\n" +
                               $"Phí vận chuyển: {phiVanChuyen:N0} VND\n" +
                               $"Tổng thanh toán: {tongThanhToan:N0} VND",
                               "Thành công");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
        



        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin sản phẩm
            HienThiThongTinSanPham();

            // Load danh sách khách hàng
            LoadDanhSachKhachHang();
         

            dtp_ngaylap.Value = DateTime.Now;
        }
       
        
    }
}

