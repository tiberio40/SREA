using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Persona
    {
        [Key]
        public int ID_Persona { get; set; }

        public string Nick { get; set; }
        
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Clave { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }

        public int ID_Tipo_Usuario { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }


    }
}