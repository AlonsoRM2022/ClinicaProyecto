using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IUsuarioService
	{
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task<IEnumerable<SpObtenerInfoUsuariosConRolResult>> GetUsuariosInfo();
        bool Add(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(Usuario usuario);
        Usuario GetById(int id);
<<<<<<< Updated upstream
        Task<Usuario> GetUsuario(string Correo, string Clave);
=======

        Task<SpIniciarSesionResult> GetUsuarioInfo(string Correo, string Clave);
>>>>>>> Stashed changes
    }
}
