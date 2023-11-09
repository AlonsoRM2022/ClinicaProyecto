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
    public class CitaController : ControllerBase
    {
        private ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Cita> citas = await _citaService.GetCitasAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Cita cita = _citaService.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cita cita)
        {
            bool result = _citaService.Add(cita);
            if (result)
            {
                return Ok(cita);
            }
            return BadRequest("Error al agregar la cita.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cita cita)
        {
            bool result = _citaService.Update(cita);
            if (result)
            {
                return Ok(cita);
            }
            return BadRequest("Error al actualizar la cita.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Cita cita = _citaService.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }

            bool result = _citaService.Delete(cita);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar la cita.");
        }
    }
}

