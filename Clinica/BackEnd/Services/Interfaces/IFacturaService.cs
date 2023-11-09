using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IFacturaService
	{
        Task<IEnumerable<Factura>> GetFacturasAsync();
        bool Add(Factura factura);
        bool Update(Factura factura);
        bool Delete(Factura factura);
        Factura GetById(int id);
    }
}

