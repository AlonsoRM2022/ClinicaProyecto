using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrecioService
    {
        Task<IEnumerable<Precio>> GetPreciosAsync();
        Precio GetById(int id);
        bool AddPrecio(Precio precio);
        bool UpdatePrecio(Precio precio);
        bool DetelePrecio(Precio precio);


    }
}