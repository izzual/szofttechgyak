using System;
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
        public Nullable<int> KategoriaID { get; set; } // vagy: public int? KategoriaID

        // 1:1 kapcsolat a bicikli oldaláról
        public virtual Kategoria Kategoria { get; set; }
    }
}