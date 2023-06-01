using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class veriIslem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["bolumId"] != null)
                {
                    using (SqlConnection sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlCn.Open();
                        using (SqlCommand sqlcom = new SqlCommand("SELECT personel_Id, personel_Isim, personel_Soyisim FROM personel_tablo WHERE personel_Turu = 'Doktor' AND personel_Bolum = @gelenParametre AND personel_IzinDurum = 0", sqlCn))
                        {
                            sqlcom.Parameters.AddWithValue("@gelenParametre", HttpContext.Current.Request.QueryString["bolumId"]);
                            SqlDataReader veriOkuyucu = sqlcom.ExecuteReader();
                            DataTable veriTablosu = new DataTable();
                            veriTablosu.Load(veriOkuyucu);
                            string jsonData = JsonConvert.SerializeObject(veriTablosu, Formatting.Indented);
                            veriOkuyucu.Close();
                            sqlCn.Close();
                            Response.Write(jsonData);
                        }
                    }
                }
                else
                {
                    Response.Redirect("/panel.aspx");
                }
                
            }
        }
    }
}