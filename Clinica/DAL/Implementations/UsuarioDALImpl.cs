using System;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class UsuarioDALImpl : DALGenericoImpl<Usuario>, IUsuarioDAL
    {
        ClinicaContext _context;

        public UsuarioDALImpl(ClinicaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string Correo, string Clave)
        {
            Usuario usuario = await _context.Usuarios.Where(u => u.Correo == Correo && u.Clave == Clave)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<IEnumerable<SpObtenerInfoUsuariosConRolResult>> GetUsuariosInfo()
        {
            List<SpObtenerInfoUsuariosConRolResult> usuarios = new List<SpObtenerInfoUsuariosConRolResult>();
            List<SpObtenerInfoUsuariosConRolResult> results;

            string sql = "[dbo].[SpObtenerInfoUsuariosConRol]";
            results = await _context.SpObtenerInfoUsuariosConRolResults
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in results)
            {
                usuarios.Add(
                    new SpObtenerInfoUsuariosConRolResult
                    {
                        IdUsuario = item.IdUsuario,
                        NombreUsuario = item.NombreUsuario,
                        Apellido = item.Apellido,
                        Correo = item.Correo,
                        Edad = item.Edad,
                        Direccion = item.Direccion,
                        Clave = item.Clave,
                        EstadoUsuario = item.EstadoUsuario,
                        FechaRegistro = item.FechaRegistro,
                        NombreRol = item.NombreRol
                    }
                    );
            }
            return usuarios;
        }
    }
}

