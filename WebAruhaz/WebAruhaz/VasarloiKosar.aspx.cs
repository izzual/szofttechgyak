using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAruhaz.Models;
using WebAruhaz.Logic;

namespace WebAruhaz {
    public partial class VasarloiKosar : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public List<KosarElem> GetVasarloiKosarElemek() {
            VasarloiKosarMuveletek muveletek = new VasarloiKosarMuveletek();
            return muveletek.GetKosarElemek();
        }
    }
}