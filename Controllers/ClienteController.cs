using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Repository;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Controllers
{       
    [Authorize]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public ClienteController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            try
            {
                if(cliente == null)
                {
                    return BadRequest("Objeto cliente está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto cliente está inválido");
                }

                _repoWrapper.Cliente.CreateCliente(cliente);
                return CreatedAtRoute("ClienteById", new { id = cliente.Id}, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ClienteById")]
        public IActionResult GetClienteById(Guid id)
        {
            try
            {
                var cliente = _repoWrapper.Cliente.GetClienteById(id);

                if(cliente == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(cliente);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}