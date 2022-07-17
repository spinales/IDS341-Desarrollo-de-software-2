using System;
using System.Collections.Generic;

namespace final_proyect.Models3
{
    public partial class Task
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Finished { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
