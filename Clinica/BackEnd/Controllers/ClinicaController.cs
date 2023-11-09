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
    public class ClinicaController : ControllerBase
    {
        private IClinicaService _clinicaService;

        public ClinicaController(IClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Clinica> clinicas = await _clinicaService.GetClinicasAsync();
            return Ok(clinicas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Clinica clinica = _clinicaService.GetById(id);
            if (clinica == null)
            {
                return NotFound();
            }
            return Ok(clinica);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clinica clinica)
        {
            bool result = _clinicaService.Add(clinica);
            if (result)
            {
                return Ok(clinica);
            }
            return BadRequest("Error al agregar la clínica.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Clinica clinica)
        {
            bool result = _clinicaService.Update(clinica);
            if (result)
            {
                return Ok(clinica);
            }
            return BadRequest("Error al actualizar la clínica.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Clinica clinica = _clinicaService.GetById(id);
            if (clinica == null)
            {
                return NotFound();
            }

            bool result = _clinicaService.Delete(clinica);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar la clínica.");
        }
    }

}

