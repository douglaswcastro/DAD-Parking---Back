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
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string VEICULO_NULL_OBJECT = "Objeto veículo está nulo";
        private const string VEICULO_INVALID_OBJECT = "Objeto veículo está inválido";
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
                    return BadRequest(VEICULO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(VEICULO_INVALID_OBJECT);
                }

                _repoWrapper.Veiculo.CreateVeiculo(veiculo);
                return CreatedAtRoute("VeiculoByPlaca", new { id = veiculo.Placa}, veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
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
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{placa}")]
        public IActionResult UpdateVeiculo(string placa, [FromBody] Veiculo veiculo)
        {
            try
            {
                if(veiculo == null)
                {
                    return BadRequest(VEICULO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)                
                {
                    return BadRequest(VEICULO_INVALID_OBJECT);
                }

                var dbVeiculo = _repoWrapper.Veiculo.GetVeiculoByPlaca(placa);
                if(dbVeiculo == null)
                {
                    return NotFound();
                }

                _repoWrapper.Veiculo.UpdateVeiculo(dbVeiculo, veiculo);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{placa}")]
        public IActionResult DeleteCliente(string placa)
        {
            try
            {
                var veiculo = _repoWrapper.Veiculo.GetVeiculoByPlaca(placa);
                if(veiculo == null)
                {
                    return NotFound();
                }

                _repoWrapper.Veiculo.DeleteVeiculo(veiculo);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
    }
}