using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Edificio
    {
        [Key]
        public int ID_Edificio { get; set; }

        [Display(Name = "Nombre del Edificio")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        public virtual ICollection<Salon> Salon { get; set; }
    }
}