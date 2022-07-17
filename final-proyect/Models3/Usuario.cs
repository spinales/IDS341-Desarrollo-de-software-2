using System;
using System.Collections.Generic;

namespace final_proyect.Models3
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
