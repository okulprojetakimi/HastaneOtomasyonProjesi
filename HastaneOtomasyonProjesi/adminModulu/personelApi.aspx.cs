using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.adminModulu
{
    public partial class personelApi : System.Web.UI.Page
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
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand personelDataCek = new SqlCommand("SELECT personel_Id, personel_Tc, personel_Isim, personel_Soyisim, personel_Turu FROM personel_tablo WHERE personel_Isim LIKE @pIsim AND personel_Soyisim LIKE @pSoyisim", sqlcon))
                    {
                        personelDataCek.Parameters.AddWithValue("@pIsim", "%" + HttpContext.Current.Request.QueryString["isim"] + "%");
                        personelDataCek.Parameters.AddWithValue("@pSoyisim", "%" + HttpContext.Current.Request.QueryString["soyisim"] + "%");
                        SqlDataReader veriOkuyucu = personelDataCek.ExecuteReader();
                        DataTable tablo = new DataTable();
                        tablo.Load(veriOkuyucu);
                        string jsonPersonelData = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                        veriOkuyucu.Close();
                        sqlcon.Close();
                        Response.Write(jsonPersonelData);
                    }
                }
            }
        }
    }
}