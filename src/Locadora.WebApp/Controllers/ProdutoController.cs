using Locadora.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
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

        //GET: Usuarios
        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     var httpClient = _httpClientFactory.CreateClient();
        //     var response = await httpClient.GetFromJsonAsync(_configuration.GetValue<string>("AppSettings:LocadoraApiUrl") + "/api/Usuario", typeof(IEnumerable<UsuarioDto>));
        //     return View(response);
        // }

        // GET: Usuarios/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        // GET: Usuarios/Create
        // public IActionResult Create()
        //     {
        //         return View();
        //     }


        //[HttpPost]
        //public IActionResult Create(UsuarioDto usuarioDto)
        //{
        //    try
        //    {
        //        usuarioDto.Tipo = Common.Enums.TipoUsuario.Funcionario;
        //        _ = _cadastrarUsuarioHandler.Criar(usuarioDto);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return BadRequest(ex.Message + " inválido(a)");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return StatusCode(500, "Erro ao executar ação");
        //    }
        //}

        // GET: Usuarios/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _context.Usuarios.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(usuario);
        //}

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Documento,Tipo,Email,Senha,Telefone,DDD,Debito")] Usuario usuario)
        //{
        //    if (id != usuario.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(usuario);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioExists(usuario.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(usuario);
        //}

        // GET: Usuarios/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        // POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var usuario = await _context.Usuarios.FindAsync(id);
        //    _context.Usuarios.Remove(usuario);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsuarioExists(Guid id)
        //{
        //    return _context.Usuarios.Any(e => e.Id == id);
        //}
    }
}