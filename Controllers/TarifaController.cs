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
    public class TarifaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string TARIFA_NULL_OBJECT = "Objeto tarifa está nulo";
        private const string TARIFA_INVALID_OBJECT = "Objeto tarifa está inválido";
        public TarifaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateTarifa([FromBody] Tarifa tarifa)
        {
            try
            {
                if(tarifa.IsObjectNull())
                {
                    return BadRequest(TARIFA_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(TARIFA_INVALID_OBJECT);
                }

                _repoWrapper.Tarifa.CreateTarifa(tarifa);
                return CreatedAtRoute("tarifa", new { id = tarifa.Id}, tarifa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "TarifaById")]
        public IActionResult GetTarifaById(Guid id)
        {
            try
            {
                var tarifa = _repoWrapper.Tarifa.GetTarifaById(id);

                if(tarifa.IsObjectNull())
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
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTarifa(Guid id, [FromBody] Tarifa tarifa)
        {
            try
            {
                if(tarifa.IsObjectNull())
                {
                    return BadRequest(TARIFA_NULL_OBJECT);
                }

                if(!ModelState.IsValid)                
                {
                    return BadRequest(TARIFA_INVALID_OBJECT);
                }

                var dbTarifa = _repoWrapper.Tarifa.GetTarifaById(id);
                if(dbTarifa.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Tarifa.UpdateTarifa(dbTarifa, tarifa);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTarifa(Guid id)
        {
            try
            {
                var tarifa = _repoWrapper.Tarifa.GetTarifaById(id);
                if(tarifa.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Tarifa.DeleteTarifa(tarifa);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
    }
}