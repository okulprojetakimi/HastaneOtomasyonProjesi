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
        public int hastaId;
        public int ilacId;
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
                        using (SqlCommand komut = new SqlCommand("SELECT hasta_Id,hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastaTC", sqlBaglan))
                        {
                            komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                hastaId = veriOkuyucu.GetInt32(0);
                                string hastaIsim = veriOkuyucu.GetString(1);
                                string hastaSoyIsim = veriOkuyucu.GetString(2);

                                ilac_Hasta.Text = "İlaç eklenecek hasta: " + hastaIsim + " " + hastaSoyIsim;
                                ilac_HastaTc.Text = "İlaç eklenecek hastanın TCKN: " + hastaTcNum;
                            }

                        }
                        using (SqlCommand komut = new SqlCommand("SELECT ilacId FROM hastaIlac_tablosu WHERE hasta_Tc = @hastaTC", sqlBaglan))
                        {
                            komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                            SqlDataReader veriOkuyucu = komut.ExecuteReader();
                            while (veriOkuyucu.Read())
                            {
                                ilacId = veriOkuyucu.GetInt32(0);
                            }

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
            string random = new Random().Next(11111, 99999).ToString();
            using (SqlConnection vtBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                vtBaglan.Open();
                using (SqlCommand ilacEkleme = new SqlCommand("insert into hastaIlac_tablosu (hastailac_Id,hastailac_hastaId,hastailac_ilacId,hastailac_verilmeTarih,hasta_IlacDevamDurumu) values (@hastailac_Id,@hastailac_hastaId,@hastailac_ilacId,@hastailac_verilmeTarih,@hasta_IlacDevamDurumu)", vtBaglan))
                {
                    ilacEkleme.Parameters.AddWithValue("@hastailac_Id", random);
                    ilacEkleme.Parameters.AddWithValue("@hastailac_hastaId", hastaId);
                    ilacEkleme.Parameters.AddWithValue("hastailac_ilacId", ilacId);
                    ilacEkleme.Parameters.AddWithValue("@hastailac_verilmeTarih",DateTime.Parse(DateTime.Now.ToLongDateString()));
                    ilacEkleme.Parameters.AddWithValue("@hasta_IlacDevamDurumu", Request.Form["hasta_IlacDevamDurumu"]);
                    ilacEkleme.Dispose();
                    vtBaglan.Close();

                }
            }
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