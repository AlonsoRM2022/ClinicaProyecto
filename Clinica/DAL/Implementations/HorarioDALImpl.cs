using System;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class HorarioDALImpl : DALGenericoImpl<Horario>, IHorarioDAL
    {
        public HorarioDALImpl(ClinicaContext context) : base(context)
        {
        }
    }
}

