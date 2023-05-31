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
using System.IO;
using System.Text;

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class personelPlanGoruntule : System.Web.UI.Page
    {

        public string listeId = HttpContext.Current.Request.QueryString["listeid"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["listeid"]))
                {
                    if (int.TryParse(Request.QueryString["listeid"], out int parsedListeId))
                    {
                        BindGridView(parsedListeId);
                    }
                }
            }
        }

       



        private void BindGridView(int listeId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString;
            string query = "SELECT cpt.calismaListeId, cpt.personelId, pt.personel_Isim AS İsim, pt.personel_Soyisim AS Soyisim, cpt.personelCalismaTarih AS 'Çalışma Tarihi', cpt.g1 AS Gün1, cpt.g2 AS Gün2, cpt.g3 AS Gün3, cpt.g4 AS Gün4, cpt.g5 AS Gün5, cpt.g6 AS Gün6, cpt.g7 AS Gün7, cpt.g8 AS Gün8, cpt.g9 AS Gün9, cpt.g10 AS Gün10, cpt.g11 AS Gün11, cpt.g12 AS Gün12, cpt.g13 AS Gün13, cpt.g14 AS Gün14, cpt.g15 AS Gün15, cpt.g16 AS Gün16, cpt.g17 AS Gün17, cpt.g18 AS Gün18, cpt.g19 AS Gün19, cpt.g20 AS Gün20, cpt.g21 AS Gün21, cpt.g22 AS Gün22, cpt.g23 AS Gün23, cpt.g24 AS Gün24, cpt.g25 AS Gün25, cpt.g26 AS Gün26, cpt.g27 AS Gün27, cpt.g28 AS Gün28, cpt.g29 AS Gün29, cpt.g30 AS Gün30, cpt.g31 AS Gün31 FROM calisanPersonelTablosu cpt INNER JOIN personel_tablo pt ON cpt.personelId = pt.personel_Id WHERE cpt.calismaListeId = @ListeId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", listeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                dataTable.Columns.Remove("calismaListeId");
                dataTable.Columns.Remove("personelId");
                connection.Close();

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["listeid"]))
            {
                if (int.TryParse(Request.QueryString["listeid"], out int parsedListeId))
                {
                    SilVeriyi(parsedListeId);
                }
            }
        }
        private void SilVeriyi(int listeId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString;
            string query = "DELETE FROM calisanPersonelTablosu WHERE calismaListeId = @ListeId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", listeId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            Response.Redirect("personelPlanGoruntule.aspx?listeid=" + listeId);
        }

        protected void excel_Aktar_Click(object sender, EventArgs e)
        {
        }
    }


}
