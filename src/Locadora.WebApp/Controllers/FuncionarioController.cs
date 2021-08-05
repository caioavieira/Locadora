using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Locadora.Application.Dtos;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace Locadora.WebApp.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public FuncionarioController(IConfiguration configuration,
                                       IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UsuarioDto usuarioDto)
        {
            usuarioDto.Tipo = Common.Enums.TipoUsuario.Funcionario;
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Usuario", usuarioDto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }

        //GET: Usuarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Usuario", typeof(IEnumerable<UsuarioDto>));
            IEnumerable<UsuarioDto> funcionarios = (IEnumerable<UsuarioDto>)response;

            return View(funcionarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
            {
                return View();
            }
    }
}
