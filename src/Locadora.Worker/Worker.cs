using Locadora.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;

namespace Locadora.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IConnection _rabbitConnection;
        private readonly IHttpClientFactory _httpClientFactory;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IConnection rabbitConnection, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _rabbitConnection = rabbitConnection;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var canal = _rabbitConnection.CreateModel())
            {
                var consumidor = new EventingBasicConsumer(canal);
                
                consumidor.Received += async (model, ea) =>
                {
                    var corpo = ea.Body.ToArray();
                    var mensagem = Encoding.UTF8.GetString(corpo);
                    var aluguelDto = JsonSerializer.Deserialize<AluguelDto>(mensagem);

                    var httpClient = _httpClientFactory.CreateClient();
                    var response = await httpClient.PostAsJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Aluguel", aluguelDto);        

                    if (response.IsSuccessStatusCode)
                        canal.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                canal.BasicConsume(queue: "qu.solicitacao.aluguel",
                                   autoAck: false,
                                   consumer: consumidor);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker rodando no: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
