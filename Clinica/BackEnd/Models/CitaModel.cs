namespace BackEnd.Models
{
    public class CitaModel
    {
        public int IdCita { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdEspecialidad { get; set; }
        public int? IdClinica { get; set; }
        public int? IdHorario { get; set; }
        public bool? StatusCita { get; set; }
    }
}
