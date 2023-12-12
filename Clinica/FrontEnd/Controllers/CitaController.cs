using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class CitaController : Controller
    {

        ICitaHelper citaHelper;
        IDoctorHelper doctorHelper;
        IEspecialidadHelper especialidadHelper;
        IClinicaHelper clinicaHelper;
        IHorarioHelper horarioHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            citaHelper.Token = Token;
            doctorHelper.Token = Token;
            especialidadHelper.Token = Token;
            clinicaHelper.Token = Token;
            horarioHelper.Token = Token;
        }

        public CitaController(ICitaHelper CitaHelper,
                              IDoctorHelper DoctorHelper,
                              IEspecialidadHelper EspecialidadHelper,
                              IClinicaHelper ClinicaHelper,
                              IHorarioHelper HorarioHelper)
        {
            citaHelper = CitaHelper;
            doctorHelper = DoctorHelper;
            especialidadHelper = EspecialidadHelper;
            clinicaHelper = ClinicaHelper;
            horarioHelper = HorarioHelper;

        }


        // GET: CitaController
        public ActionResult Index()
        {
            SetToken();
            List<CitaViewModel> citas = citaHelper.GetAll();
            return View(citas);
        }

        // GET: CitaController
        public ActionResult Info()
        {
            SetToken();
            List<CitaInfoViewModel> citas = citaHelper.GetCitaInfoAll();
            return View(citas);
        }

        // GET: CitaController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
            CitaViewModel cita = citaHelper.GetById(id);
            return View(cita);
        }

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
            SetToken();
            CitaViewModel cita = new CitaViewModel();
            cita.Doctores = doctorHelper.GetAll();
            cita.Especialidades = especialidadHelper.GetAll();
            cita.Clinicas = clinicaHelper.GetAll();
            cita.Horarios = horarioHelper.GetAll();
            return View(cita);
        }

        // POST: CitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CitaViewModel cita)
        {
            try
            {
                SetToken();
                citaHelper.AddCita(cita);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitaController/Edit/5
        public ActionResult Edit(int id)
        {
            SetToken();
            CitaViewModel cita = citaHelper.GetById(id);
            cita.Doctores = doctorHelper.GetAll();
            cita.Especialidades = especialidadHelper.GetAll();
            cita.Clinicas = clinicaHelper.GetAll();
            cita.Horarios = horarioHelper.GetAll();
            return View(cita);
        }

        // POST: CitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CitaViewModel cita)
        {
            try
            {
                SetToken();
                citaHelper.EditCita(cita);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitaController/Delete/5
        public ActionResult Delete(int id)
        {
            SetToken();
            CitaViewModel cita = citaHelper.GetById(id);
            return View(cita);
        }

        // POST: CitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CitaViewModel cita)
        {
            try
            {
                SetToken();
                citaHelper.DeleteCita(cita.IdCita);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
