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
    public class VagaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string VAGA_NULL_OBJECT = "Objeto vaga está nulo";
        private const string VAGA_INVALID_OBJECT = "Objeto vaga está inválido";
        public VagaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult GetAllVagas()
        {
            try
            {
                var vagas = _repoWrapper.Vaga.GetAllVagas();

                if(vagas.Any())
                {
                    return Ok(vagas);
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
        
        [HttpPost]
        public IActionResult CreateVaga([FromBody] Vaga vaga)
        {
            try
            {
                if(vaga.IsObjectNull())
                {
                    return BadRequest(VAGA_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(VAGA_INVALID_OBJECT);
                }

                _repoWrapper.Vaga.CreateVaga(vaga);
                return CreatedAtRoute("VagaById", new { id = vaga.Id}, vaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VagaById")]
        public IActionResult GetVagaById(Guid id)
        {
            try
            {
                var vaga = _repoWrapper.Vaga.GetVagaById(id);

                if(vaga.IsEmptyObject())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(vaga);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVaga(Guid id, [FromBody] Vaga vaga)
        {
            try
            {
                if(vaga.IsObjectNull())
                {
                    return BadRequest(VAGA_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(VAGA_INVALID_OBJECT);
                }

                var dbVaga = _repoWrapper.Vaga.GetVagaById(id);
                if(dbVaga.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Vaga.UpdateVaga(dbVaga, vaga);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVaga(Guid id)
        {
            try
            {
                var vaga = _repoWrapper.Vaga.GetVagaById(id);
                if(vaga.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Vaga.DeleteVaga(vaga);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
    }
}