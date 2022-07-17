using System;
using System.Collections.Generic;

namespace final_proyect.Models2
{
    public partial class Carro
    {
        public int Id { get; set; }
        public string Estado { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Año { get; set; } = null!;
        public string Precio { get; set; } = null!;
    }
}
