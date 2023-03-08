using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class Monedum
    {
        public Monedum()
        {
            MonedaSucursals = new HashSet<MonedaSucursal>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<MonedaSucursal> MonedaSucursals { get; set; }
    }
}
