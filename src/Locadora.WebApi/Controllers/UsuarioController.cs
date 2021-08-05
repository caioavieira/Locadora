using Locadora.Application.Dtos;
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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly CadastrarUsuarioHandler _cadastrarUsuarioHandler;

        public UsuarioController(ILogger<UsuarioController> logger,
                                    CadastrarUsuarioHandler cadastrarUsuarioHandler)
        {
            _logger = logger;
            _cadastrarUsuarioHandler = cadastrarUsuarioHandler;
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                var id = _cadastrarUsuarioHandler.Criar(usuarioDto);
                return CreatedAtAction(nameof(CriarUsuario), id);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message + " inválido(a)");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, "Erro ao executar ação");
            }
        }

        [HttpGet]
        public IActionResult ListarUsuario([FromQuery] UsuarioDto usuarioDto)
        {
            try
            {
                var usuarios = _cadastrarUsuarioHandler.Listar(usuarioDto);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, "Erro ao executar ação");
            }
        }
    }
}
