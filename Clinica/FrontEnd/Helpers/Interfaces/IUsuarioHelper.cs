using System;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
	public interface IUsuarioHelper
	{
        UsuarioViewModel GetUsuario(string Correo, string Clave);
    }
}

