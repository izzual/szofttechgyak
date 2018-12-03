using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAruhaz.Models
{
    public class Kategoria
    {
        //public Kategoria()
        //{
        //    Biciklik = new HashSet<Bicikli>();
        //}
        public int KategoriaID { get; set; }
        [Required,StringLength(30)]
        public string KatNev { get; set; }

        //Kapcsolat a bicikli táblához (1:N)
        public virtual ICollection<Bicikli> Biciklik { get; set; }

    }
}