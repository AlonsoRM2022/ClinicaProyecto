using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IHorarioHelper
    {
        List<HorarioViewModel> GetAll();
        HorarioViewModel GetById(int id);
        HorarioViewModel AddHorario(HorarioViewModel horarioViewModel);
        HorarioViewModel EditHorario(HorarioViewModel horarioViewModel);
        void DeleteHorario(int id);
    }
}
