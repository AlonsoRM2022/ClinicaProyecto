using System;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IFacturaDAL : IDALGenerico<Factura>
    {
        Task<IEnumerable<SpObtenerInfoFacturasConUsuario>> GetFacturasInfo();
    }
}

