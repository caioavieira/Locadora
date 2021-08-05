using Locadora.Application.Dtos;
using Locadora.Application.Exceptions;
using Locadora.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Locadora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly ILogger<AluguelController> _logger;
        private readonly SolicitarAluguelHandler _solicitarAluguelHandler;

        public AluguelController(ILogger<AluguelController> logger,
                                    SolicitarAluguelHandler solicitarAluguelHandler)
        {
            _logger = logger;
            _solicitarAluguelHandler = solicitarAluguelHandler;
        }

        [HttpPost]
        public IActionResult SolicitarAluguel(AluguelDto aluguelDto)
        {
            try
            {
                var id = _solicitarAluguelHandler.Solicitar(aluguelDto);
                return CreatedAtAction(nameof(SolicitarAluguel), id);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message + " inválido(a)");
            }
            catch (AluguelNaoPermitidoException ex)
            {
                _logger.LogError(ex.Message, ex);
                return UnprocessableEntity(ex.Message);
            }
            catch (UsuarioComDebitoPendenteException ex)
            {
                _logger.LogError(ex.Message, ex);
                return UnprocessableEntity(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, "Erro ao executar ação");
            }
        }
    }
}
