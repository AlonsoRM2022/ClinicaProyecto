using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {

        CitaModel Convertir(Cita cita)
        {
            return new CitaModel
            {
                IdCita = cita.IdCita,
                IdDoctor = cita.IdDoctor,
                IdEspecialidad = cita.IdEspecialidad,
                IdClinica = cita.IdClinica,
                IdHorario = cita.IdHorario,
                StatusCita = cita.StatusCita,

            };
        }


        Cita Convertir(CitaModel cita)
        {
            return new Cita
            {
                IdCita = cita.IdCita,
                IdDoctor = cita.IdDoctor,
                IdEspecialidad = cita.IdEspecialidad,
                IdClinica = cita.IdClinica,
                IdHorario = cita.IdHorario,
                StatusCita = cita.StatusCita,

            };
        }


        ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }


        // GET: api/<CitaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Cita> citas = await _citaService.GetCitas();
            List<CitaModel> citaModels = new List<CitaModel>();
            foreach (var item in citas)
            {
                citaModels.Add(this.Convertir(item));
            }
            return Ok(citaModels);
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Cita cita = await _citaService.GetById(id);
            return Ok(this.Convertir(cita));
        }

        // POST api/<CitaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CitaModel citaModel)
        {
            Cita cita = this.Convertir(citaModel);
            _citaService.Add(cita);
            return Ok(Convertir(cita));
        }

        // PUT api/<CitaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CitaModel citaModel)
        {
            Cita cita = this.Convertir(citaModel);
            _citaService.Update(cita);
            return Ok(Convertir(cita));
        }

        // DELETE api/<CitaController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _citaService.Delete(id);
        }
    }
}
