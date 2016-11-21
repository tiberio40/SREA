using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SREA.Models
{
    public class SREAContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SREAContext() : base("name=SREAContext")
        {
        }

        public System.Data.Entity.DbSet<SREA.Models.Edificio> Edificios { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Salon> Salons { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Inventario> Inventarios { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Equipo> Equipoes { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Solicitud> Solicituds { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Respuesta> Respuestas { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Dia_Apartado> Dia_Apartado { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Tipo_Usuario> Tipo_Usuario { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<SREA.Models.Contacto> Contactoes { get; set; }
    }
}
