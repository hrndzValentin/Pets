using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class Mascotum
    {
        public int? Dueño { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public string? Veterinario { get; set; }
    }
}
