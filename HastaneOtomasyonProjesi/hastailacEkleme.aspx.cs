using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public partial class hastailacEkleme : System.Web.UI.Page
    {
        public string hastaTcNum = HttpContext.Current.Request.QueryString["hasta"];
        public int hastaId;
        public int ilacId;
        public SqlConnection sqlBaglan = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["hasta"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
            else
            {
                sqlBaglan.Open();
                using (SqlCommand komut = new SqlCommand("SELECT hasta_Id,hasta_Adi, hasta_Soyadi FROM hasta_kayitlar WHERE hasta_Tc = @hastaTC", sqlBaglan))
                {
                    komut.Parameters.AddWithValue("@hastaTC", hastaTcNum);
                    using (SqlDataReader veriOkuyucu = komut.ExecuteReader())
                    {
                        while (veriOkuyucu.Read())
                        {
                            hastaId = veriOkuyucu.GetInt32(0);
                            string hastaIsim = veriOkuyucu.GetString(1);
                            string hastaSoyIsim = veriOkuyucu.GetString(2);

                            ilac_Hasta.Text = "İlaç eklenecek hasta: " + hastaIsim + " " + hastaSoyIsim;
                            ilac_HastaTc.Text = "İlaç eklenecek hastanın TCKN: " + hastaTcNum;
                        }
                    }
                    sqlBaglan.Close();
                }
            }
        }

        /* Hastaya ilaç ekleme butonu */
        protected void hastaIlac_Ekle_Click(object sender, EventArgs e)
        {
            sqlBaglan.Open();
            using (SqlCommand ilacEkleme = new SqlCommand("INSERT INTO hastaIlac_tablosu (hastailac_Id,hastailac_hastaId,hastailac_ilacId,hastailac_verilmeTarih,hasta_IlacDevamDurumu) values (@hastailac_Id,@hastailac_hastaId,@hastailac_ilacId,@hastailac_verilmeTarih,@hasta_IlacDevamDurumu)", sqlBaglan))
            {
                ilacEkleme.Parameters.AddWithValue("@hastailac_Id", new Random().Next(11111, 99999).ToString());
                ilacEkleme.Parameters.AddWithValue("@hastailac_hastaId", hastaId);
                ilacEkleme.Parameters.AddWithValue("hastailac_ilacId", ilacIdNum.Text);
                ilacEkleme.Parameters.AddWithValue("@hastailac_verilmeTarih", DateTime.Parse(DateTime.Now.ToLongDateString()));
                ilacEkleme.Parameters.AddWithValue("@hasta_IlacDevamDurumu", 1);
                ilacEkleme.ExecuteNonQuery();
                ilacEkleme.Dispose();
                sqlBaglan.Close();

            }
        }

    }
}