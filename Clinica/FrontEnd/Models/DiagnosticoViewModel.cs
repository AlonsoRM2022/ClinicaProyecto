using System;
namespace FrontEnd.Models
{
	public class DiagnosticoViewModel
	{
        public int IdDiagnostico { get; set; }
        public string? Descripcion { get; set; }
        public string? Recomendacion { get; set; }
        public int? IdReserva { get; set; }

        public IEnumerable<ReservaInfoViewModel> Reservas { get; set; }
    }
}

