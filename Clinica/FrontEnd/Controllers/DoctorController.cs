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
    public class DoctorController : Controller
    {

        IDoctorHelper doctorHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            doctorHelper.Token = Token;
        }

        public DoctorController(IDoctorHelper _doctorHelper)
        {
            doctorHelper = _doctorHelper;
        }

        // GET: DoctorController
        public ActionResult Index()
        {
            SetToken();
            //PrecioHelper precioHelper = new PrecioHelper();
            List<DoctorViewModel> doctores = doctorHelper.GetAll();
            return View(doctores);
        }

        // GET: DoctorController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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