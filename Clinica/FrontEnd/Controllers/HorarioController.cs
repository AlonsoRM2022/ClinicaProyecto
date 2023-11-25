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
    public class HorarioController : Controller
    {

        IHorarioHelper horarioHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            horarioHelper.Token = Token;
        }

        public HorarioController(IHorarioHelper _horarioHelper)
        {
            horarioHelper = _horarioHelper;
        }

        // GET: HorarioController
        public ActionResult Index()
        {
            SetToken();
            //PrecioHelper precioHelper = new PrecioHelper();
            List<HorarioViewModel> horarios = horarioHelper.GetAll();
            return View(horarios);
        }

        // GET: HorarioController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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