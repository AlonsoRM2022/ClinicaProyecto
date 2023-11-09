using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IHorarioService
	{
        Task<IEnumerable<Horario>> GetHorariosAsync();
        bool Add(Horario horario);
        bool Update(Horario horario);
        bool Delete(Horario horario);
        Horario GetById(int id);
    }
}

