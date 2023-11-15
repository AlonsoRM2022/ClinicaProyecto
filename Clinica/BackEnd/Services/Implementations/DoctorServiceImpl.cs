using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class DoctorServiceImpl : IDoctorService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public DoctorServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Doctor doctor)
        {
            bool res = _unidadDeTrabajo._doctorDAL.Add(doctor);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Doctor doctor)
        {
            bool res = _unidadDeTrabajo._doctorDAL.Remove(doctor);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Doctor GetById(int id)
        {
            Doctor doctor;
            doctor = _unidadDeTrabajo._doctorDAL.Get(id);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            IEnumerable<Doctor> doctors = await _unidadDeTrabajo._doctorDAL.GetAll();
            return doctors;
        }

        public bool Update(Doctor doctor)
        {
            bool res = _unidadDeTrabajo._doctorDAL.Update(doctor);
            _unidadDeTrabajo.Complete();
            return res;
        }
	}
}

