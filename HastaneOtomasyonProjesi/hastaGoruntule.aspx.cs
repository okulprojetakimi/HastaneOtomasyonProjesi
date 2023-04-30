using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HastaneOtomasyonProjesi
{
    public partial class hastaGoruntule : System.Web.UI.Page
    {
        public string mainTckn = "";
        protected void Page_Load(object sender, EventArgs e)
         {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            if (kontrolCookie == null)
            {
                Response.Redirect("/panel.aspx");
            }
            try
            {
                if (HttpContext.Current.Request.QueryString["hasta"] == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                else
                {
                    mainTckn = HttpContext.Current.Request.QueryString["hasta"].ToString();
                }
            }
            catch (Exception damnError)
            {
                Response.Write(damnError.Message);
            }
        }

        protected void hastaIlacEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastayaIlacEkleme.aspx?hasta="+mainTckn);
        }

        protected void hastaNotEkleme_Click(object sender, EventArgs e)
        {
            Response.Redirect("hastayaNotEkle.aspx?hasta="+mainTckn);
        }
    }
}