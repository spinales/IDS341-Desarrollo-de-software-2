using System;
using System.Collections.Generic;

namespace final_proyect.Models2
{
    public partial class Piso
    {
        public Piso()
        {
            Consultorios = new HashSet<Consultorio>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// unique
        /// </summary>
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Consultorio> Consultorios { get; set; }
    }
}
