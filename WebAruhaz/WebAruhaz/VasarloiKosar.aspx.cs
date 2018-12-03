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


            using (VasarloiKosarMuveletek usersVasarloiKosar = new VasarloiKosarMuveletek()) {
                decimal kosarOsszesen = 0;
                kosarOsszesen = usersVasarloiKosar.GetOsszesen();
                if (kosarOsszesen > 0) {
                    lblTotal.Text = String.Format("{0:c}", kosarOsszesen);
                } else {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    VasarloiKosarCim.InnerText = "A vásárlói kosár üres!";
                    btnUpdate.Visible = false;
                }
            }
        }


        public List<KosarElem> GetVasarloiKosarElemek() {
            VasarloiKosarMuveletek muveletek = new VasarloiKosarMuveletek();
            return muveletek.GetKosarElemek();
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            UpdateKosarElemek();
        }

        private void UpdateKosarElemek() {
            throw new NotImplementedException();
        }
    }
}