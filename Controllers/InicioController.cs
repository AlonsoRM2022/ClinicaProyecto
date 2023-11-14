using Microsoft.AspNetCore.Mvc;

using ProyectoClinica.Models;
using ProyectoClinica.Services;
using ProyectoClinica.Services.Implementation;
using ProyectoClinica.Tools;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ProyectoClinica.Controllers
{
   
    public class InicioController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario model)
        {
            model.Contraseña = Utilities.EcriptarContrasena(model.Contraseña);

            Usuario usuarioCreado = await _usuarioService.SaveUsuario(model);

            if (usuarioCreado.IdUsuario > 0)
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string Correo, string Clave)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(Correo, Utilities.EcriptarContrasena(Clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "El usuario no existe o las credenciales son inválidas";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);

            return RedirectToAction("Index", "Home");
        }
    }
}
