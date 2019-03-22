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
    public class VeiculoController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public VeiculoController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        [HttpPost]
        public IActionResult CreateVeiculo([FromBody] Veiculo veiculo)
        {
            try
            {
                if(veiculo == null)
                {
                    return BadRequest("Objeto veiculo está nulo");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Objeto veiculo está inválido");
                }

                _repoWrapper.Veiculo.Create(veiculo);
                return CreatedAtRoute("VeiculoByPlaca", new { id = veiculo.Placa}, veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }

        [HttpGet("{placa}", Name = "VeiculoByPlaca")]
        public IActionResult GetVeiculoByPlaca(string placa)
        {
            try
            {
                var veiculo = _repoWrapper.Veiculo.GetVeiculoByPlaca(placa);

                if(veiculo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error." + ex.Message);
            }
        }
    }
}