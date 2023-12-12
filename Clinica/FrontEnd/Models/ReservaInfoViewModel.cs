using System;
namespace FrontEnd.Models
{
	public class ReservaInfoViewModel
	{
        public int IdReserva { get; set; }
        public int IdCita { get; set; }
        public string? NombreUsuario { get; set; }
        public int? Precio { get; set; }
        public DateTime? FechaReserva { get; set; }
        public string? EstadoReserva { get; set; }
    }
}

