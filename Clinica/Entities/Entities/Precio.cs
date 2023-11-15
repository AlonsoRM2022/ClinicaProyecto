using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Precio
    {
        public Precio()
        {
            Especialidads = new HashSet<Especialidad>();
        }

        public int IdPrecio { get; set; }
        public int? Valor { get; set; }

        public virtual ICollection<Especialidad> Especialidads { get; set; }
    }
}
