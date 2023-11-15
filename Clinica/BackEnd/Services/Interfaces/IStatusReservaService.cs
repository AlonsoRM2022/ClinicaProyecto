using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IStatusReservaService
	{
        Task<IEnumerable<StatusReserva>> GetStatusReservasAsync();
        bool Add(StatusReserva statusReserva);
        bool Update(StatusReserva statusReserva);
        bool Delete(StatusReserva statusReserva);
        StatusReserva GetById(int id);
    }
}

