using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ClinicaController : Controller
    {

        IClinicaHelper clinicaHelper;

        public ClinicaController(IClinicaHelper _clinicaHelper)
        {
            clinicaHelper = _clinicaHelper;
        }

        // GET: ClinicaController
        public ActionResult Index()
        {
            //PrecioHelper precioHelper = new PrecioHelper();
            List<ClinicaViewModel> clinicas = clinicaHelper.GetAll();
            return View(clinicas);
        }

        // GET: ClinicaController/Details/5
        public ActionResult Details(int id)
        {
            ClinicaViewModel clinica = clinicaHelper.GetById(id);
            return View(clinica);
        }

        // GET: ClinicaController/Create
        public ActionResult Create()
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