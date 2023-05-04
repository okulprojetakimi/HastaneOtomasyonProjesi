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
                using (SqlCommand ilacEkleme = new SqlCommand("INSERT INTO hastaIlac_tablosu (hastailac_Id,hastailac_hastaId,hastailac_ilacId,hastailac_verilmeTarih,hasta_IlacDevamDurumu) values (@hastailac_Id,@hastailac_hastaId,@hastailac_ilacId,@hastailac_verilmeTarih,@hasta_IlacDevamDurumu)", vtBaglan))
                {
                    ilacEkleme.Parameters.AddWithValue("@hastailac_Id", random);
                    ilacEkleme.Parameters.AddWithValue("@hastailac_hastaId", hastaId);
                    ilacEkleme.Parameters.AddWithValue("hastailac_ilacId", ilacIdNum.Text);
                    ilacEkleme.Parameters.AddWithValue("@hastailac_verilmeTarih",DateTime.Parse(DateTime.Now.ToLongDateString()));
                    ilacEkleme.Parameters.AddWithValue("@hasta_IlacDevamDurumu", 1);
                    ilacEkleme.ExecuteNonQuery();
                    ilacEkleme.Dispose();
                    vtBaglan.Close();

                }
            }
        }

    }
}