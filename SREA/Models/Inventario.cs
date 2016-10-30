using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Inventario
    {
        [Key]
        public int ID_Inventario { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public int ID_Salon { get; set; }
        public virtual Salon Salon { get; set; }

        public int ID_Equipo{ get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}