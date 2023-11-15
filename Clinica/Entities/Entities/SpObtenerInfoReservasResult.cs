using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoReservasResult
	{
        public int IdReserva { get; set; }
        public int IdCita { get; set; }
        public string? NombreUsuario { get; set; }
        public int? Precio { get; set; }
        public DateTime? FechaReserva { get; set; }
        public string? EstadoReserva { get; set; }
    }
}

