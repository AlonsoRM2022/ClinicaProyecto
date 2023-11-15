using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class PrecioDALImpl : DALGenericoImpl<Precio>, IPrecioDAL
    {
        public PrecioDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

