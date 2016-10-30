using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Tipo_Usuario
    {
        [Key]
        public int ID_Tipo_Usuario { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}