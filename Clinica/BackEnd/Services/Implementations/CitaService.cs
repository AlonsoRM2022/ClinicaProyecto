using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CitaService : ICitaService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;

        public CitaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Task<bool> Add(Cita cita)
        {
            try
            {
                _unidadDeTrabajo._citaDAL.Add(cita);
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
                Cita cita = new Cita { IdCita = id };
                _unidadDeTrabajo._citaDAL.Remove(cita);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }


        }

        public async Task<Cita> GetById(int id)
        {
            Cita cita = _unidadDeTrabajo._citaDAL.Get(id);
            return cita;
        }



        public async Task<IEnumerable<Cita>> GetCitas()
        {
            IEnumerable<Cita> citas = await _unidadDeTrabajo._citaDAL.GetAll();
            return citas;
        }



        public Task<bool> Update(Cita cita)
        {
            try
            {
                _unidadDeTrabajo._citaDAL.Update(cita);
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
