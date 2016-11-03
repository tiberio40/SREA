using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Dia_Apartado
    {
        [Key]
        public int ID_Dia_Apartado { get; set; }

        [Display(Name = "Fecha en que desea reservar")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Apartada { get; set; }

        [Display(Name = "Fecha en que desea reservar")]
        public DateTime Hora_Comienzo { get; set; }

        public DateTime Hora_Terminado { get; set; }

        public int ID_Solicitud { get; set; }
        public virtual Solicitud Solicitud { get; set; }

    }
}