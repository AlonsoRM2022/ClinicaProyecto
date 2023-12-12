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
    public class FacturaController : Controller
    {
        IFacturaHelper facturaHelper;

        public string Token { get; set; }

        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            facturaHelper.Token = Token;
        }

        public FacturaController(IFacturaHelper FacturaHelper)
        {
            facturaHelper = FacturaHelper;
        }

        // GET: FacturaController
        public ActionResult Info()
        {
            SetToken();
            List<FacturaInfoViewModel> facturas = facturaHelper.GetFacturaInfoAll();
            return View(facturas);
        }
    }
}
