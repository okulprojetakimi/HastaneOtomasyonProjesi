﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.adminModulu
{
    public partial class hesapIslem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // GET => personelNumarasi
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null || kontrolCookie.Value.Trim() == "")
            {
                Response.Redirect("/cikis.aspx");
            }
            else
            {
                if (true)
                {

                }
            }
        }
    }
}