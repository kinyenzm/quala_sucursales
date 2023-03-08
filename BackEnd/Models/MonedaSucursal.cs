using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class MonedaSucursal
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Identificacion { get; set; } = null!;
        public int IdModena { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Monedum IdModenaNavigation { get; set; } = null!;
    }
}
