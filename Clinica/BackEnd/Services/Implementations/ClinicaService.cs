using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ClinicaService : IClinicaService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ClinicaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddClinica(Clinica clinica)
        {
            bool resultado = _unidadDeTrabajo._clinicaDAL.Add(clinica);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeteleClinica(Clinica clinica)
        {
            bool resultado = _unidadDeTrabajo._clinicaDAL.Remove(clinica);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Clinica GetById(int id)
        {
            Clinica clinica;
            clinica = _unidadDeTrabajo._clinicaDAL.Get(id);
            return clinica;
        }

        public async Task<IEnumerable<Clinica>> GetClinicasAsync()
        {
            IEnumerable<Clinica> clinicas;
            clinicas = await _unidadDeTrabajo._clinicaDAL.GetAll();
            return clinicas;
        }

        public bool UpdateClinica(Clinica clinica)
        {
            bool resultado = _unidadDeTrabajo._clinicaDAL.Update(clinica);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
