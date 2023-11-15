using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DoctorController : Controller
    {

        IDoctorHelper doctorHelper;

        public DoctorController(IDoctorHelper _doctorHelper)
        {
            doctorHelper = _doctorHelper;
        }

        // GET: DoctorController
        public ActionResult Index()
        {
            //PrecioHelper precioHelper = new PrecioHelper();
            List<DoctorViewModel> doctores = doctorHelper.GetAll();
            return View(doctores);
        }

        // GET: DoctorController/Details/5
        public ActionResult Details(int id)
        {
            DoctorViewModel doctor = doctorHelper.GetById(id);
            return View(doctor);
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorViewModel doctor)
        {
            try
            {
                doctorHelper.AddDoctor(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id)
        {
            DoctorViewModel doctor = doctorHelper.GetById(id);
            return View(doctor);
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorViewModel doctor)
        {
            try
            {
                DoctorViewModel doctorViewModel = doctorHelper.EditDoctor(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Delete/5
        public ActionResult Delete(int id)
        {
            DoctorViewModel doctor = doctorHelper.GetById(id);
            return View(doctor);
        }

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DoctorViewModel doctor)
        {
            try
            {
                doctorHelper.DeleteDoctor(doctor.IdDoctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}