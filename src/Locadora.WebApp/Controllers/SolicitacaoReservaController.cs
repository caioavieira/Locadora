using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Locadora.WebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Locadora.Application.Dtos;
using System.Net.Http.Json;

namespace Locadora.WebApp.Controllers
{
    public class SolicitacaoReservaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public SolicitacaoReservaController(IConfiguration configuration,
                                            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();            
            var response = await httpClient.GetFromJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Produto", typeof(IEnumerable<ProdutoDto>));

            ViewBag.Produtos = response;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([FromBody] AluguelDto aluguelDto)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Aluguel", aluguelDto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            return RedirectToAction(nameof(Index), nameof(HomeController));
        }
    }
}
