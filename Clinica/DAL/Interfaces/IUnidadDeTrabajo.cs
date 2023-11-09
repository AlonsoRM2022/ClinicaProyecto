using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ICitaDAL _citaDAL { get; }
        IClinicaDAL _clinicaDAL { get; }
        IDiagnosticoDAL _diagnosticoDAL { get; }
        IDoctorDAL _doctorDAL { get; }
        IEspecialidadDAL _especialidadDAL { get; }
        IFacturaDAL _facturaDAL { get; }
        IHorarioDAL _horarioDAL { get; }
        IPrecioDAL _precioDAL { get; }
        IReservaDAL _reservaDAL { get; }
        IRoleDAL _roleDAL { get; }
        IStatusReservaDAL _statusReservaDAL { get; }
        IUsuarioDAL _usuarioDAL { get; }
        bool Complete();
    }
}