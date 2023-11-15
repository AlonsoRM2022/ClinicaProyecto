using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoClinica.Tools;
using System.Diagnostics;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IUsuarioHelper usuarioHelper;

        public HomeController(ILogger<HomeController> logger, IUsuarioHelper _usuarioHelper)
        {
            _logger = logger;
            usuarioHelper = _usuarioHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(string Correo, string Clave)
        {
            UsuarioViewModel usuarioEncontrado = usuarioHelper.GetUsuario(Correo, Clave);

            if (usuarioEncontrado.IdUsuario != 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mensaje"] = "El usuario no existe o las credenciales son inválidas";
            return View();

            //List<Claim> claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre)
            //};

            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //AuthenticationProperties properties = new AuthenticationProperties()
            //{
            //    AllowRefresh = true
            //};

            //await HttpContext.SignInAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity),
            //    properties);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}