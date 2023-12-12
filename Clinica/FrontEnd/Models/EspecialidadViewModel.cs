namespace FrontEnd.Models
{
    public class EspecialidadViewModel
    {
        public int IdEspecialidad { get; set; }
        public string? Nombre { get; set; }
        public int? IdPrecio { get; set; }
        public IEnumerable<PrecioViewModel> Precios { get; set; }

        public bool? StatusEspecialidad { get; set; }
        
    }
}
