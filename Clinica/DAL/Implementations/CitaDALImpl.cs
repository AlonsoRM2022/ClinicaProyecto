using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CitaDALImpl : DALGenericoImpl<Cita>, ICitaDAL
    {
        public CitaDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

