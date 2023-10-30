using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {

        public IClinicaService _clinicaService;

        private Clinica Convertir(ClinicaModel clinica)
        {
            return new Clinica
            {
                IdClinica = clinica.IdClinica,
                Nombre = clinica.Nombre,
                Direccion = clinica.Direccion,
                Telefono = clinica.Telefono,
                Correo = clinica.Correo
            };

        }


        private ClinicaModel Convertir(Clinica clinica)
        {
            return new ClinicaModel
            {
                IdClinica = clinica.IdClinica,
                Nombre = clinica.Nombre,
                Direccion = clinica.Direccion,
                Telefono = clinica.Telefono,
                Correo = clinica.Correo
            };

        }

        public ClinicaController(IClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        // GET: api/<ClinicaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Clinica> lista = _clinicaService.GetClinicasAsync().Result;
            List<ClinicaModel> clinicas = new List<ClinicaModel>();

            foreach (var item in lista)
            {
                clinicas.Add(Convertir(item));

            }

            return Ok(clinicas);
        }

        // GET api/<ClinicaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Clinica clinica = _clinicaService.GetById(id);
            ClinicaModel clinicaModel = Convertir(clinica);

            return Ok(clinicaModel);
        }

        // POST api/<ClinicaController>
        [HttpPost]
        public IActionResult Post([FromBody] ClinicaModel clinica)
        {
            Clinica entity = Convertir(clinica);
            _clinicaService.AddClinica(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<ClinicaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ClinicaModel clinica)
        {
            Clinica entity = Convertir(clinica);
            _clinicaService.UpdateClinica(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<ClinicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Clinica clinica = new Clinica
            {
                IdClinica = id
            };

            _clinicaService.DeteleClinica(clinica);

            return Ok();
        }
    }
}