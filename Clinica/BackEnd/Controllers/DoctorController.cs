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
    public class DoctorController : Controller
    {
        IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Doctor> doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Doctor doctor = _doctorService.GetById(id);
            return Ok(doctor);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            _doctorService.Add(doctor);
            return Ok(doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Doctor doctor)
        {
            _doctorService.Update(doctor);
            return Ok(doctor);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Doctor doctor = new Doctor
            {
                IdDoctor = id
            };
            _doctorService.Delete(doctor);
            return Ok();
            ;
        }
    }
}

