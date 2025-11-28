using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DOANCUATAI
{
    class Users
    {
        // Đảm bảo các thuộc tính public để truy xuất được từ bên ngoài
        public string Manhanvien { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string TrangThaiQuyen { get; set; } // ADMIN, SALE, KHO

        DBConnection db = new DBConnection();

        public Users() { }

        public Users(string tenTaiKhoan, string matKhau)
        {
            this.TenDN = tenTaiKhoan;
            this.MatKhau = matKhau;
        }

        public Users TimTaiKhoan(string tentk)
        {
            Users tk = null; // Khởi tạo null để dễ kiểm tra
            // Lấy toàn bộ thông tin từ bảng Users
            string chuoitruyvan = "SELECT * FROM Users WHERE TenDangNhap = '" + tentk + "'";

            SqlDataReader Reader = db.ExcuteQuery(chuoitruyvan);

            if (Reader.Read())
            {
                tk = new Users(); // Tìm thấy mới khởi tạo đối tượng
                tk.Manhanvien = Reader["MaNhanVien"].ToString(); // Cần lấy mã để truyền sang Form Main
                tk.TenDN = Reader["TenDangNhap"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.TrangThaiQuyen = Reader["TrangThaiQuyen"].ToString(); // Cần lấy quyền để phân quyền
            }
            Reader.Close(); // Nhớ đóng Reader sau khi dùng
            return tk;
        }
    }
}