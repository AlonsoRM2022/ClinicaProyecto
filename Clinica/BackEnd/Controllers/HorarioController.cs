using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {

        public IHorarioService _horarioService;

        private Horario Convertir(HorarioModel horario)
        {
            return new Horario
            {
                IdHorario = horario.IdHorario,
                Dia = horario.Dia,
                Hora = horario.Hora,
                StatusHorario = horario.StatusHorario
            };

        }


        private HorarioModel Convertir(Horario horario)
        {
            return new HorarioModel
            {
                IdHorario = horario.IdHorario,
                Dia = horario.Dia,
                Hora = horario.Hora,
                StatusHorario = horario.StatusHorario
            };

        }

        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        // GET: api/<HorarioController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Horario> lista = _horarioService.GetHorariosAsync().Result;
            List<HorarioModel> horarios = new List<HorarioModel>();

            foreach (var item in lista)
            {
                horarios.Add(Convertir(item));

            }

            return Ok(horarios);
        }

        // GET api/<HorarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Horario horario = _horarioService.GetById(id);
            HorarioModel horarioModel = Convertir(horario);

            return Ok(horarioModel);
        }

        // POST api/<HorarioController>
        [HttpPost]
        public IActionResult Post([FromBody] HorarioModel horario)
        {
            Horario entity = Convertir(horario);
            _horarioService.AddHorario(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<HorarioController>/5
        [HttpPut]
        public IActionResult Put([FromBody] HorarioModel horario)
        {
            Horario entity = Convertir(horario);
            _horarioService.UpdateHorario(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<HorarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Horario horario = new Horario
            {
                IdHorario = id
            };

            _horarioService.DeteleHorario(horario);

            return Ok();
        }
    }
}
