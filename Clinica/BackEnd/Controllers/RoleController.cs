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
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService rolService)
        {
            _roleService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Role> roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Role rol = _roleService.GetById(id);
            if (rol is null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role rol)
        {
            bool result = _roleService.Add(rol);
            if (result)
            {
                return Ok(rol);
            }
            return BadRequest("Error al agregar el rol.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Role rol)
        {
            bool result = _roleService.Update(rol);
            if (result)
            {
                return Ok(rol);
            }
            return BadRequest("Error al actualizar el rol.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Role rol = _roleService.GetById(id);
            if (rol is null)
            {
                return NotFound();
            }

            bool result = _roleService.Delete(rol);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error al eliminar el rol.");
        }
    }
}

