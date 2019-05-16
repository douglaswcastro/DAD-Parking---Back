using System;
using System.Linq;
using System.Collections.Generic;
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
    public class VinculoController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private const string INTERNAL_SERVER_MESSAGE = "Internal server error.";
        private const string VINCULO_NULL_OBJECT = "Objeto vínculo está nulo";
        private const string VINCULO_INVALID_OBJECT = "Objeto vínculo está inválido";
        public VinculoController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult GetAllVinculos()
        {
            try
            {
                var vinculos = _repoWrapper.Vinculo.GetAllVinculos();

                if (vinculos.Any())
                {
                    var vinculosDTO = from vinculo in vinculos
                                      select new
                                      {
                                          vinculo.Id,
                                          vinculo.Vaga.NumeroVaga,
                                          NomeCliente = vinculo.Cliente.Nome,
                                          vinculo.Cliente.Veiculo.Modelo,
                                          vinculo.DataHoraInicio,
                                          vinculo.DataHoraFim,
                                          vinculo.ValorTotal
                                      };

                    return Ok(vinculosDTO);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateVinculo([FromBody] Vinculo vinculo)
        {
            try
            {
                if (vinculo.IsObjectNull())
                {
                    return BadRequest(VINCULO_NULL_OBJECT);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(VINCULO_INVALID_OBJECT);
                }

                _repoWrapper.Vinculo.CreateVinculo(vinculo);
                return CreatedAtRoute("VinculoById", new { id = vinculo.Id }, vinculo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("valorTotal/{id}")]
        public IActionResult GetValorTotal(Guid id)
        {
            try
            {
                var vinculo = _repoWrapper.Vinculo.GetVinculoById(id);

                if (vinculo.IsObjectNull())
                {
                    return NotFound();
                }
                else
                {
                    if (vinculo.Tarifa.TipoTarifa.ToLower() == "hora")
                    {
                        var tempoEstacionado = (vinculo.DataHoraFim - vinculo.DataHoraInicio).Value.Hours;
                        var valorTotal = tempoEstacionado * vinculo.Tarifa.Valor;
                        return Ok(new
                        {
                            id = vinculo.Id,
                            valorTotal = valorTotal
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            id = vinculo.Id,
                            valorTotal = vinculo.Tarifa.Valor
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VinculoById")]
        public IActionResult GetVinculoById(Guid id)
        {
            try
            {
                var vinculo = _repoWrapper.Vinculo.GetVinculoById(id);

                if (vinculo.IsObjectNull())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(TransformVinculo(vinculo));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVinculo(Guid id, [FromBody] Vinculo vinculo)
        {
            try
            {
                if (vinculo.IsObjectNull())
                {
                    return BadRequest(VINCULO_NULL_OBJECT);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(VINCULO_INVALID_OBJECT);
                }

                var dbVinculo = _repoWrapper.Vinculo.GetVinculoById(id);
                if (dbVinculo.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Vinculo.UpdateVinculo(dbVinculo, vinculo);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVinculo(Guid id)
        {
            try
            {
                var vinculo = _repoWrapper.Vinculo.GetVinculoById(id);
                if (vinculo.IsEmptyObject())
                {
                    return NotFound();
                }

                _repoWrapper.Vinculo.DeleteVinculo(vinculo);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, INTERNAL_SERVER_MESSAGE + ex.Message);
            }
        }

        private Vinculo TransformVinculo(Vinculo vinculo)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            var jsonVinculo = Newtonsoft.Json.JsonConvert.SerializeObject(vinculo, vinculo.GetType().BaseType, settings);            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Vinculo>(jsonVinculo);
        }
    }
}