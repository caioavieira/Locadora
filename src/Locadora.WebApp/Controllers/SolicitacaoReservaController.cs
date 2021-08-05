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
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Locadora.WebApp.Controllers
{
    public class SolicitacaoReservaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _rabbitConnection;
        private readonly IHttpClientFactory _httpClientFactory;

        public SolicitacaoReservaController(IConfiguration configuration,
                                            IConnection rabbitConnection,
                                            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _rabbitConnection = rabbitConnection;
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
        public IActionResult Index([FromForm] AluguelDto aluguelDto)
        {
            using (var canal = _rabbitConnection.CreateModel())
            {
                canal.QueueDeclare(queue: "qu.solicitacao.aluguel",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);


                string mensagem = JsonSerializer.Serialize(aluguelDto);
                var corpo = Encoding.UTF8.GetBytes(mensagem);

                canal.BasicPublish(exchange: string.Empty,
                                    routingKey: "qu.solicitacao.aluguel",
                                    basicProperties: null,
                                    body: corpo);
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
