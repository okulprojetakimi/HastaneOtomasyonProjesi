using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new oturumKontrolu().oturumKontroluYap(Response.Cookies["erisimCookie"]) != "yes")
            {
                Response.Redirect("/giris.aspx");
            }
        }
    }
}