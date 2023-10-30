using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EspecialidadController : Controller
    {

        IEspecialidadHelper especialidadHelper;
        IPrecioHelper precioHelper;

        public EspecialidadController(IEspecialidadHelper EspecialidadHelper,
                               IPrecioHelper PrecioHelper)
        {
            especialidadHelper = EspecialidadHelper;
            precioHelper = PrecioHelper;

        }


        // GET: EspecialidadController
        public ActionResult Index()
        {
            List<EspecialidadViewModel> especialidades = especialidadHelper.GetAll();
            return View(especialidades);
        }

        // GET: EspecialidadController/Details/5
        public ActionResult Details(int id)
        {
            EspecialidadViewModel especialidad = especialidadHelper.GetById(id);
            return View(especialidad);
        }

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
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
