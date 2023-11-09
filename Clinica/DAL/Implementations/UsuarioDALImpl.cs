using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UsuarioDALImpl : DALGenericoImpl<Usuario>, IUsuarioDAL
    {
        public UsuarioDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

