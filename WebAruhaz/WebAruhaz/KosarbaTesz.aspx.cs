using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WebAruhaz.Logic;

namespace WebAruhaz
{
    public partial class KosarbaTesz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sorId = Request.QueryString["BicikliID"];
            int bicikliId;
            if (!String.IsNullOrEmpty(sorId) && 
                int.TryParse(sorId, out bicikliId))
            {
                using (VasarloiKosarMuveletek usersVasarloiKosar=new VasarloiKosarMuveletek())
                {
                    usersVasarloiKosar.KosarbaTesz(Convert.ToInt16(sorId));
                }
            }
            else
            {
                Debug.Fail("ERROR: Nem lehet elemet hozzáadni a kosárhoz bicikliId nélkül");
                throw new Exception("ERROR: Nem lehet betölteni a KosarbaTesz.aspx oldalt a BicikliId megadása nélkül");

            }
            Response.Redirect("VasarloiKosar.aspx");
        }
    }
}