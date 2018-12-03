using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAruhaz.Models;

namespace WebAruhaz.Logic {
    public class VasarloiKosarMuveletek : IDisposable {
        public string VasarloiKosarId { get; set; }
        private BicikliContext db = new BicikliContext();
        public const string KosarSessionKey = "KosarId";

        public struct VasarloiKosarUpdates {
            public int BickliId;
            public int VasaroltMennyiseg;
            public bool RemoveElem;
        }

        public void KosarbaTesz(int id) {
            //kiolvassuk a bicikli adatait az adatbázisból
            VasarloiKosarId = GetKosarId();
            var kosarElem = (from c in db.VasarloiKosarElemek
                             where c.ElemId == VasarloiKosarId && c.BicikliId == id
                             select c).SingleOrDefault();
            if (kosarElem == null) {
                //Létrehozunk egy új kosárelem objektumot, ha még nem létezett egysem.
                //Mivel nincs paraméteres az osztálynak
                // inicializálással adunk értéket a tulajdonságoknak
                kosarElem = new KosarElem {
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
            } else {
                //Ha az elem már létezik a kosárban, akkor megnöveljük 1-el 
                // a mennyiségét
                kosarElem.Mennyiseg++;
            }
            db.SaveChanges(); // Lementjük a változásokat az adatbázisba
        }

        private string GetKosarId() {
            // Kosár Session azonosítójának beállítása
            if (HttpContext.Current.Session[KosarSessionKey] == null) {
                if (!string.IsNullOrWhiteSpace
                    (HttpContext.Current.User.Identity.Name)) //aktuális felhasználó neve
                {
                    HttpContext.Current.Session[KosarSessionKey] =
                        HttpContext.Current.User.Identity.Name;
                } else {
                    //Létrehozunk egy új véletlen GUID értéket a System.GUID osztály segítségével
                    Guid tempKosarId = Guid.NewGuid();
                    HttpContext.Current.Session[KosarSessionKey] =
                        tempKosarId.ToString();
                }
            }
            return HttpContext.Current.Session[KosarSessionKey].ToString();
        }

        public void Dispose() {
            if (db != null) {
                db.Dispose();
                db = null;
            }
        }


        public void UpdateVasarloiKosarDatabase(string kosarId, VasarloiKosarUpdates[] KosarElemUpdates) {
            using (var db = new WebAruhaz.Models.BicikliContext()) {
                try {
                    int kosarElemCount = KosarElemUpdates.Count();
                    List<KosarElem> kosar = this.GetKosarElemek();
                    foreach (var kosarElem in kosar) {
                        for (int i = 0; i < kosarElemCount; i++) {
                            if (kosarElem.Bicikli.BicikliID == KosarElemUpdates[i].BickliId) {
                                if (KosarElemUpdates[i].VasaroltMennyiseg < 1 || KosarElemUpdates[i].RemoveElem == true) {
                                    this.RemoveElem(kosarId, kosarElem.BicikliId);
                                } else {
                                    UpdateElem(kosarId, kosarElem.BicikliId, KosarElemUpdates[i].VasaroltMennyiseg);
                                }
                            }
                        }
                    }
                } catch (Exception e) {
                    throw new Exception("ERROR: nem lehet a kosar adatbazisat modositani!"+ e.Message, e);
                }
            }
        }

        private void UpdateElem(string updateKosarId, int updateBicikliId, int mennyiseg) {
            using (var db = new WebAruhaz.Models.BicikliContext()) {
                try {
                    var tetel = (from c in db.VasarloiKosarElemek
                                 where c.KosarId == updateKosarId && c.Bicikli.BicikliID == updateBicikliId
                                 select c).FirstOrDefault();
                    if (tetel != null) {
                        tetel.Mennyiseg = mennyiseg;
                        db.SaveChanges();
                    }
                } catch (Exception e) {
                    throw new Exception("ERROR: nem lehet modositani az elemet!" + e.Message, e);
                }
            }
        }

        private void RemoveElem(string removeKosarId, int removeBicikliId) {
            using (var db = new WebAruhaz.Models.BicikliContext()) {
                try {
                    var tetel = (from c in db.VasarloiKosarElemek
                                 where c.KosarId == removeKosarId && c.Bicikli.BicikliID == removeBicikliId
                                 select c).FirstOrDefault();
                    if (tetel != null) {
                        db.VasarloiKosarElemek.Remove(tetel);
                        db.SaveChanges();
                    }
                } catch (Exception e) {
                    throw new Exception("ERROR: nem lehet eltavolitani az elemet!" + e.Message, e);
                }
            }
        }

        public void KosarTorles() {
            VasarloiKosarId = GetKosarId();
            var kosarElemek = (from c in db.VasarloiKosarElemek
                               where c.KosarId == VasarloiKosarId
                               select c);
            foreach (var kosarelem in kosarElemek) {
                db.VasarloiKosarElemek.Remove(kosarelem);
            }
            db.SaveChanges();
        }

        public int Megszamol() {
            VasarloiKosarId = GetKosarId();
            int? mennyi = (from kosarElemek in db.VasarloiKosarElemek
                           where kosarElemek.KosarId == VasarloiKosarId
                           select (int?) kosarElemek.Mennyiseg).Sum();
            return mennyi ?? 0;
        }

        public List<KosarElem> GetKosarElemek() {
            VasarloiKosarId = GetKosarId();
            return (from c in db.VasarloiKosarElemek
                    where c.KosarId == VasarloiKosarId
                    select c).ToList();
        }

        public decimal GetOsszesen() {
            VasarloiKosarId = GetKosarId();

            decimal? osszesen = decimal.Zero;
            osszesen = (decimal?)(from kosarElemek in db.VasarloiKosarElemek
                                  where kosarElemek.KosarId == VasarloiKosarId
                                  select (int?)kosarElemek.Mennyiseg * kosarElemek.Bicikli.Egysegar).Sum();
            return osszesen ?? decimal.Zero;
        }

        public VasarloiKosarMuveletek GetKosar(HttpContext context) {
            using (var kosar = new VasarloiKosarMuveletek()) {
                kosar.VasarloiKosarId = kosar.GetKosarId();
                return kosar;
            }
        }

    }
}