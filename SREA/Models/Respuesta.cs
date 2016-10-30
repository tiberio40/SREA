using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Respuesta
    {
        [Key]
        public int ID_Respuesta { get; set; }

        public string Respuesta_Dada { get; set; }

        public DateTime Fecha { get; set; }

        public int ID_Solicitud { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}