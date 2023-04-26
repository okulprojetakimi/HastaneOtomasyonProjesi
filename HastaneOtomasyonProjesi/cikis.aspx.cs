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
            if (Request.Cookies["erisimCookie"] != null)
            {
                HttpCookie cerezim = new HttpCookie("erisimCookie");
                cerezim.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cerezim);
            }
        }
    }
}