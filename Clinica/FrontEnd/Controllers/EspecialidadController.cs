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
    public class EspecialidadController : Controller
    {

        IEspecialidadHelper especialidadHelper;
        IPrecioHelper precioHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            precioHelper.Token = Token;
            especialidadHelper.Token = Token;
        }

        public EspecialidadController(IEspecialidadHelper EspecialidadHelper,
                               IPrecioHelper PrecioHelper)
        {
            especialidadHelper = EspecialidadHelper;
            precioHelper = PrecioHelper;

        }


        // GET: EspecialidadController
        public ActionResult Index()
        {
            SetToken();
            List<EspecialidadViewModel> especialidades = especialidadHelper.GetAll();
            return View(especialidades);
        }

        // GET: EspecialidadController
        public ActionResult Info()
        {
            SetToken();
            List<EspecialidadInfoViewModel> especialidades = especialidadHelper.GetEspecialidadInfoAll();
            return View(especialidades);
        }

        // GET: EspecialidadController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
            EspecialidadViewModel especialidad = especialidadHelper.GetById(id);
            return View(especialidad);
        }

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
            SetToken();
            EspecialidadViewModel especialidad = new EspecialidadViewModel();
            especialidad.Precios = precioHelper.GetAll();
            return View(especialidad);
        }

        // POST: EspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecialidadViewModel especialidad)
        {
            try
            {
                SetToken();
                especialidadHelper.AddEspecialidad(especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadController/Edit/5
        public ActionResult Edit(int id)
        {
            SetToken();
            EspecialidadViewModel especialidad = especialidadHelper.GetById(id);
            especialidad.Precios = precioHelper.GetAll();
            return View(especialidad);
        }

        // POST: EspecialidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EspecialidadViewModel especialidad)
        {
            try
            {
                SetToken();
                especialidadHelper.EditEspecialidad(especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadController/Delete/5
        public ActionResult Delete(int id)
        {
            SetToken();
            EspecialidadViewModel especialidad = especialidadHelper.GetById(id);
            return View(especialidad);
        }

        // POST: EspecialidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EspecialidadViewModel especialidad)
        {
            try
            {
                SetToken();
                especialidadHelper.DeleteEspecialidad(especialidad.IdEspecialidad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
