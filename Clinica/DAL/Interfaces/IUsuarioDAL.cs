using System;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IUsuarioDAL : IDALGenerico<Usuario>
    {
        Task<IEnumerable<SpObtenerInfoUsuariosConRolResult>> GetUsuariosInfo();
<<<<<<< Updated upstream

        Task<Usuario> GetUsuario(string Correo, string Clave);
=======
        Task<SpIniciarSesionResult> GetUsuarioInfo(string Correo, string Clave);
>>>>>>> Stashed changes
    }
}

