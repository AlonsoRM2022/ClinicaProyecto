using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class ClinicaDALImpl : DALGenericoImpl<Clinica>, IClinicaDAL
    {
        public ClinicaDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

