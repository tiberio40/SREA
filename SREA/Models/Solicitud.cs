using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Solicitud
    {
        [Key]
        public int ID_Solicitud { get; set; }

        public string Tema { get; set; }

        public int Cantidad_Inscritos { get; set; }

        public DateTime Fecha_Solicitud { get; set; }

        public bool Estado { get; set; }

        public int ID_Salon { get; set; }
        public virtual Salon Salon { get; set; }

        public virtual ICollection<Dia_Apartado> Dia_Apartado { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }

        public int ID_Persona { get; set; }
        public virtual Persona Persona { get; set; }

    }
}