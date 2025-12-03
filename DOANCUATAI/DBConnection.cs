using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DOANCUOIKY
{
     class DBConnection
     {
          public SqlConnection conn;
          SqlCommand cmd;
           public string chuoiketnoi = @"Data Source=TNTA515\SQLEXPRESS;Initial Catalog=QLSHOPBANHANG_NET;Integrated Security=True";

          public DBConnection()
          {
               conn = new SqlConnection(chuoiketnoi);
          }
          public DBConnection(string chuoikn)
          {
               conn = new SqlConnection(chuoikn);
          }
          public void Open()
          {
               if (conn.State == ConnectionState.Closed)
                    conn.Open();
          }
          public void Close()
          {
               if (conn.State == ConnectionState.Open)
                    conn.Close();
          }

          public int CheckData(string chuoitruyvan)
          {
              Open();
              cmd = new SqlCommand(chuoitruyvan, conn);
              SqlDataReader dta = cmd.ExecuteReader();

              // Kiểm tra xem có dữ liệu hay không
              if (dta.HasRows)
              {
                  // Đóng DataReader
                  dta.Close();
                  Close();
                  return 1;
              }

              // Đóng DataReader và kết nối
              dta.Close();
              Close();
              return 0;
          }


          public int getNonQuery(string chuoitruyvan)
          {
               Open();
               SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
               int kq = cmd.ExecuteNonQuery();
               Close();
               return kq;
          }
          public object getScalar(string chuoitruyvan)//select countColumn name or number of supplied values does not match table definition.'

          {
               Open();
               SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
               //thực thi
               object kq = cmd.ExecuteScalar();
               Close();
               return kq;
          }
        public DataTable getDataTable(string chuoitruyvan)
        {
            DataTable dt = new DataTable();

            try
            {
                Open(); 

                SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
                da.Fill(dt);
            }
            finally
            {
                Close();
            }

            return dt;
        }

        public int updateDataTable(DataTable dt, string chuoitruyvan)
          {
               SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
               SqlCommandBuilder cb = new SqlCommandBuilder(da);
               int kq = da.Update(dt);
               return kq;
          }

          public int getQuery(string query)
          {
               Open();
               cmd = new SqlCommand(query, conn);
               int kq = cmd.ExecuteNonQuery();
               Close();
               return kq;
          }



        public List<NguoiDung> TaiKhoans(string query)
        {
            List<NguoiDung> taikhoan = new List<NguoiDung>();
            Open();
            cmd = new SqlCommand(query, conn);
            SqlDataReader dta = cmd.ExecuteReader();

            while (dta.Read())
            {
                taikhoan.Add(new NguoiDung(
                    int.Parse(dta["IDNguoiDung"].ToString()),
                    dta["HoTen"].ToString(),
                    dta["Email"].ToString(),
                    dta["SoDienThoai"].ToString(),
                    int.Parse(dta["TrangThai"].ToString()),
                    dta["MatKhau"].ToString(),
                    dta["VaiTro"].ToString(),
                    Convert.ToDateTime(dta["NgayTao"])
                ));
            }

            dta.Close();
            Close();
            return taikhoan;
        }


        public SqlDataReader ExcuteQuery(string sql)
          {
               Open();
               SqlCommand cmd = new SqlCommand(sql, conn);
               SqlDataReader rd = cmd.ExecuteReader();
               return rd;
          }
          public List<NguoiDung> NhanViens()
          {
               List<NguoiDung> nvs = new List<NguoiDung>();
               Open();
               SqlDataReader dta = ExcuteQuery("SELECT*FROM NguoiDung");
               while (dta.Read())
               {
                NguoiDung nv = new NguoiDung();
                    nv.IDNguoiDung = int.Parse(dta["IDNguoiDung"].ToString());
                    nvs.Add(nv);
               }
               return nvs;

          }
          public string getMaNVNext()
          {
               Open();
               List<NguoiDung> list = NhanViens();
               if (list.Count == 0)
               {
                    Close();
                    return "1";
               }
               else
               {
                    string MaMax = list[list.Count - 1].IDNguoiDung.ToString();
                    MaMax = MaMax.Substring(MaMax.Length - 3, 3);
                    int max = int.Parse(MaMax);
                    max++;
                    if (max < 10)
                    {
                         Close();
                         return  max.ToString();
                    }
                    else if (max < 100)
                    {
                         Close();
                         return  max.ToString();
                    }
                    Close();
                    return  max.ToString();
               }
          }
     }
}
