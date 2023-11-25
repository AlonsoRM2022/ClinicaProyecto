using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDoctorHelper
    {
        string Token { get; set; }
        List<DoctorViewModel> GetAll();
        DoctorViewModel GetById(int id);
        DoctorViewModel AddDoctor(DoctorViewModel doctorViewModel);
        DoctorViewModel EditDoctor(DoctorViewModel doctorViewModel);
        void DeleteDoctor(int id);
    }
}