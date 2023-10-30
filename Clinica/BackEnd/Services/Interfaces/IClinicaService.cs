using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IClinicaService
    {
        Task<IEnumerable<Clinica>> GetClinicasAsync();
        Clinica GetById(int id);
        bool AddClinica(Clinica clinica);
        bool UpdateClinica(Clinica clinica);
        bool DeteleClinica(Clinica clinica);


    }
}