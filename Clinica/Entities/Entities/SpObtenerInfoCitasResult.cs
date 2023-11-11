using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoCitasResult
	{
        public int IdCita { get; set; }
        public string? NombreDoctor { get; set; }
        public string? NombreEspecialidad { get; set; }
        public string? NombreClinica { get; set; }
        public string? DiaHorario { get; set; }
        public string? HoraHorario { get; set; }
    }
}

