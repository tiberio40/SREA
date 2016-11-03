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

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nick { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Display(Name = "Numero Telefonico")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Telefono { get; set; }

        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 8)]
        public string Clave { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }

        public int ID_Tipo_Usuario { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }


    }
}