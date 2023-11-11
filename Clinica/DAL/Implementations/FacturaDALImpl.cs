using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class FacturaDALImpl : DALGenericoImpl<Factura>, IFacturaDAL
    {
        ClinicaContext _context;

        public FacturaDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpObtenerInfoFacturasConUsuario>> GetFacturasInfo()
        {
            List<SpObtenerInfoFacturasConUsuario> facturas = new List<SpObtenerInfoFacturasConUsuario>();
            List<SpObtenerInfoFacturasConUsuario> results;

            string sql = "[dbo].[SpObtenerInfoFacturasConUsuario]";
            results = await _context.SpObtenerInfoFacturasConUsuarios
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                facturas.Add(
                    new SpObtenerInfoFacturasConUsuario
                    {
                        IdFactura = item.IdFactura,
                        Total = item.Total,
                        FechaFactura = item.FechaFactura,
                        NombreUsuario = item.NombreUsuario
                    }
                    );
            }
            return facturas;
        }
    }
}

