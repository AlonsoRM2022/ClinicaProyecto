using Entities.Entities;
using System.Numerics;

namespace BackEnd.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctore>> GetDoctoresAsync();
        Doctore GetById(int id);
        bool AddDoctor(Doctore doctor);
        bool UpdateDoctor(Doctore doctor);
        bool DeteleDoctor(Doctore doctor);


    }
}