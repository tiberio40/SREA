using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class Usuario
    {
        [Key]
        public string Nick { get; set; }

        public string Clave { get; set; }

    }
}