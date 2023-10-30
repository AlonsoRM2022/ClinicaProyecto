using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IPrecioDAL _precioDAL { get; }
        public IClinicaDAL _clinicaDAL { get; }
        public IDoctorDAL _doctorDAL { get; }
        public IHorarioDAL _horarioDAL { get; }
        public IEspecialidadDAL _especialidadDAL { get; }
        public ICitaDAL _citaDAL { get; }



        private readonly ClinicaContext _context;

        public UnidadDeTrabajo(ClinicaContext context,
                                IPrecioDAL precioDAL,
                                IClinicaDAL clinicaDAL,
                                IDoctorDAL doctorDAL,
                                IHorarioDAL horarioDAL,
                                IEspecialidadDAL especialidadDAL,
                                ICitaDAL citaDAL)
        {
            _context = context;
            _precioDAL = precioDAL;
            _clinicaDAL = clinicaDAL;
            _doctorDAL = doctorDAL;
            _horarioDAL = horarioDAL;
            _especialidadDAL = especialidadDAL;
            _citaDAL = citaDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}