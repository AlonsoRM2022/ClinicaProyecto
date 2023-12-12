using System;
namespace FrontEnd.Models
{
	public class CitaInfoViewModel
	{
        public int IdCita { get; set; }
        public string? NombreDoctor { get; set; }
        public string? NombreEspecialidad { get; set; }
        public string? NombreClinica { get; set; }
        public string? DiaHorario { get; set; }
        public string? HoraHorario { get; set; }
    }
}

