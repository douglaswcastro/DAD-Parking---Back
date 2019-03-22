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
    public class VagaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public VagaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateVaga([FromBody] Vaga vaga)
        {
            try
            {
                if(vaga == null)
                {
                    return BadRequest("Objeto vaga está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto vaga está inválido");
                }

                _repoWrapper.Vaga.Create(vaga);
                return CreatedAtRoute("VagaById", new { id = vaga.Id}, vaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VagaById")]
        public IActionResult GetVagaById(Guid id)
        {
            try
            {
                var vaga = _repoWrapper.Vaga.GetVagaById(id);

                if(vaga == null)
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
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}