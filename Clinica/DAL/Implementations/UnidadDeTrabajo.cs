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
        public ICitaDAL _citaDAL { get; }
        public IClinicaDAL _clinicaDAL { get; }
        public IDiagnosticoDAL _diagnosticoDAL { get; }
        public IDoctorDAL _doctorDAL { get; }
        public IEspecialidadDAL _especialidadDAL { get; }
        public IFacturaDAL _facturaDAL { get; }
        public IHorarioDAL _horarioDAL { get; }
        public IPrecioDAL _precioDAL { get; }
        public IReservaDAL _reservaDAL { get; }
        public IRoleDAL _roleDAL { get; }
        public IStatusReservaDAL _statusReservaDAL { get; }
        public IUsuarioDAL _usuarioDAL { get; }

        private readonly ClinicaContext _context;

        public UnidadDeTrabajo(
             ClinicaContext context,
             ICitaDAL citaDAL,
             IClinicaDAL clinicaDAL,
             IDiagnosticoDAL diagnosticoDAL,
             IDoctorDAL doctorDAL,
             IEspecialidadDAL especialidadDAL,
             IFacturaDAL facturasDAL,
             IHorarioDAL horarioDAL,
             IPrecioDAL precioDAL,
             IReservaDAL reservaDAL,
             IRoleDAL roleDAL,
             IStatusReservaDAL statusReservaDAL,
             IUsuarioDAL usuarioDAL)
        {
            _context = context;
            _citaDAL = citaDAL;
            _clinicaDAL = clinicaDAL;
            _diagnosticoDAL = diagnosticoDAL;
            _doctorDAL = doctorDAL;
            _especialidadDAL = especialidadDAL;
            _facturaDAL = facturasDAL;
            _horarioDAL = horarioDAL;
            _precioDAL = precioDAL;
            _reservaDAL = reservaDAL;
            _roleDAL = roleDAL;
            _statusReservaDAL = statusReservaDAL;
            _usuarioDAL = usuarioDAL;
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