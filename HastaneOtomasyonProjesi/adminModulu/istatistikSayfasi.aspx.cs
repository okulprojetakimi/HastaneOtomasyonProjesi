using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class istatistikSayfasi : System.Web.UI.Page
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
                // MssqlDBCount.Value
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand com = new SqlCommand("EXEC sp_spaceused", sqlcon))
                    {
                        SqlDataReader dRead = com.ExecuteReader();
                        if(dRead.Read())
                        {
                            db_Boyut.Text = dRead["database_size"].ToString();
                            MssqlDBCount.Value = dRead["database_size"].ToString();
                        }
                        dRead.Close();
                    }
                    /* Hasta, ameliyat ve personel sayısı çekme */
                    using (SqlCommand basitIstatistikCek = new SqlCommand())
                    {
                        basitIstatistikCek.CommandText = "SELECT " +
                                       "(SELECT COUNT(*) FROM hasta_kayitlar) AS hastaSayisi, " +
                                       "(SELECT COUNT(*) FROM ameliyathane_Tablo) AS ameliyatSayisi, " +
                                       "(SELECT COUNT(*) FROM personel_tablo) AS personelSayisi";

                        ;
                        basitIstatistikCek.Connection = sqlcon;
                        SqlDataReader reader = basitIstatistikCek.ExecuteReader();

                        if (reader.Read())
                        {
                            hasta_Sayisi.Text = reader["hastaSayisi"].ToString();
                            ameliyat_Sayisi.Text = reader["ameliyatSayisi"].ToString();
                            personel_Sayi.Text = reader["personelSayisi"].ToString();
                        }

                        reader.Close();
                    }
                    sqlcon.Close();
                }
                /**/
                PerformanceCounter cpuSayac = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float cpuKullanim = cpuSayac.NextValue() / Environment.ProcessorCount;
                System.Threading.Thread.Sleep(1000);
                cpuKullanim = cpuSayac.NextValue() / Environment.ProcessorCount;
                IIScpuKullanimi.Value = cpuKullanim.ToString();
                web_Cpu.Text = " %" + cpuKullanim.ToString();
            }
        }
    }
}