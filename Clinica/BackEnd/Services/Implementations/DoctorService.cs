using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Numerics;

namespace BackEnd.Services.Implementations
{
    public class DoctorService : IDoctorService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public DoctorService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddDoctor(Doctore doctor)
        {
            bool resultado = _unidadDeTrabajo._doctorDAL.Add(doctor);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeteleDoctor(Doctore doctor)
        {
            bool resultado = _unidadDeTrabajo._doctorDAL.Remove(doctor);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Doctore GetById(int id)
        {
            Doctore doctor;
            doctor = _unidadDeTrabajo._doctorDAL.Get(id);
            return doctor;
        }

        public async Task<IEnumerable<Doctore>> GetDoctoresAsync()
        {
            IEnumerable<Doctore> doctores;
            doctores = await _unidadDeTrabajo._doctorDAL.GetAll();
            return doctores;
        }

        public bool UpdateDoctor(Doctore doctor)
        {
            bool resultado = _unidadDeTrabajo._doctorDAL.Update(doctor);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}

