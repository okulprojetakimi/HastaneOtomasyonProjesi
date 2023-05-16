using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class personelDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                // personelTc
                if (HttpContext.Current.Request.QueryString["personelTc"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    // Devam
                    if (!IsPostBack)
                    {
                        using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                        {
                            sqlcon.Open();
                            using (SqlCommand bolumCek = new SqlCommand("SELECT * FROM personelBolum_tablo", sqlcon))
                            {
                                SqlDataReader reader = bolumCek.ExecuteReader();
                                while (reader.Read())
                                {
                                    personel_Bolum.Items.Add(new ListItem(reader["pBolumIsmi"].ToString(), reader["pBolumId"].ToString() ));
                                }
                                reader.Close();
                            }
                            using (SqlCommand sqlKomut = new SqlCommand("SELECT personel_tablo.personel_Isim, personel_tablo.personel_Soyisim, personel_tablo.personel_Telefon, personel_tablo.personel_Eposta, personel_tablo.personel_SicilNo, personel_tablo.personel_SozlesmeTipi, personel_kanGrubu, personel_tablo.personel_ikametAdres, personel_tablo.personel_Turu, personel_tablo.personel_IzinDurum, personel_tablo.personel_Tc, personel_Bolum FROM personel_tablo, personelBolum_tablo, kan_Grubu WHERE personel_tablo.personel_Tc = @pTc AND personel_tablo.personel_Bolum = personelBolum_tablo.pBolumID;", sqlcon))
                            {
                                sqlKomut.Parameters.AddWithValue("@pTc", HttpContext.Current.Request.QueryString["personelTc"]);
                                SqlDataReader veriOkuyucu = sqlKomut.ExecuteReader();
                                while (veriOkuyucu.Read())
                                {
                                    personel_Isim.Text = veriOkuyucu.GetString(0);
                                    personel_Soyisim.Text = veriOkuyucu.GetString(1);
                                    personel_Telefon.Text = veriOkuyucu.GetString(2);
                                    personel_Eposta.Text = veriOkuyucu.GetString(3);
                                    personel_SicilNo.Text = veriOkuyucu.GetString(4);
                                    personel_SozlesmeTipi.Text = veriOkuyucu.GetString(5);
                                    personel_kanGrubu.SelectedIndex = veriOkuyucu.GetInt32(6);
                                    personel_ikametAdres.Text = veriOkuyucu.GetString(7);
                                    personel_Turu.Text = veriOkuyucu.GetString(8);
                                    
                                    if (veriOkuyucu.GetBoolean(9))
                                    {
                                        personel_izinDurum.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        personel_izinDurum.SelectedIndex = 1;
                                    }
                                    personel_Tc.Text = veriOkuyucu.GetString(10);
                                    personel_Bolum.SelectedIndex = veriOkuyucu.GetInt32(11);
                                    
                                }
                            }
                            sqlcon.Close();
                        }
                    }
                }
            }
        }

        protected void personel_Guncelle_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand sqlcom = new SqlCommand("UPDATE personel_tablo SET personel_Tc = @pTc, personel_Isim = @pIsim, personel_Soyisim = @pSoyisim, personel_Telefon = @pTel, personel_Eposta = @pEposta, personel_SicilNo = @pSicilNo, personel_Bolum = @pBolum, personel_SozlesmeTipi = @pSozlesme, personel_kanGrubu = @pKan, personel_ikametAdres = @pIkamet, personel_Turu = @pTuru, personel_IzinDurum = @pIzin WHERE personel_Tc = @personelTckn", sqlcon))
                    {
                        sqlcom.Parameters.AddWithValue("@pTc", personel_Tc.Text);
                        sqlcom.Parameters.AddWithValue("@pIsim", personel_Isim.Text);
                        sqlcom.Parameters.AddWithValue("@pSoyisim", personel_Soyisim.Text);
                        sqlcom.Parameters.AddWithValue("@pTel", personel_Telefon.Text);
                        sqlcom.Parameters.AddWithValue("@pEposta", personel_Eposta.Text);
                        sqlcom.Parameters.AddWithValue("@pSicilNo", personel_SicilNo.Text);
                        sqlcom.Parameters.AddWithValue("@pBolum", personel_Bolum.SelectedIndex);
                        sqlcom.Parameters.AddWithValue("@pSozlesme", personel_SozlesmeTipi.Text);
                        sqlcom.Parameters.AddWithValue("@pKan", personel_kanGrubu.SelectedValue);
                        sqlcom.Parameters.AddWithValue("@pIkamet", personel_ikametAdres.Text);
                        sqlcom.Parameters.AddWithValue("@pTuru", personel_Turu.Text);
                        sqlcom.Parameters.AddWithValue("@pIzin", personel_izinDurum.SelectedValue);
                        sqlcom.Parameters.AddWithValue("@personelTckn", HttpContext.Current.Request.QueryString["personelTc"]);

                        sqlcom.ExecuteNonQuery();
                        Response.Redirect("/personelModulu/personelDetay?personelTc="+ HttpContext.Current.Request.QueryString["personelTc"]);
                    }

                }
            }
        }
    }
}