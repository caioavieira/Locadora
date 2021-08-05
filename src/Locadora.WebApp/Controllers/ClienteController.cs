using Locadora.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Locadora.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClienteController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UsuarioDto usuarioDto) 
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Usuario", usuarioDto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            return RedirectToAction(nameof(Create));
        }
    }
}
