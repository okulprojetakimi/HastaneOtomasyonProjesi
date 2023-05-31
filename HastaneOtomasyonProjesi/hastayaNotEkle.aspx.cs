using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastayaNotEkle : System.Web.UI.Page
    {
        /* Global Variables*/
        public string mainTCKN = HttpContext.Current.Request.QueryString["hasta"].ToString();
        public string hastaIsim = "";
        public string hastaSoyisim = "";
        public int hastaId;
        public SqlConnection sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["hasta"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                hasta_TcLabel.Text = mainTCKN;
                sqlCn.Open();
                using (SqlCommand idCek = new SqlCommand("SELECT hasta_Id, hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastatcnum", sqlCn))
                {
                    idCek.Parameters.AddWithValue("@hastatcnum", mainTCKN);
                    using (SqlDataReader tabloOkuyucu = idCek.ExecuteReader())
                    {
                        while (tabloOkuyucu.Read())
                        {
                            hastaId = tabloOkuyucu.GetInt32(0);
                            hastaIsim = tabloOkuyucu.GetString(1);
                            hastaSoyisim = tabloOkuyucu.GetString(2);
                        }
                        tabloOkuyucu.Close();
                        sqlCn.Close();
                    }
                }
                hasta_IsimSoyisim.Text = hastaIsim + " " + hastaSoyisim;
            }
        }

        /* Hastaya Not Ekleme */
        protected void hastaNot_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCn.Open();
                using (SqlCommand notEklemeKomutu = new SqlCommand("INSERT INTO hasta_Notlari (hasta_NotId, hasta_Not, hasta_notTarihi, hasta_Id) VALUES (@hastaIdNumarasi, @hastaNotYazisi, @hastaNotTarihi, @hastaId)", sqlCn))
                {
                    notEklemeKomutu.Parameters.AddWithValue("@hastaIdNumarasi", new Random().Next(11111, 99999).ToString());
                    notEklemeKomutu.Parameters.AddWithValue("@hastaNotYazisi", hastaNotu.Text);
                    notEklemeKomutu.Parameters.AddWithValue("@hastaNotTarihi", DateTime.Parse(DateTime.Now.ToLongDateString()));
                    notEklemeKomutu.Parameters.AddWithValue("@hastaId", hastaId);
                    notEklemeKomutu.ExecuteNonQuery();
                    Response.Write("<script>alert('Not başarıyla eklendi.')</script>");
                    notEklemeKomutu.Dispose();
                    sqlCn.Close();
                }
            }
            catch (Exception damnError)
            {
                Response.Write("Kritik hata! Lütfen sistem yöneticiniz ile görüşünüz. \n " + damnError.Message);
            }
        }
    }
}