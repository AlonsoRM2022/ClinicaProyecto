using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IEspecialidadService
	{
        Task<IEnumerable<Especialidad>> GetEspecialidadesAsync();
        bool Add(Especialidad especialidad);
        bool Update(Especialidad especialidad);
        bool Delete(Especialidad especialidad);
        Especialidad GetById(int id);
    }
}

