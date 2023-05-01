using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                hastaTcNum = HttpContext.Current.Request.QueryString["hasta"];
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