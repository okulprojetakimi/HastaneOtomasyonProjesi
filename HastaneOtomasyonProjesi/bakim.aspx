<%@ Page  Title="Bakım Var" Language="C#" AutoEventWireup="true" CodeBehind="bakim.aspx.cs" Inherits="HastaneOtomasyonProjesi.bakim" %>

<html>
    <body style="font-family: sans-serif;">
        <center>
        <%
            string mesaj = "";
            string title = "";

            using (System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
            {
                sqlcon.Open();
                using (System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand("SELECT ayar_Title, ayar_BakimMesaji FROM sistem_Tablo", sqlcon))
                {
                    System.Data.SqlClient.SqlDataReader readData = com.ExecuteReader();
                    while (readData.Read())
                    {
                        title = readData.GetString(0);
                        mesaj = readData.GetString(1);
                    }
                    readData.Close();
                }
                sqlcon.Close();
            }

            %>
        <h1><%= title %></h1>
        <h3><%= mesaj %></h3>
    </center>
    </body>
</html>