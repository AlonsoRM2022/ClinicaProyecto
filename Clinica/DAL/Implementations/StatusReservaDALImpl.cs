using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class StatusReservaDALImpl : DALGenericoImpl<StatusReserva>, IStatusReservaDAL
    {
        public StatusReservaDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

