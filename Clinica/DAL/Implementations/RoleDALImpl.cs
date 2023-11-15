using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class RoleDALImpl : DALGenericoImpl<Role>, IRoleDAL
    {
        public RoleDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

