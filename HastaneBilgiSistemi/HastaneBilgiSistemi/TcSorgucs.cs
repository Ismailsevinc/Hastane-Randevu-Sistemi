using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Numerics;

namespace HastaneBilgiSistemi
{
    public class TcSorgu
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-471QMFA;Initial Catalog=hastane;Integrated Security=True");
        public bool yap(string tc)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select * from kisiler where Tckimlik=@tckimlik", baglanti);
                cmd.Parameters.AddWithValue("@tckimlik", tc.ToString());
                using (SqlDataReader oku= cmd.ExecuteReader())
                {
                    return oku.HasRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return false; 

            }
            finally { baglanti.Close(); }
           
            
        }
     
    }
}
