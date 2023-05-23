using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class planArama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlcon.Open();
                using (SqlCommand com = new SqlCommand("SELECT calismaPlaniListeId, calismaPlaniPersonelId FROM calismaPlaniTablosu WHERE calismaPlaniPersonelId = @pId AND calismaPlaniTarih = @pTarih", sqlcon))
                {
                    com.Parameters.AddWithValue("@pId", HttpContext.Current.Request.QueryString["personel_Numara"]);
                    com.Parameters.AddWithValue("@pTarih", DateTime.Parse(HttpContext.Current.Request.QueryString["plan_Tarih"]).Date);
                    SqlDataReader veriOkuyucu = com.ExecuteReader();
                    DataTable tablo = new DataTable();
                    tablo.Load(veriOkuyucu);
                    string json = JsonConvert.SerializeObject(tablo, Formatting.Indented);
                    sqlcon.Close();
                    Response.Write(json);
                }
            }
        }
    }
}