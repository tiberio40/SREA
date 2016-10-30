using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Equipo
    {
        [Key]
        public int ID_Equipo { get; set; }

        public string Tipo_Equipo { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}