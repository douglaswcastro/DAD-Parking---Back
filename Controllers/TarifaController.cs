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
    public class TarifaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public TarifaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateTarifa([FromBody] Tarifa tarifa)
        {
            try
            {
                if(tarifa == null)
                {
                    return BadRequest("Objeto tarifa está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto tarifa está inválido");
                }

                _repoWrapper.Tarifa.CreateTarifa(tarifa);
                return CreatedAtRoute("tarifa", new { id = tarifa.Id}, tarifa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "TarifaById")]
        public IActionResult GetTarifaById(Guid id)
        {
            try
            {
                var tarifa = _repoWrapper.Tarifa.GetTarifaById(id);

                if(tarifa == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tarifa);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}