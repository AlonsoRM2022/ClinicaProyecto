using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class ReservaDALImpl : DALGenericoImpl<Reserva>, IReservaDAL
    {
        public ReservaDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

