using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoFacturasConUsuario
	{
        public int IdFactura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public int? Total { get; set; }
        public string? NombreUsuario { get; set; }
	}
}

