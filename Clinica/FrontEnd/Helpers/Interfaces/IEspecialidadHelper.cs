using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IEspecialidadHelper
    {
        string Token { get; set; }
        List<EspecialidadViewModel> GetAll();
        List<EspecialidadInfoViewModel> GetEspecialidadInfoAll();
        EspecialidadViewModel GetById(int id);
        EspecialidadViewModel AddEspecialidad(EspecialidadViewModel EspecialidadViewModel);
        EspecialidadViewModel EditEspecialidad(EspecialidadViewModel EspecialidadViewModel);
        void DeleteEspecialidad(int id);
    }
}
