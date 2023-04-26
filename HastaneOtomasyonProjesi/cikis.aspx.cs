using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie silCerez = Request.Cookies["erisimCookie"];
            silCerez.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(silCerez);
        }
    }
}