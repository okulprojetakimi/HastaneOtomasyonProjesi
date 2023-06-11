using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class hastaRandevuGoruntule : System.Web.UI.Page
    {
        public int hastaId;
        public string randevuId = HttpContext.Current.Request.QueryString["randevuNumara"];
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisim = new erisimDuzey())
            {
                if (kontrolCookie == null || kontrolCookie.Value.Trim() == "" || HttpContext.Current.Request.QueryString["randevuNumara"] != null)
                {
                    Response.Redirect("/panel.aspx");
                }
                if (!IsPostBack)
                {
                    using (SqlConnection bag = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        bag.Open();

                        string randevuQuery = "SELECT r.randevuId, r.hastaId, p.pIsim AS PoliklinikAdi , p.pId , r.randevuTarih, r.randevuSaat, r.randevuNot, pr.personel_Isim, pr.personel_Soyisim, pr.personel_Id " +
                                              "FROM randevu_modulu AS r " +
                                              "INNER JOIN poliklinik_Tablo AS p ON r.randevuPoliklinik = p.pId " +
                                              "INNER JOIN personel_tablo AS pr ON r.randevuDoktor = pr.personel_Id " +
                                              "WHERE r.randevuId = @randevuId";

                        using (SqlCommand randevuCommand = new SqlCommand(randevuQuery, bag))
                        {

                            randevuCommand.Parameters.AddWithValue("@randevuId", randevuId);

                            using (SqlDataReader reader = randevuCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string poliklinik = reader["PoliklinikAdi"].ToString();
                                    int poliklinikId = Convert.ToInt32(reader["pId"]);
                                    DateTime tarih = Convert.ToDateTime(reader["randevuTarih"]);
                                    string saat = reader["randevuSaat"].ToString();
                                    string notlar = reader["randevuNot"].ToString();
                                    string doktorIsim = reader["personel_Isim"].ToString();
                                    string doktorSoyisim = reader["personel_Soyisim"].ToString();
                                    int doktorId = Convert.ToInt32(reader["personel_Id"]);

                                    reader.Close();

                                    randevuTarih.Value = tarih.ToString("yyyy-MM-dd");
                                    randevuSaat.Text = saat;
                                    randevuNot.Text = notlar;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void randevu_Guncelle_Click(object sender, EventArgs e)
        {

            //int poliklinikId = Convert.ToInt32(randevuPoliklinik.SelectedValue);
            //string tarih = randevuTarih.Value;
            //string saat = randevuSaat.Text;
            //string notlar = randevuNot.Text;
            //int doktorId = Convert.ToInt32(randevuDoktor.SelectedValue);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                con.Open();

                if (IsPostBack)
                {
                    string updateQuery = "UPDATE randevu_modulu SET randevuPoliklinik = @poliklinikId, randevuTarih = @tarih, randevuSaat = @saat, randevuNot = @notlar, randevuDoktor = @doktorId WHERE randevuId = @randevuId";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                    {
                        updateCommand.Parameters.AddWithValue("@poliklinikId", secilenPoliklinik.Value);
                        updateCommand.Parameters.AddWithValue("@tarih", randevuTarih.Value);
                        updateCommand.Parameters.AddWithValue("@saat", randevuSaat.Text);
                        updateCommand.Parameters.AddWithValue("@notlar", randevuNot.Text);
                        updateCommand.Parameters.AddWithValue("@doktorId", secilenDoktor.Value);
                        updateCommand.Parameters.AddWithValue("@randevuId", HttpContext.Current.Request.QueryString["randevuNumara"]);

                        updateCommand.ExecuteNonQuery();
                        con.Close();
                    }
                    
                }
            }
        }



    }
}
