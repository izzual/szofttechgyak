using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace WebAruhaz.Models
{
    public class BicikliFeltolt:DropCreateDatabaseIfModelChanges<BicikliContext>
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
        // először beolvassuk a fájlból a kategória adatokat

        private static List<Kategoria> BeolvKategoria()
        {
            StreamReader reader = File.OpenText(@"E:\ai7ga9\szofttechgyak\WebAruhaz\WebAruhaz\App_Data\katadat.txt");
           // StreamReader reader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/katadat.txt"));
            var kategoria = new List<Kategoria>();
            Kategoria kateg;
            string[] sor;
            while (!reader.EndOfStream)
            {
                // A Split() metódussal a beolvasott sort szétdaraboljuk,                
                sor = reader.ReadLine().Split(';');
                // meghívjuk a default konstruktort és inicializáljuk az objektumot
                kateg = new Kategoria() { KategoriaID = int.Parse(sor[0]), KatNev = sor[1] };
                // az objektumot a listához adjuk
                kategoria.Add(kateg);
            }
            reader.Close();
            return kategoria;
        }
        private static List<Bicikli> BeolvBicikli()
        {
            StreamReader reader = File.OpenText( HttpContext.Current.Server.MapPath("~/App_Data/bicikli.txt"));
            var bicikli = new List<Bicikli>();
            Bicikli bicik;
            string[] sor;
            while (!reader.EndOfStream)
            {
                sor = reader.ReadLine().Split(';'); //széttördeljük a sort
                // létrehozzuk az objektumot és inicializáljuk
                bicik = new Bicikli()
                {
                    BicikliID = int.Parse(sor[0]),
                    ModelNev = sor[1],
                    Gyarto = sor[2],
                    Tipus = sor[3],
                    Egysegar = int.Parse(sor[4]),
                    Kepfajl = sor[5],
                    KategoriaID = int.Parse(sor[6])
                };
                // Az objektumot a listához adjuk
                bicikli.Add(bicik);
            }
            reader.Close();
            return bicikli;

        }
    }
}