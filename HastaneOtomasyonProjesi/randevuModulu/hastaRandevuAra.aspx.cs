using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaRandevuAra : System.Web.UI.Page
    {
        protected void btnSearch_Click(object sender, EventArgs e)
        {

          
            {
           
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
                con.Open();

                // SQL sorgusu oluştur
                string sql = "SELECT Hasta.Ad, Hasta.Soyad, Hasta.TCKimlikNo, Hasta.DogumTarihi FROM Hasta INNER JOIN Randevu ON Hasta.HastaID = Randevu.HastaID WHERE Hasta.Ad LIKE @search OR Hasta.Soyad LIKE @search OR Hasta.TCKimlikNo LIKE @search";
    



        }
        }
}