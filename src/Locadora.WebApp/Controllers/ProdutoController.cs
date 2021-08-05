using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Locadora.Application.Dtos;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Locadora.Common.Enums;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Locadora.WebApp.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProdutoController(IConfiguration configuration,
                                       IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
                // GET: Usuarios/Create


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Produto", typeof(IEnumerable<ProdutoDto>));

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProdutoDto produtoDto) 
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Produto", produtoDto);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            List<SelectListItem> categorias = new List<SelectListItem>();
            categorias.AddRange(Enum.GetValues(typeof(CategoriaProduto))
                                    .Cast<CategoriaProduto>()
                                    .Select(s => new SelectListItem { 
                                                                        Value = ((int)s).ToString(), 
                                                                        Text = s.GetType()
                                                                                .GetMember(s.ToString())
                                                                                .First()
                                                                                .GetCustomAttribute<DisplayAttribute>()
                                                                                .GetName() }));
            ViewBag.Categorias = categorias;
            return View();
        }
    }
}