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
    public class VinculoController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public VinculoController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateVinculo([FromBody] Vinculo vinculo)
        {
            try
            {
                if(vinculo == null)
                {
                    return BadRequest("Objeto vinculo está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto vinculo está inválido");
                }

                _repoWrapper.Vinculo.CreateVinculo(vinculo);
                return CreatedAtRoute("VinculoById", new { id = vinculo.Id}, vinculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("valorTotal/{id}")]
        public IActionResult GetValorTotal(Guid id)
        {
            try
            {
                var vinculo = _repoWrapper.Vinculo.GetVinculoById(id);

                if(vinculo == null)
                {
                    return NotFound();
                }
                else
                {
                    if(vinculo.Tarifa.TipoTarifa.ToLower() == "hora")
                    {
                        var tempoEstacionado = (vinculo.DataHoraFim - vinculo.DataHoraInicio).Hours;
                        var valorTotal = tempoEstacionado * vinculo.Tarifa.Valor;
                        return Ok(new {
                            id = vinculo.Id,
                            valorTotal = valorTotal
                        });
                    }
                    else
                    {
                        return Ok(new {
                            id = vinculo.Id,
                            valorTotal = vinculo.Tarifa.Valor
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);                
            }
        }

        [HttpGet("{id}", Name = "VinculoById")]
        public IActionResult GetVinculoById(Guid id)
        {
            try
            {
                var vinculo = _repoWrapper.Vinculo.GetVinculoById(id);

                if(vinculo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(vinculo);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}