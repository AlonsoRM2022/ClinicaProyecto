using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class EspecialidadDALImpl : DALGenericoImpl<Especialidad>, IEspecialidadDAL
    {
        public EspecialidadDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

