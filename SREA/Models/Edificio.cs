using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Edificio
    {
        [Key]
        public int ID_Edificio { get; set; }

        public string Nombre { get; set; }
    }
}