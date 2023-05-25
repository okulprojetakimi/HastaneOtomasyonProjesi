using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Optimization;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class kaydetapi : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "GET")
            {
                string personelCalismaTarihString = Request.QueryString["personelCalismaTarih"];
                string calismaPlanlariString = Request.QueryString["calismaPlanlari"];
                string calismaListeId = Request.QueryString["calismaListeId"];
                string personelId = Request.QueryString["personelid"];


                JArray calismaPlanlariArray = JArray.Parse(calismaPlanlariString);
                string[] calismaPlanlari = calismaPlanlariArray.Select(p => p.ToString()).ToArray();

                DateTime personelCalismaTarih;
                if (!DateTime.TryParse(personelCalismaTarihString, out personelCalismaTarih))
                {

                    return;
                }

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO calisanPersonelTablosu (calismaListeId, personelId, personelCalismaTarih, g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16, g17, g18, g19, g20, g21, g22, g23, g24, g25, g26, g27, g28, g29, g30, g31) " +
                        "VALUES (@calismaListeId, @personelId, @personelCalismaTarih, @g1, @g2, @g3, @g4, @g5, @g6, @g7, @g8, @g9, @g10, @g11, @g12, @g13, @g14, @g15, @g16, @g17, @g18, @g19, @g20, @g21, @g22, @g23, @g24, @g25, @g26, @g27, @g28, @g29, @g30, @g31)", connection);

                    command.Parameters.AddWithValue("@calismaListeId", calismaListeId);
                    command.Parameters.AddWithValue("@personelId", personelId);
                    command.Parameters.AddWithValue("@personelCalismaTarih", personelCalismaTarih);

                    for (int i = 0; i < 31; i++)
                    {
                        string gValue = string.Empty;

                        //if (calismaPlanlari.Length > i && !string.IsNullOrEmpty(calismaPlanlari[i]))
                        //{
                        //    string[] saatler = calismaPlanlari[i].Split(',');
                        //    if (saatler.Length == 2)
                        //    {
                        //        string baslangicSaat = saatler[0].Trim().TrimStart('\"').TrimEnd('\"');
                        //        string bitisSaat = saatler[1].Trim().TrimStart('\"').TrimEnd('\"');
                        //        gValue = baslangicSaat + "," + bitisSaat;
                        //    }
                        //}

                        if (calismaPlanlari.Length > i && !string.IsNullOrEmpty(calismaPlanlari[i]))
                        {
                            string saatlerString = calismaPlanlari[i].Trim().TrimStart('[').TrimEnd(']');
                            string[] saatler = saatlerString.Split(',');
                            if (saatler.Length == 2)
                            {
                                string baslangicSaat = saatler[0].Trim().TrimStart('\"').TrimEnd('\"');
                                string bitisSaat = saatler[1].Trim().TrimStart('\"').TrimEnd('\"');
                                gValue = baslangicSaat + "," + bitisSaat;
                            }
                        }
                        command.Parameters.AddWithValue("@g" + (i + 1), gValue);
                    }

                    command.ExecuteNonQuery();

                    connection.Close();

                    Response.Write("<script>alert('Eklendi');</script>");
                }
            }






        }

    }
}



