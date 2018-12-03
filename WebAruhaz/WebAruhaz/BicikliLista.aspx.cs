using System;
using System.Linq;
using System.Web.ModelBinding;
using WebAruhaz.Models;

namespace WebAruhaz
{
    public partial class BicikliLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Bicikli> GetBiciklik([QueryString("id")] int? kategoriaID) {
            var db = new BicikliContext();
            IQueryable<Bicikli> query = db.Biciklik;
            if (kategoriaID.HasValue && kategoriaID>0)
            {
                query = from sor in query
                        where sor.KategoriaID == kategoriaID
                        select sor;
                           
            }
            return query;
        }
    }
}