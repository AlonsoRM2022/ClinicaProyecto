using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IEspecialidadService
	{
        Task<IEnumerable<Especialidad>> GetEspecialidadesAsync();
        Task<IEnumerable<SpObtenerInfoEspecialidadesResult>> GetEspecialidadesInfo();
        bool Add(Especialidad especialidad);
        bool Update(Especialidad especialidad);
        bool Delete(Especialidad especialidad);
        Especialidad GetById(int id);
    }
}

