using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IDiagnosticoService
	{
        Task<IEnumerable<Diagnostico>> GetDiagnosticosAsync();
        bool Add(Diagnostico diagnostico);
        bool Update(Diagnostico diagnostico);
        bool Delete(Diagnostico diagnostico);
        Diagnostico GetById(int id);
    }
}

