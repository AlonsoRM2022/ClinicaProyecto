using System;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioServiceImpl(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(Usuario usuario)
        {
            bool res = _unidadDeTrabajo._usuarioDAL.Add(usuario);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public bool Delete(Usuario usuario)
        {
            bool res = _unidadDeTrabajo._usuarioDAL.Remove(usuario);
            _unidadDeTrabajo.Complete();
            return res;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario;
            usuario = _unidadDeTrabajo._usuarioDAL.Get(id);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            IEnumerable<Usuario> usuarios = await _unidadDeTrabajo._usuarioDAL.GetAll();
            return usuarios;
        }

        public bool Update(Usuario usuario)
        {
            bool res = _unidadDeTrabajo._usuarioDAL.Update(usuario);
            _unidadDeTrabajo.Complete();
            return res;
        }
    }

}

