using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Contacto
    {
        [Key]
        public int ID_Contacto { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Mensaje")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Mensaje { get; set; }

        public bool Estado { get; set; }
    }
}