using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace HastaneOtomasyonProjesi
{
    public partial class hastailacEkleme : System.Web.UI.Page
    {
        public string hastaTcNum;

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
                else
                {
                    hastaTcNum = HttpContext.Current.Request.QueryString["hasta"];
                    using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBaglan.Open();
                        using (SqlCommand komut = new SqlCommand("SELECT hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastaTC", sqlBaglan))
                        {
                            komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                string hastaIsim = veriOkuyucu.GetString(0);
                                string hastaSoyIsim = veriOkuyucu.GetString(1);
                                ilac_Hasta.Text = "İlaç eklenecek hasta: " + hastaIsim + " "+ hastaSoyIsim;
                                ilac_HastaTc.Text = "İlaç eklenecek hastanın TCKN: " + hastaTcNum;
                            }
                            komut.Dispose();
                            sqlBaglan.Close();
                        }
                        
                    }
                    
                }
            }
        }

        /* İlaç arama / listeleme butonu */
        protected void ilacIsmiAraButonu_Click(object sender, EventArgs e)
        {
            
        }

        /* Hastaya ilaç ekleme butonu */
        protected void hastaIlac_Ekle_Click(object sender, EventArgs e)
        {
            
        }

        protected void ilac_AramaButonu_Click(object sender, EventArgs e)
        {
            using (SqlConnection veritabaniBaglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                veritabaniBaglanti.Open();
                using (SqlCommand veriCek = new SqlCommand("SELECT * FROM ilaclar_tablosu WHERE ilacIsmi LIKE @parametre", veritabaniBaglanti))
                {
                    veriCek.Parameters.AddWithValue("@parametre", "%" + aranacak_Ilac.Text + "%");
                    SqlDataReader veriOkuyucu = veriCek.ExecuteReader();
                    if (!veriOkuyucu.HasRows)
                    {
                        Response.Write("İlaç bulunamadı!");
                    }
                    // Verileri GridView'e bağlıyoruz
                    ilacListesi.DataSource = veriOkuyucu;
                    ilacListesi.DataBind();
                    veriOkuyucu.Close();
                    veriCek.Dispose();
                    veritabaniBaglanti.Close();
                }
            }
        }
    }
}