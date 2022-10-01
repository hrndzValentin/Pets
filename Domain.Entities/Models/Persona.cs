using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string Direccion { get; set; } = null!;
        public string? Telefono { get; set; }
    }
}
