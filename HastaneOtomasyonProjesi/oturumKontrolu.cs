using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneOtomasyonProjesi
{
    public class oturumKontrolu
    {
        public string oturumKontroluYap(HttpCookie kontrolCookiesi)
        { 
            /* Eğer bu fonksiyondan "yes" geri dönüyorsa oturum var "no" dönüyorsa oturum geçersiz demektir.*/

            if (kontrolCookiesi != null)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
    }
}