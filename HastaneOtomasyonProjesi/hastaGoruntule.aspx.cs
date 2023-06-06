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
            using (erisimDuzey duzeyKontrol = new erisimDuzey())
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null || !duzeyKontrol.yetkiKontrol("Doktor", Request.Cookies["erisimCookie"].Value))
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    mainTckn = HttpContext.Current.Request.QueryString["hasta"].ToString();
                    LoadData();
                }
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

        protected void tetkikDetayButonu_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaTetkikDetay.aspx?tetkikId=" + hasta_TetkikDetayID.Text);
        }

        
    }
}
