using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        IReservaHelper reservaHelper;

        public string Token { get; set; }

        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            reservaHelper.Token = Token;
        }

        public ReservaController(IReservaHelper ReservaHelper)
        {
            reservaHelper = ReservaHelper;
        }

        // GET: ReservaController
        public ActionResult Info()
        {
            SetToken();
            List<ReservaInfoViewModel> reservas = reservaHelper.GetReservaInfoAll();
            return View(reservas);
        }
    }
}