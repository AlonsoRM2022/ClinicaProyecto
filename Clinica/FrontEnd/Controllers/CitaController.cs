using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CitaController : Controller
    {

        ICitaHelper citaHelper;
        IDoctorHelper doctorHelper;
        IEspecialidadHelper especialidadHelper;
        IClinicaHelper clinicaHelper;
        IHorarioHelper horarioHelper;

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
            List<CitaViewModel> citas = citaHelper.GetAll();
            return View(citas);
        }

        // GET: CitaController/Details/5
        public ActionResult Details(int id)
        {
            CitaViewModel cita = citaHelper.GetById(id);
            return View(cita);
        }

        // GET: EspecialidadController/Create
        public ActionResult Create()
        {
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
