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
    public class HorarioController : ControllerBase
    {
        private IHorarioService _horarioService;

        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Horario> horarios = await _horarioService.GetHorariosAsync();
            return Ok(horarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Horario horario = _horarioService.GetById(id);
            if (horario == null)
            {
                return NotFound();
            }
            return Ok(horario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Horario horario)
        {
            bool result = _horarioService.Add(horario);
            if (result)
            {
                return Ok(horario);
            }
            return BadRequest("Error al agregar el horario.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Horario horario)
        {
            bool result = _horarioService.Update(horario);
            if (result)
            {
                return Ok(horario);
            }
            return BadRequest("Error al actualizar el horario.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Horario horario = _horarioService.GetById(id);
            if (horario == null)
            {
                return NotFound();
            }

            bool result = _horarioService.Delete(horario);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el horario.");
        }
    }
}

