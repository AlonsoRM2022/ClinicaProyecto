using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IEspecialidadHelper
    {
        List<EspecialidadViewModel> GetAll();
        EspecialidadViewModel GetById(int id);
        EspecialidadViewModel AddEspecialidad(EspecialidadViewModel EspecialidadViewModel);
        EspecialidadViewModel EditEspecialidad(EspecialidadViewModel EspecialidadViewModel);
        void DeleteEspecialidad(int id);
    }
}
