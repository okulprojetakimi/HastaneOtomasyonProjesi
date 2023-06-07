using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace HastaneOtomasyonProjesi.calismaplaniModulu
{
    public partial class anasayfa : System.Web.UI.Page
    {

        public string pNumARA = HttpContext.Current.Request.QueryString["personel_Numara"];
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie kontrolCookie = Request.Cookies["erisimCookie"];
            using (erisimDuzey erisim = new erisimDuzey())
            {
                if (!erisim.yetkiKontrol("Danışman", kontrolCookie.Value) || kontrolCookie == null || kontrolCookie.Value.Trim() == "" || pNumARA == null)
                {
                    Response.Redirect("/panel.aspx");
                }
                personelid.Value = HttpContext.Current.Request.QueryString["personel_Numara"];
            }
        }

        protected void kaydet_Buton(object sender, EventArgs e)
        {
            
        }

    }
}
