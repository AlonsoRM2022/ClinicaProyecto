using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoDiagnosticosResult
	{
        public int IdDiagnostico { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreDoctor { get; set; }
        public string? NombreUsuario { get; set; }
    }
}

