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
        public int TrangThai { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public DateTime NgayTao { get; set; }

        public NguoiDung() { }

        public NguoiDung(int id, string hoten, string email, string sdt,
                         int trangthai, string matkhau, string vaitro, DateTime ngaytao)
        {
            IDNguoiDung = id;
            HoTen = hoten;
            Email = email;
            SDT = sdt;
            TrangThai = trangthai;
            MatKhau = matkhau;
            VaiTro = vaitro;
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
                //tk.TrangThai = bool.Parse(Reader["TrangThai"].ToString());
                tk.VaiTro = Reader["VaiTro"].ToString();
                tk.NgayTao = DateTime.Parse(Reader["NgayTao"].ToString());
            }
            Reader.Close(); // Nhớ đóng Reader sau khi dùng
            return tk;
        }

    }
}
