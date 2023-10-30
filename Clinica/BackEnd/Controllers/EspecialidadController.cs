using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {

        EspecialidadModel Convertir(Especialidade especialidad)
        {
            return new EspecialidadModel
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Nombre = especialidad.Nombre,
                IdPrecio = especialidad.IdPrecio,
                StatusEspecialidad = especialidad.StatusEspecialidad,

            };
        }


        Especialidade Convertir(EspecialidadModel especialidad)
        {
            return new Especialidade
            {
                IdEspecialidad = especialidad.IdEspecialidad,
                Nombre = especialidad.Nombre,
                IdPrecio = especialidad.IdPrecio,
                StatusEspecialidad = especialidad.StatusEspecialidad,

            };
        }


        IEspecialidadService _especialidadService;

        public EspecialidadController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }


        // GET: api/<EspecialidadController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Especialidade> especialidades = await _especialidadService.GetEspecialidades();
            List<EspecialidadModel> especialidadModels = new List<EspecialidadModel>();
            foreach (var item in especialidades)
            {
                especialidadModels.Add(this.Convertir(item));
            }
            return Ok(especialidadModels);
        }

        // GET api/<EspecialidadController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Especialidade especialidad = await _especialidadService.GetById(id);
            return Ok(this.Convertir(especialidad));
        }

        // POST api/<EspecialidadController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EspecialidadModel especialidadModel)
        {
            Especialidade especialidad = this.Convertir(especialidadModel);
            _especialidadService.Add(especialidad);
            return Ok(Convertir(especialidad));
        }

        // PUT api/<EspecialidadController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EspecialidadModel especialidadModel)
        {
            Especialidade especialidad = this.Convertir(especialidadModel);
            _especialidadService.Update(especialidad);
            return Ok(Convertir(especialidad));
        }

        // DELETE api/<EspecialidadController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _especialidadService.Delete(id);
        }
    }
}
