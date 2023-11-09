using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class StatusReservaServiceImpl : IStatusReservaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public StatusReservaServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(StatusReserva statusReserva)
        {
            bool res = _unidadDeTrabajo._statusReservaDAL.Add(statusReserva);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(StatusReserva statusReserva)
        {
            bool res = _unidadDeTrabajo._statusReservaDAL.Remove(statusReserva);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public StatusReserva GetById(int id)
        {
            StatusReserva statusReserva;
            statusReserva = _unidadDeTrabajo._statusReservaDAL.Get(id);
            return statusReserva;
        }

        public async Task<IEnumerable<StatusReserva>> GetStatusReservasAsync()
        {
            IEnumerable<StatusReserva> statusReservas = await _unidadDeTrabajo._statusReservaDAL.GetAll();
            return statusReservas;
        }

        public bool Update(StatusReserva statusReserva)
        {
            bool res = _unidadDeTrabajo._statusReservaDAL.Update(statusReserva);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

