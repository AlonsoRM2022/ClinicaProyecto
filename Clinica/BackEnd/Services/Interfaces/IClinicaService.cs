using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IClinicaService
	{
        Task<IEnumerable<Clinica>> GetClinicasAsync();
        bool Add(Clinica clinica);
        bool Update(Clinica clinica);
        bool Delete(Clinica clinica);
        Clinica GetById(int id);

    }
}

