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
                    using (SqlConnection sqlBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlBagla.Open();
                        using (SqlCommand tabloGuncelleKomutu = new SqlCommand("SELECT ilacId, ilacIsmi, ilacreceteTuru, ilacFiyat FROM ilaclar_tablosu ORDER BY ilacId DESC", sqlBagla))
                        {
                            SqlDataAdapter veriKaynagi = new SqlDataAdapter(tabloGuncelleKomutu);
                            DataTable veriTablosu = new DataTable();
                            veriKaynagi.Fill(veriTablosu);
                            ilacListesiTablo.DataSource = veriTablosu;
                            ilacListesiTablo.DataBind();
                            tabloGuncelleKomutu.Dispose();
                            sqlBagla.Close();
                        }
                    }
                }
            }
        }

        /* İlaç arama / listeleme butonu */
        protected void ilacIsmiAraButonu_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBagla = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBagla.Open();
                using (SqlCommand tabloGuncelleKomutu = new SqlCommand("SELECT ilacId, ilacIsmi, ilacreceteTuru, ilacFiyat FROM ilaclar_tablosu WHERE ilacIsmi = LIKE '%@ilacIsmiArama%'", sqlBagla))
                {
                    tabloGuncelleKomutu.Parameters.AddWithValue("@ilacIsmiArama", ilacIsmi);
                    SqlDataAdapter veriKaynagi = new SqlDataAdapter(tabloGuncelleKomutu);
                    DataTable veriTablosu = new DataTable();
                    veriKaynagi.Fill(veriTablosu);
                    ilacListesiTablo.DataSource = veriTablosu;
                    ilacListesiTablo.DataBind();
                    tabloGuncelleKomutu.Dispose();
                    sqlBagla.Close();
                }
            }
        }

        /* Hastaya ilaç ekleme butonu */
        protected void hastaIlac_Ekle_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglantisi.Open();
                using (SqlCommand hastaIlacEkleme = new SqlCommand("insert into hastaIlac_tablosu (hastailac_Id,hastailac_hastaId,hastailac_ilacId,hastailac_verilmeTarih) values (@hastailac_Id,@hastailac_hastaId,@hastailac_ilacId,@hastailac_verilmeTarih)", sqlBaglantisi))
                {

                }
            }
        }
    }
}