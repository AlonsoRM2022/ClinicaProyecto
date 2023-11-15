using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class FacturaServiceImpl : IFacturaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public FacturaServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Factura factura)
        {
            bool res = _unidadDeTrabajo._facturaDAL.Add(factura);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Factura factura)
        {
            bool res = _unidadDeTrabajo._facturaDAL.Remove(factura);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Factura GetById(int id)
        {
            Factura facturas;
            facturas = _unidadDeTrabajo._facturaDAL.Get(id);
            return facturas;
        }

        public async Task<IEnumerable<Factura>> GetFacturasAsync()
        {
            IEnumerable<Factura> facturas = await _unidadDeTrabajo._facturaDAL.GetAll();
            return facturas;
        }

        public async Task<IEnumerable<SpObtenerInfoFacturasConUsuario>> GetFacturasInfo()
        {
            IEnumerable<SpObtenerInfoFacturasConUsuario> facturas = await _unidadDeTrabajo._facturaDAL.GetFacturasInfo();
            return facturas;
        }

        public bool Update(Factura factura)
        {
            bool res = _unidadDeTrabajo._facturaDAL.Update(factura);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

