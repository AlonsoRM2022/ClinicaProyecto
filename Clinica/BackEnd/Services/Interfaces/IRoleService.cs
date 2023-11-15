using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IRoleService
	{
        Task<IEnumerable<Role>> GetRolesAsync();
        bool Add(Role role);
        bool Update(Role role);
        bool Delete(Role role);
        Role GetById(int id);
    }
}

