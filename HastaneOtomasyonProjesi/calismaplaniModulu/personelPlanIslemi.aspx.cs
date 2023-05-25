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
            if (HttpContext.Current.Request.QueryString["pId"] == null)
            {
                Response.Redirect("/panel.aspx");
            }
        }
    }
}