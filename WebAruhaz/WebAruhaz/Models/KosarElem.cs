using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAruhaz.Models
{
    public class KosarElem
    {
        [Key]
        public string ElemId { get; set; }
        public string KosarId { get; set; }
        public int Mennyiseg { get; set; }
        public System.DateTime LetrehozasDatuma { get; set; }
        public int BicikliId { get; set; }
        public virtual Bicikli Bicikli { get; set; }

    }
}