using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        public IDoctorService _doctorService;

        private Doctore Convertir(DoctorModel doctor)
        {
            return new Doctore
            {
                IdDoctor = doctor.IdDoctor,
                Nombre = doctor.Nombre,
                Apellido = doctor.Apellido,
                StatusDoctor = doctor.StatusDoctor
            };

        }


        private DoctorModel Convertir(Doctore doctor)
        {
            return new DoctorModel
            {
                IdDoctor = doctor.IdDoctor,
                Nombre = doctor.Nombre,
                Apellido = doctor.Apellido,
                StatusDoctor = doctor.StatusDoctor
            };

        }

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Doctore> lista = _doctorService.GetDoctoresAsync().Result;
            List<DoctorModel> doctores = new List<DoctorModel>();

            foreach (var item in lista)
            {
                doctores.Add(Convertir(item));

            }

            return Ok(doctores);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Doctore doctor = _doctorService.GetById(id);
            DoctorModel doctorModel = Convertir(doctor);

            return Ok(doctorModel);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromBody] DoctorModel doctor)
        {
            Doctore entity = Convertir(doctor);
            _doctorService.AddDoctor(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<DoctorController>/5
        [HttpPut]
        public IActionResult Put([FromBody] DoctorModel doctor)
        {
            Doctore entity = Convertir(doctor);
            _doctorService.UpdateDoctor(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Doctore doctor = new Doctore
            {
                IdDoctor = id
            };

            _doctorService.DeteleDoctor(doctor);

            return Ok();
        }
    }
}