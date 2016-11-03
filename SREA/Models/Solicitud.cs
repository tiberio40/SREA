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

        [Display(Name = "Tema de Solicitud")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Tema { get; set; }

        [Display(Name = "Cantidad de Usuarios")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [Range(1, 100, ErrorMessage = "Debe ingresar un valor de 1 a 100")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Cantidad_Inscritos { get; set; }

        [Display(Name = "Fecha de la solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Solicitud { get; set; }

        [Display(Name = "Estado de la Solicitud")]
        public bool Estado { get; set; }

        public int ID_Salon { get; set; }
        public virtual Salon Salon { get; set; }

        public virtual ICollection<Dia_Apartado> Dia_Apartado { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }

        public int ID_Persona { get; set; }
        public virtual Persona Persona { get; set; }

    }
}