using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface ICitaService
	{
        Task<IEnumerable<Cita>> GetCitasAsync();
        Task<IEnumerable<SpObtenerInfoCitasResult>> GetCitasInfo();
        bool Add(Cita cita);
        bool Update(Cita cita);
        bool Delete(Cita cita);
        Cita GetById(int id);
    }
}

