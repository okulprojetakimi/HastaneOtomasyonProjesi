using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaNotGoruntuleme : System.Web.UI.Page
    {
        public int notIdNumarasi = Int32.Parse(HttpContext.Current.Request.QueryString["notIdNum"].ToString());
        public int hastaIdNumarasi;
        public string hastaNotVerisi;
        public DateTime hastaNotTarih;
        public string hastaAdi = "";
        public string hastaSoyadi = "";
        public string hastaTcNumarasi = "";
        public SqlConnection hastaVeriCek = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["notIdNum"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    hastaVeriCek.Open();
                    using (SqlCommand hastaIdGetir = new SqlCommand("SELECT hasta_Notlari.hasta_Not AS [Hasta Not], hasta_Notlari.hasta_Id AS [Hasta Id], hasta_Notlari.hasta_notTarihi AS [Hasta Not Tarihi], hasta_kayitlar.hasta_Adi AS [Hasta Adı], hasta_kayitlar.hasta_Soyadi AS [Hasta Soyadı], hasta_kayitlar.hasta_Tc AS [Hasta Tc] FROM hasta_Notlari, hasta_kayitlar WHERE hasta_notlari.hasta_NotId = @hNId AND hasta_Notlari.hasta_Id = hasta_kayitlar.hasta_Id;", hastaVeriCek))
                    {
                        hastaIdGetir.Parameters.AddWithValue("@hNId", notIdNumarasi);
                        using (SqlDataReader idOku = hastaIdGetir.ExecuteReader())
                        {
                            if (!idOku.HasRows)
                            {
                                Response.Redirect("/panel.aspx");
                            }
                            else
                            {
                                while (idOku.Read())
                                {
                                    hastaNotVerisi = idOku.GetString(0);
                                    hastaIdNumarasi = idOku.GetInt32(1);
                                    hastaNotTarih = idOku.GetDateTime(2);
                                    hastaAdi = idOku.GetString(3);
                                    hastaSoyadi = idOku.GetString(4);
                                    hastaTcNumarasi = idOku.GetString(5);
                                }
                            }
                            idOku.Close();
                        }
                        hastaVeriCek.Close();
                    }
                    hasta_TcLabel.Text = hastaTcNumarasi;
                    hasta_IsimSoyisim.Text = hastaAdi + " " + hastaSoyadi;
                    eski_Veri.Text = hastaNotVerisi;
                }
            }
            
        }
        /* Not güncelle buton */
        protected void hastaNot_Duzenle_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    hastaVeriCek.Open();
                    using (SqlCommand notDuzenleme = new SqlCommand("UPDATE hasta_Notlari SET hasta_Not = @hastaNotInput WHERE hasta_NotId = @hNotId", hastaVeriCek))
                    {
                        notDuzenleme.Parameters.AddWithValue("@hastaNotInput", eski_Veri.Text);
                        notDuzenleme.Parameters.AddWithValue("@hNotId", notIdNumarasi);
                        notDuzenleme.ExecuteNonQuery();
                        notDuzenleme.Dispose();
                        hastaVeriCek.Close();
                    }
                }
                catch (Exception damnError)
                {
                    Response.Write(damnError.Message);
                }
            }
        }

        protected void hasta_NotSil_butonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaNotSil.aspx?notIdNum="+notIdNumarasi);
        }
    }
}