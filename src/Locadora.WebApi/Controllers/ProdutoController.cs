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
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ListarProdutosHandler _listarProdutosHandler;

        public ProdutoController(ILogger<ProdutoController> logger,
                                    ListarProdutosHandler listarProdutosHandler)
        {
            _logger = logger;
            _listarProdutosHandler = listarProdutosHandler;
        }

        [HttpGet]
        public IActionResult ListarProdutos([FromQuery] ProdutoDto produtoDto)
        {
            try
            {
                var produtos = _listarProdutosHandler.Listar(produtoDto);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, "Erro ao executar ação");
            }
        }
    }
}
