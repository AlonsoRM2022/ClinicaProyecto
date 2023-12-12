using System;
namespace FrontEnd.Models
{
	public class DiagnosticoInfoViewModel
	{
        public int IdDiagnostico { get; set; }
        public string? Descripcion { get; set; }
        public string? Recomendacion { get; set; }
        public string? NombreDoctor { get; set; }
        public string? NombreUsuario { get; set; }
    }
}

