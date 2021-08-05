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
        private readonly ListarUsuariosHandler _listarUsuariosHandler;
        private readonly CadastrarUsuarioHandler _cadastrarUsuarioHandler;

        public UsuarioController(ILogger<UsuarioController> logger,
                                    ListarUsuariosHandler listarUsuariosHandler,
                                    CadastrarUsuarioHandler cadastrarUsuarioHandler)
        {
            _logger = logger;
            _listarUsuariosHandler = listarUsuariosHandler;
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
        public IActionResult ListarUsuarios([FromQuery] UsuarioDto usuarioDto)
        {
            try
            {
                var usuarios = _listarUsuariosHandler.Listar(usuarioDto);
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
