using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PrecioController : Controller
    {

        IPrecioHelper precioHelper;

        public PrecioController(IPrecioHelper _precioHelper)
        {
            precioHelper = _precioHelper;
        }

        // GET: PrecioController
        public ActionResult Index()
        {
            //PrecioHelper precioHelper = new PrecioHelper();
            List<PrecioViewModel> precios = precioHelper.GetAll();
            return View(precios);
        }

        // GET: PrecioController/Details/5
        public ActionResult Details(int id)
        {
            PrecioViewModel precio = precioHelper.GetById(id);
            return View(precio);
        }

        // GET: PrecioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrecioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrecioViewModel precio)
        {
            try
            {
                precioHelper.AddPrecio(precio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrecioController/Edit/5
        public ActionResult Edit(int id)
        {
            PrecioViewModel precio = precioHelper.GetById(id);
            return View(precio);
        }

        // POST: PrecioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrecioViewModel precio)
        {
            try
            {
                PrecioViewModel precioViewModel = precioHelper.EditPrecio(precio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrecioController/Delete/5
        public ActionResult Delete(int id)
        {
            PrecioViewModel precio = precioHelper.GetById(id);
            return View(precio);
        }

        // POST: PrecioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PrecioViewModel precio)
        {
            try
            {
                precioHelper.DeletePrecio(precio.IdPrecio);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

