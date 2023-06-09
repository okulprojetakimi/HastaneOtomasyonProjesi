using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.laboratuvarModulu
{
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (erisimDuzey erisim = new erisimDuzey())
            {
                HttpCookie cookie = Request.Cookies["erisimCookie"];
                if (erisim.yetkiKontrol("Laboratuvar Teknikeri", cookie.Value) || erisim.yetkiKontrol("Admin", cookie.Value))
                {
                    
                }
                else if (HttpContext.Current.Request.QueryString["hastaNumara"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
            }

            }
    }
}