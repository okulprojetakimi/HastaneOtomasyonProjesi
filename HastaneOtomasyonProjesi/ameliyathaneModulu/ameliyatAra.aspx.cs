using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace HastaneOtomasyonProjesi.ameliyathaneModulu
{
    public partial class ameliyatAra : System.Web.UI.Page
    {
        public string hastaTckn = "";

        private void veriCekme()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlCon.Open();
                    int hastaIdNUm;

                    using (SqlCommand IDcek = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @tcParam", sqlCon))
                    {
                        IDcek.Parameters.AddWithValue("@tcParam", hastaTckn);
                        SqlDataReader okuyucu = IDcek.ExecuteReader();
                        okuyucu.Read();
                        hastaIdNUm = okuyucu.GetInt32(0);
                        okuyucu.Close();
                        IDcek.Dispose();
                    }
                    using (SqlCommand veriCek = new SqlCommand("SELECT ameliyathane_Tablo.ameliyatId, ameliyathane_Tablo.ameliyatGirisTarihi, ameliyathane_Tablo.ameliyatCikisTarihi, personel_tablo.personel_Isim,personel_tablo.personel_Soyisim, hasta_kayitlar.hasta_Adi,hasta_kayitlar.hasta_Soyadi FROM ameliyathane_Tablo, hasta_kayitlar, personel_tablo WHERE ameliyathane_Tablo.ameliyatPersonelId = personel_tablo.personel_Id AND ameliyathane_Tablo.ameliyatHastaId = hasta_kayitlar.hasta_Id AND hasta_kayitlar.hasta_Id = @IDParam", sqlCon))
                    {
                        veriCek.Parameters.AddWithValue("@IDParam", hastaIdNUm);
                        SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                        DataTable ameliyatTablo = new DataTable();
                        ameliyatTablo.Load(veriOkuyucu);
                        string json = JsonConvert.SerializeObject(ameliyatTablo, Formatting.Indented);
                        veriOkuyucu.Close();
                        sqlCon.Close();
                        Response.Write(json);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["hastaTcKn"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    /*
                Ameliyat Numarası
                Ameliyat Giriş Tarihi
                Ameliyat Çıkış Tarihi
                Ameliyat Personel Numarası
                Ameliyat Hasta Numarası
                     */
                    hastaTckn = HttpContext.Current.Request.QueryString["hastaTcKn"].ToString();
                    veriCekme();
                }
            }
        }
    }
}