using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IDoctorService
	{
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        bool Add(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Doctor doctor);
        Doctor GetById(int id);
    }
}

