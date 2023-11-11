using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class DiagnosticoDALImpl : DALGenericoImpl<Diagnostico>, IDiagnosticoDAL
    {
        ClinicaContext _context;

        public DiagnosticoDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpObtenerInfoDiagnosticosResult>> GetDiagnosticosInfo()
        {
            List<SpObtenerInfoDiagnosticosResult> diagnosticos = new List<SpObtenerInfoDiagnosticosResult>();
            List<SpObtenerInfoDiagnosticosResult> results;

            string sql = "[dbo].[SpObtenerInfoDiagnosticoConDoctorYUsuario]";
            results = await _context.SpObtenerInfoDiagnosticosResults
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                diagnosticos.Add(
                    new SpObtenerInfoDiagnosticosResult
                    {
                        IdDiagnostico = item.IdDiagnostico,
                        Descripcion = item.Descripcion,
                        NombreDoctor = item.NombreDoctor,
                        NombreUsuario = item.NombreUsuario
                    }
                    );
            }
            return diagnosticos;
        }
    }
}

