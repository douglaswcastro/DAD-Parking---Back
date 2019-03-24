using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Repository;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Extensions;

namespace DAD_Parking___Back.Controllers
{       
    [Authorize]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string CLIENTE_NULL_OBJECT = "Objeto cliente está nulo";
        private const string CLIENTE_INVALID_OBJECT = "Objeto cliente está inválido";
        public ClienteController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpGet]
        public IActionResult GetAllClientes()
        {
            try
            {
                var clientes = _repoWrapper.Cliente.GetAllClientes();

                if (clientes.Any())
                {
                    return Ok(clientes);
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            try
            {
                if(cliente.IsObjectNull())
                {
                    return BadRequest(CLIENTE_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(CLIENTE_INVALID_OBJECT);
                }

                _repoWrapper.Cliente.CreateCliente(cliente);
                return CreatedAtRoute("ClienteById", new { id = cliente.Id}, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
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
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(Guid id, [FromBody] Cliente cliente)
        {
            try
            {
                if(cliente.IsObjectNull())
                {
                    return BadRequest(CLIENTE_NULL_OBJECT);
                }

                if(!ModelState.IsValid)                
                {
                    return BadRequest(CLIENTE_INVALID_OBJECT);
                }

                var dbCliente = _repoWrapper.Cliente.GetClienteById(id);
                if(dbCliente.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Cliente.UpdateCliente(dbCliente, cliente);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {
            try
            {
                var cliente = _repoWrapper.Cliente.GetClienteById(id);
                if(cliente.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Cliente.DeleteCliente(cliente);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
    }
}