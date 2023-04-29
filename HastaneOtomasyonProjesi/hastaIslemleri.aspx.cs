using System;
using System.Collections;
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
    public partial class hastaIslemleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolEt = Request.Cookies["erisimCookie"];
            if (kontrolEt == null)
            {
                Response.Redirect("/giris.aspx");
            }

            /* Arama için post işlemi yapılırsa */
            string hastaIsim = Request.Form["hastaIsmi"];
            string hastaSoyismi = Request.Form["hastaSoyismi"];

            
        }
    }
}