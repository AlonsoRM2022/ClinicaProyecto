using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ClinicaServiceImpl : IClinicaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ClinicaServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Clinica clinica)
        {
            bool res = _unidadDeTrabajo._clinicaDAL.Add(clinica);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Clinica clinica)
        {
            bool res = _unidadDeTrabajo._clinicaDAL.Remove(clinica);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Clinica GetById(int id)
        {
            Clinica clinica;
            clinica = _unidadDeTrabajo._clinicaDAL.Get(id);
            return clinica;
        }

        public async Task<IEnumerable<Clinica>> GetClinicasAsync()
        {
            IEnumerable<Clinica> clinicas = await _unidadDeTrabajo._clinicaDAL.GetAll();
            return clinicas;
        }

        public bool Update(Clinica clinica)
        {
            bool res = _unidadDeTrabajo._clinicaDAL.Update(clinica);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

