using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAruhaz.Models
{
    public class Bicikli
    {
        public int BicikliID { get; set; }
        [Required,StringLength(60)]
        public string ModelNev { get; set; }
        [StringLength(40)]
        public string Gyarto { get; set; }
        [StringLength(20)]
        public string Tipus { get; set; }
        public int Egysegar { get; set; }
        public string Kepfajl { get; set; }
        public Nullable<int> KategoriaID { get; set; }
        //vagy public int? KategoriaID{get; set;}

        //kapcsolat a bicikli oldaláról a kategória felé 1:1
        public virtual Kategoria Kategoria { get; set; }
    }
}