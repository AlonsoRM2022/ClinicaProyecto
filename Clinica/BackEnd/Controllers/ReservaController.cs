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
    public class ReservaController : ControllerBase
    {
        private IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Reserva> reservas = await _reservaService.GetReservasAsync();
            return Ok(reservas);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            IEnumerable<SpObtenerInfoReservasResult> reservas = await _reservaService.GetReservasInfo();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Reserva reserva = _reservaService.GetById(id);
            if (reserva is null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            bool result = _reservaService.Add(reserva);
            if (result)
            {
                return Ok(reserva);
            }
            return BadRequest("Error al agregar la reserva.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Reserva reserva)
        {
            bool result = _reservaService.Update(reserva);
            if (result)
            {
                return Ok(reserva);
            }
            return BadRequest("Error al actualizar la reserva.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Reserva reserva = _reservaService.GetById(id);
            if (reserva is null)
            {
                return NotFound();
            }

            bool result = _reservaService.Delete(reserva);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar la reserva.");
        }
    }
}

