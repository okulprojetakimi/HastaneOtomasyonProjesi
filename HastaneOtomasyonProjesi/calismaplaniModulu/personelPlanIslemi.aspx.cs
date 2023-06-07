using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class personelPlanIslemi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisim = new erisimDuzey())
            {
                if (!erisim.yetkiKontrol("Danışman", kontrolCookie.Value) || kontrolCookie == null || kontrolCookie.Value.Trim() == "" || HttpContext.Current.Request.QueryString["pId"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                personel_Id.Value = HttpContext.Current.Request.QueryString["pId"];
            }
        }
    }
}