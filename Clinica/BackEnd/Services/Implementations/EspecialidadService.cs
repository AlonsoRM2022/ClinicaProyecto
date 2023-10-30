using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EspecialidadService : IEspecialidadService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public EspecialidadService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Task<bool> Add(Especialidade especialidad)
        {
            try
            {
                _unidadDeTrabajo._especialidadDAL.Add(especialidad);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }


        }

        public Task<bool> Delete(int id)
        {
            try
            {
                Especialidade especialidad = new Especialidade { IdEspecialidad = id };
                _unidadDeTrabajo._especialidadDAL.Remove(especialidad);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }


        }

        public async Task<Especialidade> GetById(int id)
        {
            Especialidade especialidad = _unidadDeTrabajo._especialidadDAL.Get(id);
            return especialidad;
        }



        public async Task<IEnumerable<Especialidade>> GetEspecialidades()
        {
            IEnumerable<Especialidade> especialidades = await _unidadDeTrabajo._especialidadDAL.GetAll();
            return especialidades;
        }



        public Task<bool> Update(Especialidade especialidad)
        {
            try
            {
                _unidadDeTrabajo._especialidadDAL.Update(especialidad);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }


        }
    }
}
