using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaGoruntule : System.Web.UI.Page
    {
        public string mainTckn = "";

        private void notListesiGetir()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                string query = "SELECT hasta_NotId, hasta_Not, hasta_notTarihi FROM hasta_Notlari";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                hastaNotListesi.DataSource = dataTable;
                hastaNotListesi.DataBind();
                command.Dispose();
                connection.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
         {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/panel.aspx");
            }
            try
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    notListesiGetir();
                    mainTckn = HttpContext.Current.Request.QueryString["hasta"].ToString();
                    using (SqlConnection sqlCom = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlCom.Open();
                        using (SqlCommand hastaKontrol = new SqlCommand("SELECT * FROM hasta_kayitlar WHERE hasta_Tc = @hastaTckn", sqlCom))
                        {
                            hastaKontrol.Parameters.AddWithValue("@hastaTckn", mainTckn);
                            SqlDataReader veriOkuyucu = hastaKontrol.ExecuteReader();
                            veriOkuyucu.Read();
                            

                            if (!veriOkuyucu.HasRows)
                            {
                                veriOkuyucu.Close();
                                sqlCom.Close();
                                Response.Redirect("hastaIslemleri.aspx");  
                            }

                        }
                    }
                }
            }
            catch (Exception damnError)
            {
                Response.Write(damnError.Message);
            }
        }

        protected void hastaIlacEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastailacEkleme.aspx?hasta="+mainTckn);
        }

        protected void hastaNotEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastayaNotEkle.aspx?hasta="+mainTckn);
        }

        protected void notGoruntuleButonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaNotGoruntuleme.aspx?notIdNum="+ not_Id.Text);
        }
    }
}