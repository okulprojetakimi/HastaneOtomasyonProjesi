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

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT personel_Id, personel_Tc, personel_Isim, personel_Soyisim, personel_Turu FROM personel_tablo WHERE personel_Isim LIKE @pIsim AND personel_Soyisim LIKE @pSoyisim", con))
                {
                    com.Parameters.AddWithValue("@pIsim", "%" + HttpContext.Current.Request.QueryString["personel_Isim"] + "%");
                    com.Parameters.AddWithValue("@pSoyisim", "%" + HttpContext.Current.Request.QueryString["personel_Soyisim"] + "%");
                    SqlDataReader veriOkuyucu = com.ExecuteReader();
                    DataTable tablo = new DataTable();
                    tablo.Load(veriOkuyucu);
                    string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                    con.Close();
                    Response.Write(json);
                }
            }
        }
    }
}