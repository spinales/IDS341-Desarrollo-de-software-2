using System;
using System.Collections.Generic;

namespace final_proyect.Models2
{
    public partial class Consultorio
    {
        public Consultorio()
        {
            Cita = new HashSet<Cita>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string NombreConsultorio { get; set; } = null!;
        public string Encargado { get; set; } = null!;
        public long PisoId { get; set; }

        public virtual Piso Piso { get; set; } = null!;
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
