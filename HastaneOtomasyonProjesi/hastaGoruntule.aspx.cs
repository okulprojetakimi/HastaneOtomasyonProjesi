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

        private void inputDoldur()
        {
            using (SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlBaglan.Open();
                using (SqlCommand sqlKomutu = new SqlCommand("SELECT * FROM hasta_kayitlar WHERE hasta_Tc = @hastaNum", sqlBaglan))
                {
                    sqlKomutu.Parameters.AddWithValue("@hastaNum", HttpContext.Current.Request.QueryString["hasta"].ToString());
                    SqlDataReader veriOkuyucu = sqlKomutu.ExecuteReader();
                    while (veriOkuyucu.Read())
                    {
                        hasta_Tc.Text = veriOkuyucu.GetString(1);
                        hasta_Adi.Text = veriOkuyucu.GetString(2);
                        hasta_Soyadi.Text = veriOkuyucu.GetString(3);
                    }
                    veriOkuyucu.Close();
                    sqlBaglan.Close();
                }
            }
        }


        private void notListesiGetir(int hastaIdDegeri)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                string query = "SELECT hasta_NotId, hasta_Not, hasta_notTarihi FROM hasta_Notlari WHERE hasta_Id = @hastaNumarasi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@hastaNumarasi", hastaIdDegeri);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                hastaNotListesi.DataSource = dataTable;
                hastaNotListesi.DataBind();
                command.Dispose();
                connection.Close();
            }
        }

        private void tetkikCek(int hastaIdDegeri)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                string query = "SELECT laboratuvar_modul.tetkik_Id, laboratuvar_modul.tetkik_istekTarih, personel_tablo.personel_Isim ,laboratuvar_modul.tetkik_sonucTarih, laboratuvar_modul.tetkik_durum FROM laboratuvar_modul, personel_tablo WHERE laboratuvar_modul.tetkik_isteyenDoktorID = personel_tablo.personel_Id AND hasta_IdNumarasi = @hastaNumarasi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@hastaNumarasi", hastaIdDegeri);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                hasta_laboratuvarSonuclari.DataSource = dataTable;
                hasta_laboratuvarSonuclari.DataBind();
                command.Dispose();
                connection.Close();
            }
        }

        private void ilacVerisiCek(int hastaIdDegeri)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                string sorgu = "SELECT hastaIlac_tablosu.hastailac_Id, hastaIlac_tablosu.hastailac_ilacId, hastaIlac_tablosu.hastailac_verilmeTarih, hastaIlac_tablosu.hasta_IlacDevamDurumu, ilaclar_tablosu.ilacId, ilaclar_tablosu.ilacIsmi FROM hastaIlac_tablosu,ilaclar_tablosu WHERE hastaIlac_tablosu.hastailac_ilacId = ilaclar_tablosu.ilacId AND hastailac_hastaId = @hastaIdNUm";
                SqlCommand command = new SqlCommand(sorgu, connection);
                command.Parameters.AddWithValue("@hastaIdNUm", hastaIdDegeri);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                hasta_IlacListesi.DataSource = dataTable;
                hasta_IlacListesi.DataBind();
                command.Dispose();
                connection.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
         {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            try
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    mainTckn = HttpContext.Current.Request.QueryString["hasta"].ToString();

                    using (SqlConnection sqlCom = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                    {
                        sqlCom.Open();
                        using (SqlCommand hastaKontrol = new SqlCommand("SELECT hasta_Id FROM hasta_kayitlar WHERE hasta_Tc = @hastaTckn", sqlCom)) 
                        {
                            hastaKontrol.Parameters.AddWithValue("@hastaTckn", mainTckn);
                            SqlDataReader veriOkuyucu = hastaKontrol.ExecuteReader();
                            if (!veriOkuyucu.HasRows)
                            {
                                sqlCom.Close();
                                Response.Redirect("hastaIslemleri.aspx");  
                            }
                            else
                            {
                                int hastaIdNum = 0;
                                while (veriOkuyucu.Read())
                                {
                                    hastaIdNum = veriOkuyucu.GetInt32(0);
                                    notListesiGetir(hastaIdNum);
                                    tetkikCek(hastaIdNum);
                                    ilacVerisiCek(hastaIdNum);
                                }
                                
                                
                                veriOkuyucu.Close();
                                
                                sqlCom.Close();
                            }
                            

                        }
                    }
                    inputDoldur();
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

        protected void hastaIlacForm_yonlendir_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastaIlacGoruntule.aspx?vIlacId="+ hastaIlac_ID.Text);
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