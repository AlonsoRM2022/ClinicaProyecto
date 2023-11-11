using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CitaServiceImpl : ICitaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CitaServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Cita cita)
        {
            bool res = _unidadDeTrabajo._citaDAL.Add(cita);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Cita cita)
        {
            bool res = _unidadDeTrabajo._citaDAL.Remove(cita);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Cita GetById(int id)
        {
            Cita cita;
            cita = _unidadDeTrabajo._citaDAL.Get(id);
            return cita;
        }

        public async Task<IEnumerable<Cita>> GetCitasAsync()
        {
            IEnumerable<Cita> citas = await _unidadDeTrabajo._citaDAL.GetAll();
            return citas;
        }

        public async Task<IEnumerable<SpObtenerInfoCitasResult>> GetCitasInfo()
        {
            IEnumerable<SpObtenerInfoCitasResult> citas = await _unidadDeTrabajo._citaDAL.GetCitasInfo();
            return citas;
        }

        public bool Update(Cita cita)
        {
            bool res = _unidadDeTrabajo._citaDAL.Update(cita);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }
}

