using System;
using System.Collections.Generic;

namespace crudweb.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Sectors = new HashSet<Sector>();
        }

        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Provincium Provincia { get; set; } = null!;
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
