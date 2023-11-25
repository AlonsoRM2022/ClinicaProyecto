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
    public class PrecioController : Controller
    {

        IPrecioHelper precioHelper;

        public string Token { get; set; }
        private void SetToken()
        {
            Token = HttpContext.Session.GetString("token");
            precioHelper.Token = Token;
        }

        public PrecioController(IPrecioHelper _precioHelper)
        {
            precioHelper = _precioHelper;
        }

        // GET: PrecioController
        public ActionResult Index()
        {
            SetToken();
            //PrecioHelper precioHelper = new PrecioHelper();
            List<PrecioViewModel> precios = precioHelper.GetAll();
            return View(precios);
        }

        // GET: PrecioController/Details/5
        public ActionResult Details(int id)
        {
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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
            SetToken();
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
                SetToken();
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

