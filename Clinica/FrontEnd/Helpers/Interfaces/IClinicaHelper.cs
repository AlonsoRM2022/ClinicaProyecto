using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IClinicaHelper
    {
        string Token { get; set; }
        List<ClinicaViewModel> GetAll();
        ClinicaViewModel GetById(int id);
        ClinicaViewModel AddClinica(ClinicaViewModel clinicaViewModel);
        ClinicaViewModel EditClinica(ClinicaViewModel clinicaViewModel);
        void DeleteClinica(int id);
    }
}
