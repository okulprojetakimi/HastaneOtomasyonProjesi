using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.randevuModulu
{
    public partial class hastaRandevuGoruntule : System.Web.UI.Page
    {
        public int hastaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string connectionString = ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString;
                {

                    string query = "SELECT rm.randevuId, rm.hastaId, pt.pIsim AS randevuPoliklinik, rm.randevuTarih, rm.randevuSaat, rm.randevuNot, rm.randevuDurumu, CONCAT(pt2.personel_Isim, ' ', pt2.personel_Soyisim) AS randevuDoktor " +
                           "FROM randevu_modulu rm " +
                           "INNER JOIN poliklinik_tablo pt ON rm.randevuPoliklinik = pt.pId " +
                           "INNER JOIN personel_tablo pt2 ON rm.randevuDoktor = pt2.personel_Id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }

            }
        }

        protected void detayGor_Buton_Click(object sender, EventArgs e)
        {
            using (SqlConnection bag = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                bag.Open();
                string hastaTc = hastaTcInput.Text;
              
                string hastaIdQuery = "SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @hastaTc";
                using (SqlCommand command = new SqlCommand(hastaIdQuery, bag))
                {
                    command.Parameters.AddWithValue("@hastaTc", hastaTc);
                    int hastaId = (int)command.ExecuteScalar();

                    
                    string randevuQuery = "SELECT r.randevuId, r.hastaId, p.pIsim AS PoliklinikAdi, r.randevuTarih, r.randevuSaat, r.randevuNot, pr.personel_Isim, pr.personel_Soyisim FROM randevu_modulu AS r INNER JOIN poliklinik_Tablo AS p ON r.randevuPoliklinik = p.pId INNER JOIN personel_tablo AS pr ON r.randevuDoktor = pr.personel_Id WHERE r.hastaId = @hastaId";
                    using (SqlCommand randevuCommand = new SqlCommand(randevuQuery, bag))
                    {
                        randevuCommand.Parameters.AddWithValue("@hastaId", hastaId);
                        SqlDataReader reader = randevuCommand.ExecuteReader();

                        
                        while (reader.Read())
                        {
                            string randevuId = reader["randevuId"].ToString();
                            string poliklinik = reader["PoliklinikAdi"].ToString();
                            string tarih = reader["randevuTarih"].ToString();
                            string saat = reader["randevuSaat"].ToString();
                            string notlar = reader["randevuNot"].ToString();
                            string doktorIsim = reader["personel_Isim"].ToString();
                            string doktorSoyisim = reader["personel_Soyisim"].ToString();

                            randevuPoliklinik.Text = poliklinik;
                            randevuTarih.Text = tarih.ToString();
                            randevuSaat.Text = saat.ToString();
                            randevuNot.Text = notlar;
                            randevuDoktor.Text = doktorIsim + " " + doktorSoyisim;
                        }


                        reader.Close();
                    }
                }








            }
        }

    }
}