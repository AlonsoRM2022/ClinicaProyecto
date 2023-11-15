using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {
        private IPrecioService _precioService;

        public PrecioController(IPrecioService precioService)
        {
            _precioService = precioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Precio> precios = await _precioService.GetPreciosAsync();
            return Ok(precios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Precio precio = _precioService.GetById(id);
            if (precio is null)
            {
                return NotFound();
            }
            return Ok(precio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Precio precio)
        {
            bool result = _precioService.Add(precio);
            if (result)
            {
                return Ok(precio);
            }
            return BadRequest("Error al agregar el precio.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Precio precio)
        {
            bool result = _precioService.Update(precio);
            if (result)
            {
                return Ok(precio);
            }
            return BadRequest("Error al actualizar el precio.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Precio precio = _precioService.GetById(id);
            if (precio is null)
            {
                return NotFound();
            }

            bool result = _precioService.Delete(precio);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el precio.");
        }
    }
}

