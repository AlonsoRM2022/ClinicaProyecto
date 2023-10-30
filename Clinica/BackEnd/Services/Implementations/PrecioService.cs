using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PrecioService : IPrecioService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PrecioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddPrecio(Precio precio)
        {
            bool resultado = _unidadDeTrabajo._precioDAL.Add(precio);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DetelePrecio(Precio precio)
        {
            bool resultado = _unidadDeTrabajo._precioDAL.Remove(precio);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Precio GetById(int id)
        {
            Precio precio;
            precio = _unidadDeTrabajo._precioDAL.Get(id);
            return precio;
        }

        public async Task<IEnumerable<Precio>> GetPreciosAsync()
        {
            IEnumerable<Precio> precios;
            precios = await _unidadDeTrabajo._precioDAL.GetAll();
            return precios;
        }

        public bool UpdatePrecio(Precio precio)
        {
            bool resultado = _unidadDeTrabajo._precioDAL.Update(precio);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
