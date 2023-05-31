using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaGoruntule : System.Web.UI.Page
    {
        public string mainTckn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["hasta"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                mainTckn = HttpContext.Current.Request.QueryString["hasta"].ToString();
                LoadData();
            }
        }

        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                int hastaId = GetHastaId(sqlConnection);
                if (hastaId == -1)
                {
                    Response.Redirect("hastaIslemleri.aspx");
                }
                else
                {
                    FillHastaFields(sqlConnection, hastaId);
                    BindNotListesi(sqlConnection, hastaId);
                    BindTetkikCek(sqlConnection, hastaId);
                    BindIlacVerisi(sqlConnection, hastaId);
                }
            }
        }

        private int GetHastaId(SqlConnection sqlConnection)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @hastaTckn", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaTckn", mainTckn);
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }

        private void FillHastaFields(SqlConnection sqlConnection, int hastaId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM hasta_kayitlar WHERE hasta_Id = @hastaId", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaId", hastaId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hasta_Tc.Text = reader.GetString(1);
                        hasta_Adi.Text = reader.GetString(2);
                        hasta_Soyadi.Text = reader.GetString(3);
                        hasta_kanGrubu.SelectedValue = reader.GetInt32(4).ToString();
                        hasta_babaAd.Text = reader.GetString(5);
                        hasta_AnneAd.Text = reader.GetString(6);
                        hasta_DogumYer.Text = reader.GetString(7);
                        hasta_DogumTarihi.Text = reader.GetDateTime(8).ToString();
                        hasta_Cinsiyet.Text = reader.GetString(9);
                        hasta_Adres.Text = reader.GetString(10);
                        hasta_Eposta.Text = reader.GetString(11);
                        hasta_faxNo.Text = reader.GetString(12);
                        hasta_evTelefonu.Text = reader.GetString(13);
                        hasta_cepTelefonu.Text = reader.GetString(14);
                        hasta_sigortaTuru.Text = reader.GetString(15);
                        hasta_karneNo.Text = reader.GetString(16);
                        hasta_sicilNo.Text = reader.GetString(17);
                        hasta_YakinAdi.Text = reader.GetString(18);
                        hasta_yakinlikDerecesi.Text = reader.GetString(19);
                        hasta_tedaviDurumu.Text = reader.GetString(20);
                        hasta_tedaviTuru.Text = reader.GetString(21);
                    }
                }
            }
        }

        private void BindNotListesi(SqlConnection sqlConnection, int hastaId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT hasta_NotId, hasta_Not, hasta_notTarihi FROM hasta_Notlari WHERE hasta_Id = @hastaNumarasi", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaNumarasi", hastaId);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    hastaNotListesi.DataSource = dataTable;
                    hastaNotListesi.DataBind();
                }
            }
        }

        private void BindTetkikCek(SqlConnection sqlConnection, int hastaId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT lm.tetkik_Id, lm.tetkik_istekTarih, pt.personel_Isim, lm.tetkik_sonucTarih, lm.tetkik_durum FROM laboratuvar_modul lm INNER JOIN personel_tablo pt ON lm.tetkik_isteyenDoktorID = pt.personel_Id WHERE lm.hasta_IdNumarasi = @hastaNumarasi", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaNumarasi", hastaId);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    hasta_laboratuvarSonuclari.DataSource = dataTable;
                    hasta_laboratuvarSonuclari.DataBind();
                }
            }
        }

        private void BindIlacVerisi(SqlConnection sqlConnection, int hastaId)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT hi.hastailac_Id, hi.hastailac_ilacId, hi.hastailac_verilmeTarih, hi.hasta_IlacDevamDurumu, it.ilacId, it.ilacIsmi FROM hastaIlac_tablosu hi INNER JOIN ilaclar_tablosu it ON hi.hastailac_ilacId = it.ilacId WHERE hi.hastailac_hastaId = @hastaIdNum", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@hastaIdNum", hastaId);
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    hasta_IlacListesi.DataSource = dataTable;
                    hasta_IlacListesi.DataBind();
                }
            }
        }

        protected void hastaIlacEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastailacEkleme.aspx?hasta=" + mainTckn);
        }

        protected void hastaNotEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastayaNotEkle.aspx?hasta=" + mainTckn);
        }

        protected void notGoruntuleButonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaNotGoruntuleme.aspx?notIdNum=" + not_Id.Text);
        }

        protected void hastaIlacForm_yonlendir_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaIlacGoruntule.aspx?vIlacId=" + hastaIlac_ID.Text);
        }

        protected void tetkikDetayButonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaTetkikDetay.aspx?tetkikId=" + hasta_TetkikDetayID.Text);
        }

        protected void kaydet_Button_Click(object sender, EventArgs e)
        {
            Response.Write("Hasta adı: " + hasta_Adi.Text);
            string hastaIsim = hasta_Adi.Text;
            Response.Write("Yeni: " + hastaIsim);
        }
    }
}
