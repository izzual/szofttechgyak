using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAruhaz.Models;

namespace WebAruhaz.Logic
{
    public class VasarloiKosarMuveletek : IDisposable
    {
        public string VasarloiKosarId { get; set; }
        private BicikliContext db = new BicikliContext();
        public const string KosarSessionKey = "KosarId";

        public void KosarbaTesz(int id) {
            //kiolvassuk a bicikli adatait az adatbázisból
            VasarloiKosarId = GetKosarId();
            var kosarElem = (from c in db.VasarloiKosarElemek
                             where c.ElemId == VasarloiKosarId && c.BicikliId == id
                             select c).SingleOrDefault();
            if (kosarElem==null)
            {
                //Létrehozunk egy új kosárelem objektumot, ha még nem létezett egysem.
                //Mivel nincs paraméteres az osztálynak
                // inicializálással adunk értéket a tulajdonságoknak
                kosarElem = new KosarElem
                {
                    ElemId = Guid.NewGuid().ToString(),
                    BicikliId = id,
                    KosarId = VasarloiKosarId,
                    Bicikli = (from b in db.Biciklik
                               where b.BicikliID == id
                               select b).SingleOrDefault(),
                    Mennyiseg = 1,
                    LetrehozasDatuma = DateTime.Now
                };
                db.VasarloiKosarElemek.Add(kosarElem);
            }
            else
            {
                //Ha az elem már létezik a kosárban, akkor megnöveljük 1-el 
                // a mennyiségét
                kosarElem.Mennyiseg++;
            }
            db.SaveChanges(); // Lementjük a változásokat az adatbázisba
        }

        private string GetKosarId()
        {
            // Kosár Session azonosítójának beállítása
            if (HttpContext.Current.Session[KosarSessionKey]==null)
            {
                if (!string.IsNullOrWhiteSpace
                    (HttpContext.Current.User.Identity.Name)) //aktuális felhasználó neve
                {
                    HttpContext.Current.Session[KosarSessionKey] =
                        HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    //Létrehozunk egy új véletlen GUID értéket a System.GUID osztály segítségével
                    Guid tempKosarId = Guid.NewGuid();
                    HttpContext.Current.Session[KosarSessionKey] = 
                        tempKosarId.ToString();
                }
            }
            return HttpContext.Current.Session[KosarSessionKey].ToString();
        }

        public void Dispose()
        {
            if (db!=null)
            {
                db.Dispose();
                db = null;
            }
        }
        public List<KosarElem> GetKosarElemek() {
            VasarloiKosarId = GetKosarId();
            return (from c in db.VasarloiKosarElemek
                    where c.KosarId == VasarloiKosarId
                    select c).ToList();
        }

    }
}