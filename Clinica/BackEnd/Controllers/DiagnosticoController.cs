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
    public class DiagnosticoController : ControllerBase
    {
        private IDiagnosticoService _diagnosticoService;

        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            _diagnosticoService = diagnosticoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Diagnostico> diagnosticos = await _diagnosticoService.GetDiagnosticosAsync();
            return Ok(diagnosticos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Diagnostico diagnostico = _diagnosticoService.GetById(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            return Ok(diagnostico);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Diagnostico diagnostico)
        {
            bool result = _diagnosticoService.Add(diagnostico);
            if (result)
            {
                return Ok(diagnostico);
            }
            return BadRequest("Error al agregar el diagnóstico.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Diagnostico diagnostico)
        {
            bool result = _diagnosticoService.Update(diagnostico);
            if (result)
            {
                return Ok(diagnostico);
            }
            return BadRequest("Error al actualizar el diagnóstico.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Diagnostico diagnostico = _diagnosticoService.GetById(id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            bool result = _diagnosticoService.Delete(diagnostico);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el diagnóstico.");
        }
    }
}

