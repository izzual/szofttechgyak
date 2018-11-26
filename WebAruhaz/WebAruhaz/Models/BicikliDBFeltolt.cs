using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity;

namespace WebAruhaz.Models
{
    public class BicikliDBFeltolt:DropCreateDatabaseIfModelChanges<BicikliContext>
    {
        protected override void Seed(BicikliContext context)
        {
            foreach (var item in BeolvKategoria())
            {
                context.Kategoriak.Add(item);
            }
            foreach (var item in BeolvBicikli())
            {
                context.Biciklik.Add(item);
            }
        }

        private static List<Kategoria> BeolvKategoria()
        {
            StreamReader reader =
                 File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/katadat.txt"));
            var kategoria = new List<Kategoria>();
            Kategoria kateg;
            string[] sor;
            while (!reader.EndOfStream)
            {
                sor = reader.ReadLine().Split(';');
                kateg = new Kategoria()
                {
                    KategoriaID = int.Parse(sor[0]),
                    KatNev = sor[1]
                };
                kategoria.Add(kateg);
            }
            reader.Close();
            return kategoria;
        }

        private List<Bicikli> BeolvBicikli()
        {
            StreamReader reader =
                File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/bicikli.txt"));
            var biciklik = new List<Bicikli>();
            Bicikli bicikli;
            string[] sor;
            while (!reader.EndOfStream)
            {
                sor = reader.ReadLine().Split(';');
                //létrehozzuk és inicializáljuk a bicikli objektumot
                bicikli = new Bicikli()
                {
                    BicikliID = int.Parse(sor[0]),
                    ModelNev = sor[1],
                    Gyarto = sor[2],
                    Tipus = sor[3],
                    Egysegar = int.Parse(sor[4]),
                    Kepfajl = sor[5],
                    KategoriaID = int.Parse(sor[6])
                };
                biciklik.Add(bicikli);
            }
            reader.Close();
            return biciklik;
        }
    }
}