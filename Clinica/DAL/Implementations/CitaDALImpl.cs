
using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CitaDALImpl : DALGenericoImpl<Cita>, ICitaDAL
    {
        public CitaDALImpl(ClinicaContext context) : base(context)
        {

        }
    }
}
