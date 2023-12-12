using System;
namespace FrontEnd.Models
{
    public class FacturaInfoViewModel
	{
        public int IdFactura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public int? Total { get; set; }
        public string? NombreUsuario { get; set; }
    }
}

