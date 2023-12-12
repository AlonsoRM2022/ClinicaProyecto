using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class DiagnosticoController : Controller
    {

        IDiagnosticoHelper diagnosticoHelper;
        IReservaHelper reservaHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            diagnosticoHelper.Token = Token;
            reservaHelper.Token = Token;
        }

        public DiagnosticoController(IDiagnosticoHelper DiagnosticoHelper, IReservaHelper ReservaHelper)
        {
            diagnosticoHelper = DiagnosticoHelper;
            reservaHelper = ReservaHelper;
        }

        // GET: DiagnosticoController
        public ActionResult Info()
        {
            SetToken();
            List<DiagnosticoInfoViewModel> diagnosticos = diagnosticoHelper.GetDiagnosticoInfoAll();
            return View(diagnosticos);
        }

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
            SetToken();
            DiagnosticoViewModel diagnostico = new DiagnosticoViewModel();
            diagnostico.Reservas = reservaHelper.GetReservaInfoAll();
            return View(diagnostico);
        }

        // POST: EspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiagnosticoViewModel diagnostico)
        {
            try
            {
                SetToken();
                diagnosticoHelper.AddDiagnostico(diagnostico);
                return RedirectToAction(nameof(Info));
            }
            catch
            {
                return View();
            }
        }
    }
}
