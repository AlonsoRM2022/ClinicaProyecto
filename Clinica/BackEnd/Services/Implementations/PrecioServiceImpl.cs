using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PrecioServiceImpl : IPrecioService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PrecioServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Precio precio)
        {
            bool res = _unidadDeTrabajo._precioDAL.Add(precio);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Precio precio)
        {
            bool res = _unidadDeTrabajo._precioDAL.Remove(precio);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Precio GetById(int id)
        {
            Precio precio;
            precio = _unidadDeTrabajo._precioDAL.Get(id);
            return precio;
        }

        public async Task<IEnumerable<Precio>> GetPreciosAsync()
        {
            IEnumerable<Precio> precios = await _unidadDeTrabajo._precioDAL.GetAll();
            return precios;
        }

        public bool Update(Precio precio)
        {
            bool res = _unidadDeTrabajo._precioDAL.Update(precio);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

