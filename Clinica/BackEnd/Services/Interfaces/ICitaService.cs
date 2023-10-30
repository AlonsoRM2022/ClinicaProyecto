using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICitaService
    {
        Task<IEnumerable<Cita>> GetCitas();
        Task<bool> Add(Cita cita);
        Task<bool> Delete(int id);
        Task<bool> Update(Cita cita);
        Task<Cita> GetById(int id);
    }
}