using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class personelEkle : System.Web.UI.Page
    {
        public int pIsim;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }

        }
        protected void personelEkleButon_click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            { 
                sqlBaglantisi.Open();
                int random = new Random().Next(1111, 9999);
                using (SqlCommand personelEkleme = new SqlCommand("INSERT INTO personel_tablo (personel_Id,personel_Isim,personel_Soyisim,personel_Telefon,personel_Eposta,personel_SicilNo,personel_Bolum,personel_SozlesmeTipi,personel_kanGrubu,personel_ikametAdres,personel_Turu,personel_IzinDurum,personel_Tc) VALUES (@personel_Id,@personel_Isim,@personel_Soyisim,@personel_Telefon,@personel_Eposta,@personel_SicilNo,@personel_Bolum,@personel_SozlesmeTipi,@personel_kanGrubu,@personel_ikametAdres,@personel_Turu,@personel_IzinDurum,@personel_Tc)", sqlBaglantisi))
                {
                    personelEkleme.Parameters.AddWithValue("@personel_Id", random);
                    personelEkleme.Parameters.AddWithValue("personel_Isim", personel_Isim.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_Soyisim", personel_Soyisim.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_Telefon", personel_Telefon.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_Eposta", personel_Eposta.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_SicilNo", personel_SicilNo.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_Bolum", secilenPoliklinik.Value);
                    personelEkleme.Parameters.AddWithValue("@personel_SozlesmeTipi", personel_SozlesmeTipi.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_kanGrubu", Request.Form["personel_kanGrubu"]);
                    personelEkleme.Parameters.AddWithValue("@personel_ikametAdres", personel_ikametAdres.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_Turu", personel_Turu.SelectedItem.Text);
                    personelEkleme.Parameters.AddWithValue("@personel_IzinDurum", false);
                    personelEkleme.Parameters.AddWithValue("@personel_Tc", personel_Tc.Text);



                    personelEkleme.ExecuteNonQuery();
                    personelEkleme.Dispose();
                    sqlBaglantisi.Close();
                }
            }
        }
    }
}