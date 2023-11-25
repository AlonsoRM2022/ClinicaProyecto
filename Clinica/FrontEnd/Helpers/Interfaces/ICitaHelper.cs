using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICitaHelper
    {
        string Token { get; set; }
        List<CitaViewModel> GetAll();
        CitaViewModel GetById(int id);
        CitaViewModel AddCita(CitaViewModel CitaViewModel);
        CitaViewModel EditCita(CitaViewModel CitaViewModel);
        void DeleteCita(int id);
    }
}
