using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class CitaDALImpl : DALGenericoImpl<Cita>, ICitaDAL
    {

        ClinicaContext _context;

        public CitaDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpObtenerInfoCitasResult>> GetCitasInfo()
        {
            List<SpObtenerInfoCitasResult> citas = new List<SpObtenerInfoCitasResult>();
            List<SpObtenerInfoCitasResult> results;

            string sql = "[dbo].[SpObtenerInfoCitas]";
            results = await _context.SpObtenerInfoCitasResults
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                citas.Add(
                    new SpObtenerInfoCitasResult
                    {
                        IdCita = item.IdCita,
                        NombreDoctor = item.NombreDoctor,
                        NombreEspecialidad = item.NombreEspecialidad,
                        NombreClinica = item.NombreClinica,
                        DiaHorario = item.DiaHorario,
                        HoraHorario = item.HoraHorario
                    }
                    );
            }
            return citas;
        }
    }
}

    