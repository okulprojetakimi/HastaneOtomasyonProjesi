using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastayaNotEkle : System.Web.UI.Page
    {
        /* Global Variables*/
        public string mainTCKN = "";
        public string hastaIsim = "";
        public string hastaSoyisim = "";
        public int hastaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                mainTCKN = HttpContext.Current.Request.QueryString["hasta"].ToString();
                hasta_TcLabel.Text = mainTCKN;
                using (SqlConnection sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlCn.Open();
                    using (SqlCommand idCek = new SqlCommand("SELECT hasta_Id, hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastatcnum", sqlCn))
                    {
                        idCek.Parameters.AddWithValue("@hastatcnum", mainTCKN);
                        SqlDataReader tabloOkuyucu = idCek.ExecuteReader();
                        while (tabloOkuyucu.Read())
                        {
                            hastaId = tabloOkuyucu.GetInt32(0);
                            hastaIsim = tabloOkuyucu.GetString(1);
                            hastaSoyisim = tabloOkuyucu.GetString(2);
                        }
                        tabloOkuyucu.Close();
                        sqlCn.Close();
                    }
                }
                hasta_IsimSoyisim.Text = hastaIsim + " " + hastaSoyisim;
            }
        }

        /* Hastaya Not Ekleme */
        protected void hastaNot_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string notId = new Random().Next(11111, 99999).ToString();
                using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    vtBaglan.Open();
                    using (SqlCommand notEklemeKomutu = new SqlCommand("INSERT INTO hasta_Notlari (hasta_NotId, hasta_Not, hasta_notTarih, hasta_Id) VALUES (@hastaIdNumarasi, @hastaNotYazisi, @hastaNotTarihi, @hastaId)", vtBaglan))
                    {
                        notEklemeKomutu.Parameters.AddWithValue("@hastaIdNumarasi", notId);
                        notEklemeKomutu.Parameters.AddWithValue("@hastaNotYazisi", hastaNotu.Text);
                        notEklemeKomutu.Parameters.AddWithValue("@hastaNotTarihi", DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString());
                        notEklemeKomutu.Parameters.AddWithValue("@hastaId", hastaId);
                        notEklemeKomutu.Dispose();
                        vtBaglan.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            Response.Write("<script>alert('OKEY!')</script>");
        }
    }
}