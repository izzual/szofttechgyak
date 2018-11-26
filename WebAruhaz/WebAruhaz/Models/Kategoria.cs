using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAruhaz.Models
{
    public class Kategoria
    {
        public int KategoriaID { get; set; }
        [Required,StringLength(30)]
        public string  KatNev { get; set; }

        //kapcsolat a bicikli táblához (1:N)
        public virtual ICollection<Bicikli> Biciklik { get; set; }
    }
}