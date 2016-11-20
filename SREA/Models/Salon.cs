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

        [Display(Name = "Nombre del Salón")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Capacidad de Personas")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [Range(1, 100, ErrorMessage = "Debe ingresar un valor de 1 a 100")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Capacidad { get; set; }

        [Display(Name = "Descripción del Salon")]
        public string Descripcion { get; set; }

        
        //public byte[] Imagen { get; set; }

        [Display(Name = "Nombre del Edificio")]
        public int ID_Edificio { get; set; }
        public virtual Edificio Edificio { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}