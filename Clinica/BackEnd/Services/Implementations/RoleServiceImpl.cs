using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RoleServiceImpl : IRoleService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public RoleServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Role role)
        {
            bool res = _unidadDeTrabajo._roleDAL.Add(role);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Role role)
        {
            bool res = _unidadDeTrabajo._roleDAL.Remove(role);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Role GetById(int id)
        {
            Role role;
            role = _unidadDeTrabajo._roleDAL.Get(id);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            IEnumerable<Role> rolees = await _unidadDeTrabajo._roleDAL.GetAll();
            return rolees;
        }

        public bool Update(Role role)
        {
            bool res = _unidadDeTrabajo._roleDAL.Update(role);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

