using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.personelModulu
{
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisim = new erisimDuzey())
            {
                if (!erisim.yetkiKontrol("Danışman", kontrolCookie.Value) || kontrolCookie == null || kontrolCookie.Value.Trim() == "")
                {
                    Response.Redirect("/panel.aspx");
                }
            }
        }
    }
}