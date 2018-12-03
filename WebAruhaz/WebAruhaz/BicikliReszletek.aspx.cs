using System;
using System.Linq;
using System.Web.ModelBinding;
using WebAruhaz.Models;

namespace WebAruhaz
{
    public partial class BicikliReszletek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Bicikli> EgyBicikli([QueryString("bicikliID")] int? bicikliKod) {
            var db = new BicikliContext();
            IQueryable<Bicikli> query = db.Biciklik;

            if (bicikliKod.HasValue&& bicikliKod>0)
            {
                query = from sor in query
                        where sor.BicikliID == bicikliKod
                        select sor;
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}