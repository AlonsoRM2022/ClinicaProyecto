using System;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
	public interface IUsuarioHelper
	{
        string Token { get; set; }
        UsuarioViewModel GetUsuario(string Correo, string Clave);
    }
}

