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
    public class StatusReservaController : ControllerBase
    {
        private IStatusReservaService _statusReservaService;

        public StatusReservaController(IStatusReservaService statusReservaService)
        {
            _statusReservaService = statusReservaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<StatusReserva> statusReservas = await _statusReservaService.GetStatusReservasAsync();
            return Ok(statusReservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            StatusReserva statusReserva = _statusReservaService.GetById(id);
            if (statusReserva is null)
            {
                return NotFound();
            }
            return Ok(statusReserva);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusReserva statusReserva)
        {
            bool result = _statusReservaService.Add(statusReserva);
            if (result)
            {
                return Ok(statusReserva);
            }
            return BadRequest("Error al agregar el estado de reserva.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StatusReserva statusReserva)
        {
            bool result = _statusReservaService.Update(statusReserva);
            if (result)
            {
                return Ok(statusReserva);
            }
            return BadRequest("Error al actualizar el estado de reserva.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StatusReserva statusReserva = _statusReservaService.GetById(id);
            if (statusReserva is null)
            {
                return NotFound();
            }

            bool result = _statusReservaService.Delete(statusReserva);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el estado de reserva.");
        }
    }
}

