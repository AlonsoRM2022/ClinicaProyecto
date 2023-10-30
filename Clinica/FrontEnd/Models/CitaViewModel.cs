namespace FrontEnd.Models
{
    public class CitaViewModel
    {
        public int IdCita { get; set; }
        public int? IdDoctor { get; set; }
        public IEnumerable<DoctorViewModel> Doctores { get; set; }


        public int? IdEspecialidad { get; set; }
        public IEnumerable<EspecialidadViewModel> Especialidades { get; set; }


        public int? IdClinica { get; set; }
        public IEnumerable<ClinicaViewModel> Clinicas { get; set; }


        public int? IdHorario { get; set; }
        public IEnumerable<HorarioViewModel> Horarios { get; set; }


        public bool? StatusCita { get; set; }
    }
}
