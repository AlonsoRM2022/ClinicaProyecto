using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Usuario> usuarios = await _usuarioService.GetUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            IEnumerable<SpObtenerInfoUsuariosConRolResult> usuarios = await _usuarioService.GetUsuariosInfo();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Usuario usuario = _usuarioService.GetById(id);
            if (usuario is null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                Usuario usuario2 = await _usuarioService.GetUsuario(usuario.Correo, usuario.Clave);
                Console.WriteLine("Usuario logueado: " + usuario2);
                if (usuario2 != null)
                {
                    return Ok(usuario2);
                }
                 return BadRequest("El usuario no existe o las credenciales son inválidas");
            }
            else
            {
                bool result = _usuarioService.Add(usuario);
                if (result)
                {
                    return Ok(usuario);
                }
                return BadRequest("Error al agregar el usuario.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            bool result = _usuarioService.Update(usuario);
            if (result)
            {
                return Ok(usuario);
            }
            return BadRequest("Error al actualizar el usuario.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuario = _usuarioService.GetById(id);
            if (usuario is null)
            {
                return NotFound();
            }

            bool result = _usuarioService.Delete(usuario);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el usuario.");
        }
    }
}

