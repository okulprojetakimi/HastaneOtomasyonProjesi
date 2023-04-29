﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HastaneOtomasyonProjesi
{
    public partial class yeniHastaKaydı : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button31_Click31(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlBaglantisi = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabaniBilgi"].ConnectionString))
                {
                    sqlBaglantisi.Open();

                    using (SqlCommand hastaEkleme = new SqlCommand("insert into hasta_kayitlar(hasta_Adi, hasta_Soyadi) values(@hasta_Adi, @hasta_Soyadi)", sqlBaglantisi))
                    {
                        hastaEkleme.Parameters.AddWithValue("@hasta_Adi", hasta_Adi.Text);
                    }



                }
            }
            catch (Exception)
            {
                Response.Write("<script> alert('eklendi') </script>");
            }





        }

    }
}
