using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IPrecioDAL _precioDAL { get; }
        IClinicaDAL _clinicaDAL { get; }
        IDoctorDAL _doctorDAL { get; }
        IHorarioDAL _horarioDAL { get; }
        IEspecialidadDAL _especialidadDAL { get; }
        ICitaDAL _citaDAL { get; }
        bool Complete();
    }
}