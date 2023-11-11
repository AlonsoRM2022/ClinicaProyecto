using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ReservaServiceImpl : IReservaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ReservaServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Reserva reserva)
        {
            bool res = _unidadDeTrabajo._reservaDAL.Add(reserva);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Reserva reserva)
        {
            bool res = _unidadDeTrabajo._reservaDAL.Remove(reserva);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Reserva GetById(int id)
        {
            Reserva reserva;
            reserva = _unidadDeTrabajo._reservaDAL.Get(id);
            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetReservasAsync()
        {
            IEnumerable<Reserva> reservas = await _unidadDeTrabajo._reservaDAL.GetAll();
            return reservas;
        }

        public async Task<IEnumerable<SpObtenerInfoReservasResult>> GetReservasInfo()
        {
            IEnumerable<SpObtenerInfoReservasResult> citas = await _unidadDeTrabajo._reservaDAL.GetReservasInfo();
            return citas;
        }

        public bool Update(Reserva reserva)
        {
            bool res = _unidadDeTrabajo._reservaDAL.Update(reserva);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

