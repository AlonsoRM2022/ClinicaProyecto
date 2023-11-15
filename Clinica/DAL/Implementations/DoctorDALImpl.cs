using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
	public class DoctorDALImpl : DALGenericoImpl<Doctor>, IDoctorDAL
	{
		public DoctorDALImpl(ClinicaContext context) : base(context)
		{
		}
	}
}

