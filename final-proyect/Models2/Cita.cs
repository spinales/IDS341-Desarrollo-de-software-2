using System;
using System.Collections.Generic;

namespace final_proyect.Models2
{
    public partial class Cita
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Paciente { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public long ConsultorioId { get; set; }

        public virtual Consultorio Consultorio { get; set; } = null!;
    }
}
