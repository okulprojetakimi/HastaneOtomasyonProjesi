using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.laboratuvarModulu
{
    public partial class laboratuvarModulEkle : System.Web.UI.Page
    {
        public string hastaId;
        public int personelId;
        public SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["hastaNumara"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                hastaId = HttpContext.Current.Request.QueryString["hastaNumara"];
                personelCek(sqlBaglan);

                sqlBaglan.Open();
                using (SqlCommand komut = new SqlCommand("SELECT personel_Id FROM personel_tablo", sqlBaglan))
                {
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    while (okuyucu.Read())
                    {
                        personelId = okuyucu.GetInt32(0);
                    }
                    sqlBaglan.Close();
                    komut.Dispose();
                    okuyucu.Close();

                }
            }
        }
            
        protected void labEkleButon_click(object sender, EventArgs e)
        {
            sqlBaglan.Open();
            int random = new Random().Next(1111, 9999);
            using (SqlCommand LabEkle = new SqlCommand("INSERT INTO laboratuvar_modul (tetkik_Id,tetkik_istekTarih,tetkik_isteyenDoktorID,tetkik_durum,hasta_IdNumarasi)  VALUES (@tetkik_Id,@tetkik_istekTarih,@tetkik_isteyenDoktorID,@tetkik_durum,@hasta_IdNumarasi)", sqlBaglan))
            {
                LabEkle.Parameters.AddWithValue("@tetkik_Id", random);
                LabEkle.Parameters.AddWithValue("@tetkik_istekTarih", DateTime.Parse(tetkik_istekTarih.Text));
                LabEkle.Parameters.AddWithValue("@tetkik_isteyenDoktorID", labPersonelSecimi.SelectedValue);
                LabEkle.Parameters.AddWithValue("@tetkik_durum", tetkik_durum.SelectedValue);
                LabEkle.Parameters.AddWithValue("@hasta_IdNumarasi", hastaId);
                LabEkle.ExecuteNonQuery();

                LabEkle.Dispose();
                sqlBaglan.Close();
                Response.Redirect("tetkikDetayEkleme.aspx?tetkikId=" + random);
            }
        }
        private void personelCek(SqlConnection baglanti)
        {
            baglanti.Open();
            using (SqlCommand veriGetir = new SqlCommand("SELECT personel_Id, personel_Isim, personel_Soyisim FROM personel_Tablo WHERE personel_Turu = 'Doktor'", baglanti))
            {
                SqlDataReader veriOkuyucu = veriGetir.ExecuteReader();
                while (veriOkuyucu.Read())
                {
                    ListItem yeniItem = new ListItem();
                    yeniItem.Text = veriOkuyucu.GetString(1) + veriOkuyucu.GetString(2);
                    yeniItem.Value = veriOkuyucu.GetInt32(0).ToString();
                    labPersonelSecimi.Items.Add(yeniItem);
                }
                veriOkuyucu.Close();
            }
            baglanti.Close();
        }

        protected void tetkik_AraButon_Click(object sender, EventArgs e)
        {
            sqlBaglan.Open();
            string query = "SELECT lm.tetkik_Id, lm.tetkik_istekTarih, pt.personel_Isim FROM laboratuvar_modul lm INNER JOIN personel_tablo pt ON lm.tetkik_isteyenDoktorID = pt.personel_Id WHERE lm.hasta_IdNumarasi = @hastaNumarasi AND lm.tetkik_istekTarih IS NOT NULL";
            using (SqlCommand cmd = new SqlCommand(query, sqlBaglan))
            {
                cmd.Parameters.AddWithValue("@hastaNumarasi", hastaId);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    tetkikListe.DataSource = dataTable;
                    tetkikListe.DataBind();
                }
            }
            sqlBaglan.Close();


        }

        protected void ara_Buton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/laboratuvarModulu/tetkikDetayEkleme.aspx?tetkikId=" + id_Degeri.Text);
        }
    }
}
