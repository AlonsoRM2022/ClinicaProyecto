using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IEspecialidadService
    {
        Task<IEnumerable<Especialidade>> GetEspecialidades();
        Task<bool> Add(Especialidade especialidad);
        Task<bool> Delete(int id);
        Task<bool> Update(Especialidade especialidad);
        Task<Especialidade> GetById(int id);
    }
}