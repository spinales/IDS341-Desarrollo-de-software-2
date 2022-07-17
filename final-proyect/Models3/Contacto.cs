using System;
using System.Collections.Generic;

namespace final_proyect.Models3
{
    public partial class Contacto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroTelefonico { get; set; } = null!;
    }
}
