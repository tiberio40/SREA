using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Salon
    {
        [Key]
        public int ID_Salon { get; set; }

        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        public int ID_Edificio { get; set; }
        public virtual Edificio Edificio { get; set; }
    }
}