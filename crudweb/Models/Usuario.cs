using System;
using System.Collections.Generic;

namespace crudweb.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ciudadanos = new HashSet<Ciudadano>();
        }

        public string Id { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string? CorreoElectronico { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Ciudadano> Ciudadanos { get; set; }
    }
}
