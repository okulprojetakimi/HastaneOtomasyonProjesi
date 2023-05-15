using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                }
            }

        }
    }
}