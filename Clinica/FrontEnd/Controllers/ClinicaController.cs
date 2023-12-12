using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class ClinicaController : Controller
    {

        IClinicaHelper clinicaHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            clinicaHelper.Token = Token;
        }

        public ClinicaController(IClinicaHelper _clinicaHelper)
        {
            clinicaHelper = _clinicaHelper;
        }

        // GET: ClinicaController
        public ActionResult Index()
        {
            SetToken();
            //PrecioHelper precioHelper = new PrecioHelper();
            List<ClinicaViewModel> clinicas = clinicaHelper.GetAll();
            return View(clinicas);
        }

        // GET: ClinicaController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
            ClinicaViewModel clinica = clinicaHelper.GetById(id);
            return View(clinica);
        }

        // GET: ClinicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: ClinicaController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: ClinicaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaViewModel clinica)
        {
            try
            {
                SetToken();
                clinicaHelper.AddClinica(clinica);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClinicaController/Edit/5
        public ActionResult Edit(int id)
        {
            SetToken();
            ClinicaViewModel clinica = clinicaHelper.GetById(id);
            return View(clinica);
        }

        // POST: ClinicaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaViewModel clinica)
        {
            try
            {
                SetToken();
                ClinicaViewModel clinicaViewModel = clinicaHelper.EditClinica(clinica);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClinicaController/Delete/5
        public ActionResult Delete(int id)
        {
            SetToken();
            ClinicaViewModel clinica = clinicaHelper.GetById(id);
            return View(clinica);
        }

        // POST: ClinicaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClinicaViewModel clinica)
        {
            try
            {
                SetToken();
                clinicaHelper.DeleteClinica(clinica.IdClinica);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}