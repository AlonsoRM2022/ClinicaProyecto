using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class FacturaDALImpl : DALGenericoImpl<Factura>, IFacturaDAL
    {
        public FacturaDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

