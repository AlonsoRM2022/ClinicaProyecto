using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class HorarioController : Controller
    {

        IHorarioHelper horarioHelper;

        public HorarioController(IHorarioHelper _horarioHelper)
        {
            horarioHelper = _horarioHelper;
        }

        // GET: HorarioController
        public ActionResult Index()
        {
            //PrecioHelper precioHelper = new PrecioHelper();
            List<HorarioViewModel> horarios = horarioHelper.GetAll();
            return View(horarios);
        }

        // GET: HorarioController/Details/5
        public ActionResult Details(int id)
        {
            HorarioViewModel horario = horarioHelper.GetById(id);
            return View(horario);
        }

        // GET: HorarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HorarioViewModel horario)
        {
            try
            {
                horarioHelper.AddHorario(horario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HorarioController/Edit/5
        public ActionResult Edit(int id)
        {
            HorarioViewModel horario = horarioHelper.GetById(id);
            return View(horario);
        }

        // POST: HorarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HorarioViewModel horario)
        {
            try
            {
                HorarioViewModel horarioViewModel = horarioHelper.EditHorario(horario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HorarioController/Delete/5
        public ActionResult Delete(int id)
        {
            HorarioViewModel horario = horarioHelper.GetById(id);
            return View(horario);
        }

        // POST: HorarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HorarioViewModel horario)
        {
            try
            {
                horarioHelper.DeleteHorario(horario.IdHorario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}