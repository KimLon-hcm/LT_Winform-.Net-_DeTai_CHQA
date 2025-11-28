using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANCUOIKY
{
    class NguoiDung
    {
        DBConnection db = new DBConnection();




        public int IDNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTK { get; set; }
        public DateTime NgayTao { get; set; }

        public NguoiDung() { }

        public NguoiDung(int id, string hoten, string email, string sdt,
                         string diachi, string matkhau, string loaitk, DateTime ngaytao)
        {
            IDNguoiDung = id;
            HoTen = hoten;
            Email = email;
            SDT = sdt;
            DiaChi = diachi;
            MatKhau = matkhau;
            LoaiTK = loaitk;
            NgayTao = ngaytao;
        }



        public NguoiDung TimTaiKhoan(string Email)
        {
            NguoiDung tk = null; // Khởi tạo null để dễ kiểm tra
            // Lấy toàn bộ thông tin từ bảng Users
            string chuoitruyvan = "SELECT * FROM NguoiDung WHERE Email =  '" + Email + "' ";

            SqlDataReader Reader = db.ExcuteQuery(chuoitruyvan);

            if (Reader.Read())
            {
                tk = new NguoiDung(); // Tìm thấy mới khởi tạo đối tượng
                tk.IDNguoiDung = int.Parse(Reader["IDNguoiDung"].ToString()); // Cần lấy mã để truyền sang Form Main
                tk.HoTen = Reader["HoTen"].ToString();
                tk.SDT = Reader["SoDienThoai"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.Email = Reader["Email"].ToString(); // Cần lấy quyền để phân quyền
                tk.DiaChi = Reader["DiaChi"].ToString();
                tk.LoaiTK = Reader["LoaiTK"].ToString();
                tk.NgayTao = DateTime.Parse(Reader["NgayTao"].ToString());
            }
            Reader.Close(); // Nhớ đóng Reader sau khi dùng
            return tk;
        }

    }
}
