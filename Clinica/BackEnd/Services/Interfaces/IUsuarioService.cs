using System;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
	public interface IUsuarioService
	{
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        bool Add(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(Usuario usuario);
        Usuario GetById(int id);

    }
}

