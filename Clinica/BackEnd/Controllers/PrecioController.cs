using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {

        public IPrecioService _precioService;

        private Precio Convertir(PrecioModel precio)
        {
            return new Precio
            {
                IdPrecio = precio.IdPrecio,
                Valor = precio.Valor
            };

        }


        private PrecioModel Convertir(Precio precio)
        {
            return new PrecioModel
            {
                IdPrecio = precio.IdPrecio,
                Valor = precio.Valor
            };

        }

        public PrecioController(IPrecioService precioService)
        {
            _precioService = precioService;
        }

        // GET: api/<PrecioController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Precio> lista = _precioService.GetPreciosAsync().Result;
            List<PrecioModel> precios = new List<PrecioModel>();

            foreach (var item in lista)
            {
                precios.Add(Convertir(item));

            }

            return Ok(precios);
        }

        // GET api/<PrecioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Precio precio = _precioService.GetById(id);
            PrecioModel precioModel = Convertir(precio);

            return Ok(precioModel);
        }

        // POST api/<PrecioController>
        [HttpPost]
        public IActionResult Post([FromBody] PrecioModel precio)
        {
            Precio entity = Convertir(precio);
            _precioService.AddPrecio(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<PrecioController>/5
        [HttpPut]
        public IActionResult Put([FromBody] PrecioModel precio)
        {
            Precio entity = Convertir(precio);
            _precioService.UpdatePrecio(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<PrecioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Precio precio = new Precio
            {
                IdPrecio = id
            };

            _precioService.DetelePrecio(precio);

            return Ok();
        }
    }
}