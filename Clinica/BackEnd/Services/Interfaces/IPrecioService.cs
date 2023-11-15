using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IPrecioService
	{
        Task<IEnumerable<Precio>> GetPreciosAsync();
        bool Add(Precio precio);
        bool Update(Precio precio);
        bool Delete(Precio precio);
        Precio GetById(int id);
    }
}

