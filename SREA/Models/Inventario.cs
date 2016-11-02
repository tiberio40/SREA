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

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Display(Name = "Cantidad en el Inventario")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [Range(1, 100, ErrorMessage = "Debe ingresar un valor de 1 a 100")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Cantidad { get; set; }

        public int ID_Salon { get; set; }
        public virtual Salon Salon { get; set; }

        public int ID_Equipo{ get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}