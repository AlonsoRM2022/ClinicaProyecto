using System;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IReservaDAL : IDALGenerico<Reserva>
    {
        Task<IEnumerable<SpObtenerInfoReservasResult>> GetReservasInfo();
    }
}

