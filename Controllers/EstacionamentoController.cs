using System;
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
    public class EstacionamentoController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string ESTACIONAMENTO_NULL_OBJECT = "Objeto estacionamento está nulo";
        private const string ESTACIONAMENTO_INVALID_OBJECT = "Objeto estacionamento está inválido";
        public EstacionamentoController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateEstacionamento([FromBody] Estacionamento estacionamento)
        {
            try
            {
                if(estacionamento.IsObjectNull())
                {
                    return BadRequest(ESTACIONAMENTO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(ESTACIONAMENTO_INVALID_OBJECT);
                }

                _repoWrapper.Estacionamento.CreateEstacionamento(estacionamento);
                return CreatedAtRoute("EstacionamentoById", new { id = estacionamento.Id}, estacionamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EstacionamentoById")]
        public IActionResult GetEstacionamentoById(Guid id)
        {
            try
            {
                var estacionamento = _repoWrapper.Estacionamento.GetEstacionamentoById(id);

                if(estacionamento.IsObjectNull())
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
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstacionamento(Guid id, [FromBody] Estacionamento estacionamento)
        {
            try
            {
                if(estacionamento.IsObjectNull())
                {
                    return BadRequest(ESTACIONAMENTO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(ESTACIONAMENTO_INVALID_OBJECT);
                }

                var dbEstacionamento = _repoWrapper.Estacionamento.GetEstacionamentoById(id);
                if(dbEstacionamento.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Estacionamento.UpdateEstacionamento(dbEstacionamento, estacionamento);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstacionamento(Guid id)
        {
            try
            {
                var estacionamento = _repoWrapper.Estacionamento.GetEstacionamentoById(id);
                if(estacionamento.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Estacionamento.DeleteEstacionamento(estacionamento);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
    }
}