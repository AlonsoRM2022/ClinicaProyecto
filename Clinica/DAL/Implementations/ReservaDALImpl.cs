using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ReservaDALImpl : DALGenericoImpl<Reserva>, IReservaDAL
    {
        ClinicaContext _context;

        public ReservaDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpObtenerInfoReservasResult>> GetReservasInfo()
        {
            List<SpObtenerInfoReservasResult> reservas = new List<SpObtenerInfoReservasResult>();
            List<SpObtenerInfoReservasResult> results;

            string sql = "[dbo].[SpObtenerInfoCompletaReservas]";
            results = await _context.SpObtenerInfoReservasResults
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                reservas.Add(
                    new SpObtenerInfoReservasResult
                    {
                        IdReserva = item.IdReserva,
                        IdCita = item.IdCita,
                        NombreUsuario = item.NombreUsuario,
                        Precio = item.Precio,
                        FechaReserva = item.FechaReserva,
                        EstadoReserva = item.EstadoReserva
                    }
                    );
            }
            return reservas;
        }
    }
}

