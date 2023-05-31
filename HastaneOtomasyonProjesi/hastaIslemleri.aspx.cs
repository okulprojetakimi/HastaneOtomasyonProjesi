using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace HastaneOtomasyonProjesi
{
    public partial class hastaIslemleri : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    using (SqlCommand command = new SqlCommand("SELECT hasta_Tc, hasta_Adi, hasta_Soyadi, hasta_yakinAdi, hasta_tedaviDurumu FROM hasta_kayitlar", connection))
                    {
                        connection.Open();
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            enYeniOnHasta.DataSource = dataTable;
                            enYeniOnHasta.DataBind();
                        }
                        connection.Close();
                    }
                }
            } 
        }

        protected void hasta_Ara_Click(object sender, EventArgs e)
        {
            /* Arama için post işlemi yapılırsa */
            string hastaIsim = Request.Form["hastaIsmi"];
            string hastaSoyismi = Request.Form["hastaSoyismi"];

            using (SqlCommand command = new SqlCommand("SELECT TOP 5 hasta_Tc, hasta_Adi, hasta_Soyadi, hasta_yakinAdi, hasta_tedaviDurumu FROM hasta_kayitlar WHERE hasta_Adi = @hastaAd AND hasta_Soyadi = @hastaSoyad ORDER BY hasta_Tc DESC", connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@hastaAd", hastaIsim);
                command.Parameters.AddWithValue("@hastaSoyad", hastaSoyismi);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    enYeniOnHasta.DataSource = dataTable;
                    enYeniOnHasta.DataBind();
                }
                connection.Close();
            }
        }

        protected void yeniHastaEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("yeniHastaKaydi.aspx");
        }

        protected void hastaGoruntule_Buton_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaGoruntule.aspx?hasta=" + hasta_Tc_Numara.Text);
        }
    }
}