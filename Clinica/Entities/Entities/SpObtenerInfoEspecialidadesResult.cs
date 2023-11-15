using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoEspecialidadesResult
	{
        public int IdEspecialidad { get; set; }
        public string? NombreEspecialidad { get; set; }
        public int? PrecioEspecialidad { get; set; }
        public string? EstadoEspecialidad { get; set; }
    }
}

