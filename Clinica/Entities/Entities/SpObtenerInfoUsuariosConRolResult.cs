using System;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities
{
    [Keyless]
    public class SpObtenerInfoUsuariosConRolResult
	{
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Clave { get; set; }
        public string? EstadoUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? NombreRol { get; set; }
    }
}

