using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAruhaz.Models
{
    public class BicikliContext:DbContext
    {
        public BicikliContext() : base("WebAruhaz") {

        }
        public DbSet<Kategoria> Kategoriak { get; set; }
        public DbSet<Bicikli> Biciklik { get; set; }
        public DbSet<KosarElem> VasarloiKosarElemek { get; set; }


    }
}