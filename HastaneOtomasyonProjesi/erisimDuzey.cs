using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace HastaneOtomasyonProjesi
{
    public class erisimDuzey : IDisposable
    {
        private SqlConnection sqlCon;

        public erisimDuzey()
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        }

        public bool yetkiKontrol(string yetkiDuzeyi, string erisimKodu)
        {
            using (SqlCommand sqlcom = new SqlCommand("SELECT personel_tablo.personel_Turu FROM personel_tablo, personel_kullaniciHesap WHERE personel_tablo.personel_Id = personel_kullaniciHesap.personelId AND personel_kullaniciHesap.personel_ErisimKodu = @erisimKodu", sqlCon))
            {
                sqlCon.Open();
                sqlcom.Parameters.AddWithValue("@erisimKodu", erisimKodu);
                object result = sqlcom.ExecuteScalar();
                string mevcut = result != null ? result.ToString().Trim() : string.Empty;

                sqlCon.Close();

                if (mevcut == yetkiDuzeyi || mevcut == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Dispose();
            }
        }
    }
}
