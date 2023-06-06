using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaBilgiGoruntule : System.Web.UI.Page
    {
        public string hastaId;
        public SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);

        protected void kaydet_Button_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                using (SqlCommand sqlcom = new SqlCommand("UPDATE hasta_kayitlar " +
                        "SET hasta_Tc = @hastaTc, hasta_Adi = @hastaAd, hasta_Soyadi = @hastaSoyadi, hasta_kanGrubu = @kangrubu, " +
                        "hasta_BabaAdi = @babaAd, hasta_AnneAdi = @anneAdi, hasta_DogumYeri = @dogumyeri, hasta_DogumTarihi = @dgumTa, hasta_Cinsiyet = " +
                        "@hastaCinsiyet, hasta_Adres = @adres, hasta_Eposta = @mail, hasta_faxNo = @fax, hasta_evTelefonu = @evtel, hasta_cepTelefonu = @ceptelefonu, " +
                        "hasta_sigortaTuru = @sigorta, hasta_karneNo = @karneno, hasta_sicilNo = @sicil, hasta_YakinAdi = @yakinadi, hasta_yakinlikDerecesi = @yakinlik, " +
                        "hasta_tedaviDurumu = @tedavidurum, hasta_tedaviTuru = @tedavitur WHERE hasta_Id = @hastaId", sqlcon))
                {
                    sqlcon.Open();
                    sqlcom.Parameters.AddWithValue("@hastaTc", hasta_Tc.Text);
                    sqlcom.Parameters.AddWithValue("@hastaAd", hasta_Adi.Text);
                    sqlcom.Parameters.AddWithValue("@hastaSoyadi", hasta_Soyadi.Text);
                    sqlcom.Parameters.AddWithValue("@kangrubu", hasta_kanGrubu.SelectedValue);
                    sqlcom.Parameters.AddWithValue("@babaAd", hasta_babaAd.Text);
                    sqlcom.Parameters.AddWithValue("@anneAdi", hasta_AnneAd.Text);
                    sqlcom.Parameters.AddWithValue("@dogumyeri", hasta_DogumYer.Text);
                    sqlcom.Parameters.AddWithValue("@dgumTa", Convert.ToDateTime(hasta_DogumTarihi.Text));
                    sqlcom.Parameters.AddWithValue("@hastaCinsiyet", hasta_Cinsiyet.Text);
                    sqlcom.Parameters.AddWithValue("@adres", hasta_Adres.Text.Trim());
                    sqlcom.Parameters.AddWithValue("@mail", hasta_Eposta.Text);
                    sqlcom.Parameters.AddWithValue("@fax", hasta_faxNo.Text);
                    sqlcom.Parameters.AddWithValue("@evtel", hasta_evTelefonu.Text);
                    sqlcom.Parameters.AddWithValue("@ceptelefonu", hasta_cepTelefonu.Text);
                    sqlcom.Parameters.AddWithValue("@sigorta", hasta_sigortaTuru.Text);
                    sqlcom.Parameters.AddWithValue("@karneno", hasta_karneNo.Text);
                    sqlcom.Parameters.AddWithValue("@sicil", hasta_sicilNo.Text);
                    sqlcom.Parameters.AddWithValue("@yakinadi", hasta_YakinAdi.Text);
                    sqlcom.Parameters.AddWithValue("@yakinlik", hasta_yakinlikDerecesi.Text);
                    sqlcom.Parameters.AddWithValue("@tedavidurum", hasta_tedaviDurumu.Text);
                    sqlcom.Parameters.AddWithValue("@tedavitur", hasta_tedaviTuru.Text);
                    sqlcom.Parameters.AddWithValue("@hastaId", hastaId);
                    sqlcom.ExecuteNonQuery();
                }
            }
        }

        private void FillHastaFields(SqlConnection sqlConnection, string hastaId)
        {
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM hasta_kayitlar WHERE hasta_Id = @hastaId", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaId", hastaId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hasta_Tc.Text = reader.GetString(1);
                        hasta_Adi.Text = reader.GetString(2);
                        hasta_Soyadi.Text = reader.GetString(3);
                        hasta_kanGrubu.SelectedValue = reader.GetInt32(4).ToString();
                        hasta_babaAd.Text = reader.GetString(5);
                        hasta_AnneAd.Text = reader.GetString(6);
                        hasta_DogumYer.Text = reader.GetString(7);
                        hasta_DogumTarihi.Text = reader.GetDateTime(8).ToString();
                        hasta_Cinsiyet.Text = reader.GetString(9);
                        hasta_Adres.Text = reader.GetString(10);
                        hasta_Eposta.Text = reader.GetString(11);
                        hasta_faxNo.Text = reader.GetString(12);
                        hasta_evTelefonu.Text = reader.GetString(13);
                        hasta_cepTelefonu.Text = reader.GetString(14);
                        hasta_sigortaTuru.Text = reader.GetString(15);
                        hasta_karneNo.Text = reader.GetString(16);
                        hasta_sicilNo.Text = reader.GetString(17);
                        hasta_YakinAdi.Text = reader.GetString(18);
                        hasta_yakinlikDerecesi.Text = reader.GetString(19);
                        hasta_tedaviDurumu.Text = reader.GetString(20);
                        hasta_tedaviTuru.Text = reader.GetString(21);
                    }
                }
            }
            sqlConnection.Close();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            using (erisimDuzey duzeyKontrol = new erisimDuzey())
            {
                if (HttpContext.Current.Request.QueryString["hastaNumarasi"] == null || !duzeyKontrol.yetkiKontrol("Danışman", Request.Cookies["erisimCookie"].Value))
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    hastaId = HttpContext.Current.Request.QueryString["hastaNumarasi"].ToString();
                    if (!IsPostBack)
                    {
                        FillHastaFields(sqlcon, hastaId);
                    }
                }
            }

            
        }
    }
}