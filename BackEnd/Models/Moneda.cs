using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            Sucursales = new HashSet<Sucursale>();
        }

        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Sucursale> Sucursales { get; set; }
    }
}
