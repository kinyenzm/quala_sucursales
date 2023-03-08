using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class Sucursale
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public string Moneda { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual Moneda MonedaNavigation { get; set; } = null!;
    }
}
