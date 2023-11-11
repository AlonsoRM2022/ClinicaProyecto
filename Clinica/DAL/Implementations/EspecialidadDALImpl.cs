using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class EspecialidadDALImpl : DALGenericoImpl<Especialidad>, IEspecialidadDAL
    {
        ClinicaContext _context;

        public EspecialidadDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpObtenerInfoEspecialidadesResult>> GetEspecialidadesInfo()
        {
            List<SpObtenerInfoEspecialidadesResult> especialidades = new List<SpObtenerInfoEspecialidadesResult>();
            List<SpObtenerInfoEspecialidadesResult> results;

            string sql = "[dbo].[SpObtenerInfoEspecialidadesConEstado]";
            results = await _context.SpObtenerInfoEspecialidadesResult
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                especialidades.Add(
                    new SpObtenerInfoEspecialidadesResult
                    {
                        IdEspecialidad = item.IdEspecialidad,
                        NombreEspecialidad = item.NombreEspecialidad,
                        PrecioEspecialidad = item.PrecioEspecialidad,
                        EstadoEspecialidad = item.EstadoEspecialidad
                    }
                    );
            }
            return especialidades;
        }
    }
}

