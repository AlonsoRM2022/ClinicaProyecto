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
    public class EspecialidadController : ControllerBase
    {
        private IEspecialidadService _especialidadService;

        public EspecialidadController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Especialidad> especialidades = await _especialidadService.GetEspecialidadesAsync();
            return Ok(especialidades);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            IEnumerable<SpObtenerInfoEspecialidadesResult> especialidades = await _especialidadService.GetEspecialidadesInfo();
            return Ok(especialidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Especialidad especialidad = _especialidadService.GetById(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return Ok(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Especialidad especialidad)
        {
            bool result = _especialidadService.Add(especialidad);
            if (result)
            {
                return Ok(especialidad);
            }
            return BadRequest("Error al agregar la especialidad.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Especialidad especialidad)
        {
            bool result = _especialidadService.Update(especialidad);
            if (result)
            {
                return Ok(especialidad);
            }
            return BadRequest("Error al actualizar la especialidad.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Especialidad especialidad = _especialidadService.GetById(id);
            if (especialidad == null)
            {
                return NotFound();
            }

            bool result = _especialidadService.Delete(especialidad);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar la especialidad.");
        }
    }
}

