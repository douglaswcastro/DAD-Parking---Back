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
    public class EstacionamentoController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public EstacionamentoController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateEstacionamento([FromBody] Estacionamento estacionamento)
        {
            try
            {
                if(estacionamento == null)
                {
                    return BadRequest("Objeto estacionamento está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto estacionamento está inválido");
                }

                _repoWrapper.Estacionamento.Create(estacionamento);
                return CreatedAtRoute("EstacionamentoById", new { id = estacionamento.Id}, estacionamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EstacionamentoById")]
        public IActionResult GetEstacionamentoById(Guid id)
        {
            try
            {
                var estacionamento = _repoWrapper.Estacionamento.GetEstacionamentoById(id);

                if(estacionamento == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(estacionamento);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}