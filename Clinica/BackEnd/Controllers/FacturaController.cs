using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Factura> facturas = await _facturaService.GetFacturasAsync();
            return Ok(facturas);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            IEnumerable<SpObtenerInfoFacturasConUsuario> facturas = await _facturaService.GetFacturasInfo();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Factura factura = _facturaService.GetById(id);
            if (factura is null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Factura factura)
        {
            bool result = _facturaService.Add(factura);
            if (result)
            {
                return Ok(factura);
            }
            return BadRequest("Error al agregar la factura.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Factura factura)
        {
            bool result = _facturaService.Update(factura);
            if (result)
            {
                return Ok(factura);
            }
            return BadRequest("Error al actualizar la factura.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Factura factura = _facturaService.GetById(id);
            if (factura is null)
            {
                return NotFound();
            }

            bool result = _facturaService.Delete(factura);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar la factura.");
        }
    }
}

