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

        [HttpGet]
        public IActionResult GetAllVeiculos()
        {
            try
            {
                var veiculos = _repoWrapper.Veiculo.GetAllVeiculos();

                if (veiculos.Any())
                {
                    return Ok(veiculos);
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }
        
        [HttpPost]
        public IActionResult CreateVeiculo([FromBody] Veiculo veiculo)
        {
            try
            {
                if(veiculo.IsObjectNull())
                {
                    return BadRequest(VEICULO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest(VEICULO_INVALID_OBJECT);
                }

                _repoWrapper.Veiculo.CreateVeiculo(veiculo);
                return CreatedAtRoute("VeiculoById", new { id = veiculo.Placa}, veiculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VeiculoById")]
        public IActionResult GetVeiculoById(Guid id)
        {
            try
            {
                var veiculo = _repoWrapper.Veiculo.GetVeiculoById(id);

                if(veiculo.IsObjectNull())
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

        [HttpPut("{id}")]
        public IActionResult UpdateVeiculo(Guid id, [FromBody] Veiculo veiculo)
        {
            try
            {
                if(veiculo.IsObjectNull())
                {
                    return BadRequest(VEICULO_NULL_OBJECT);
                }

                if(!ModelState.IsValid)                
                {
                    return BadRequest(VEICULO_INVALID_OBJECT);
                }

                var dbVeiculo = _repoWrapper.Veiculo.GetVeiculoById(id);
                if(dbVeiculo.IsEmptyObject())
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {
            try
            {
                var veiculo = _repoWrapper.Veiculo.GetVeiculoById(id);
                if(veiculo.IsObjectNull())
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