using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IReservaService
	{
        Task<IEnumerable<Reserva>> GetReservasAsync();
        Task<IEnumerable<SpObtenerInfoReservasResult>> GetReservasInfo();
        bool Add(Reserva reserva);
        bool Update(Reserva reserva);
        bool Delete(Reserva reserva);
        Reserva GetById(int id);
    }
}

