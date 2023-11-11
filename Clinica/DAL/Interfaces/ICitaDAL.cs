using System;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface ICitaDAL : IDALGenerico<Cita>
    {
        Task<IEnumerable<SpObtenerInfoCitasResult>> GetCitasInfo();
    }
}

