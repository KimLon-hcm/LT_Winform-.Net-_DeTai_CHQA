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
            NguoiDung tk = null;

            // Thêm COLLATE Latin1_General_CS_AS để phân biệt hoa thường
            string chuoitruyvan = @"SELECT * FROM NguoiDung 
                            WHERE Email COLLATE Latin1_General_CS_AS = @Email";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", Email)
            };

            SqlDataReader Reader = db.ExcuteQuery(chuoitruyvan, parameters);

            if (Reader.Read())
            {
                tk = new NguoiDung();
                tk.IDNguoiDung = int.Parse(Reader["IDNguoiDung"].ToString());
                tk.HoTen = Reader["HoTen"].ToString();
                tk.SDT = Reader["SoDienThoai"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.Email = Reader["Email"].ToString();
                tk.VaiTro = Reader["VaiTro"].ToString();
                tk.NgayTao = DateTime.Parse(Reader["NgayTao"].ToString());
            }
            Reader.Close();
            return tk;
        }
        public NguoiDung TimTaiKhoanSDT(string Sdt)
        {
            NguoiDung tk = null;

            string chuoitruyvan = "SELECT * FROM NguoiDung WHERE SoDienThoai =  '" + Sdt + "' ";

            SqlDataReader Reader = db.ExcuteQuery(chuoitruyvan);

            if (Reader.Read())
            {
                tk = new NguoiDung();
                tk.IDNguoiDung = int.Parse(Reader["IDNguoiDung"].ToString());
                tk.HoTen = Reader["HoTen"].ToString();
                tk.SDT = Reader["SoDienThoai"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.Email = Reader["Email"].ToString();

                tk.VaiTro = Reader["VaiTro"].ToString();
                tk.NgayTao = DateTime.Parse(Reader["NgayTao"].ToString());
            }
            Reader.Close();
            return tk;
        }

    }
}
