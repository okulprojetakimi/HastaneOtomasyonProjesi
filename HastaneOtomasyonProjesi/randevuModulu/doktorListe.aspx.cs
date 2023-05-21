using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class doktorListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["poliklinikId"] != null)
                {
                    string poliklinikId = Request.QueryString["poliklinikId"];
                    using (SqlConnection sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlCn.Open();
                        using (SqlCommand sqlcom = new SqlCommand("SELECT personel_Id, personel_Isim, personel_Soyisim FROM personel_tablo WHERE personel_Bolum = @gelenParametre AND personel_Turu = 'Doktor' AND personel_IzinDurum = 0", sqlCn))
                        {
                            sqlcom.Parameters.AddWithValue("@gelenParametre", poliklinikId);
                            SqlDataReader veriOkuyucu = sqlcom.ExecuteReader();
                            DataTable veriTablosu = new DataTable();
                            
                            veriTablosu.Load(veriOkuyucu);
                            string jsonData = JsonConvert.SerializeObject(veriTablosu, Formatting.Indented);
                            Response.Write(jsonData);
                            veriOkuyucu.Close();
                            sqlCn.Close();
                            
                        }
                    }
                }
            }
        }
    }
}