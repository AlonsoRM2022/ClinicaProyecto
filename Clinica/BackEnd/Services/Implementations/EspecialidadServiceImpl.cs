using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EspecialidadServiceImpl : IEspecialidadService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public EspecialidadServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Especialidad especialidad)
        {
            bool res = _unidadDeTrabajo._especialidadDAL.Add(especialidad);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Especialidad especialidad)
        {
            bool res = _unidadDeTrabajo._especialidadDAL.Remove(especialidad);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Especialidad GetById(int id)
        {
            Especialidad especialidad;
            especialidad = _unidadDeTrabajo._especialidadDAL.Get(id);
            return especialidad;
        }

        public async Task<IEnumerable<Especialidad>> GetEspecialidadesAsync()
        {
            IEnumerable<Especialidad> especialidades = await _unidadDeTrabajo._especialidadDAL.GetAll();
            return especialidades;
        }

        public async Task<IEnumerable<SpObtenerInfoEspecialidadesResult>> GetEspecialidadesInfo()
        {
            IEnumerable<SpObtenerInfoEspecialidadesResult> especialidades = await _unidadDeTrabajo._especialidadDAL.GetEspecialidadesInfo();
            return especialidades;
        }

        public bool Update(Especialidad especialidad)
        {
            bool res = _unidadDeTrabajo._especialidadDAL.Update(especialidad);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

