using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class DiagnosticoDALImpl : DALGenericoImpl<Diagnostico>, IDiagnosticoDAL
    {
        public DiagnosticoDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

