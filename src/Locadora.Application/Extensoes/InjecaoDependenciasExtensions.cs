using Locadora.Application.Handlers;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using Locadora.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Application.Extensoes
{
    public static class InjecaoDependenciasExtensions
    {
        public static void AddContexto(this IServiceCollection servicos, string stringConexao)
        {
            servicos.AddDbContext<LocadoraContext>(options =>
                options.UseSqlServer(stringConexao));
        }

        public static void AddRepositorios(this IServiceCollection servicos)
        {
            servicos.AddScoped<IAluguelRepository, AluguelRepository>();
            servicos.AddScoped<IProdutoRepository, ProdutoRepository>();
            servicos.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public static void AddHandlers(this IServiceCollection servicos)
        {
            servicos.AddScoped((serviceProvider) => 
            {
                var locadoraContext = serviceProvider.GetRequiredService<LocadoraContext>();
                var repositorioUsuario = serviceProvider.GetRequiredService<IUsuarioRepository>();
                return new CadastrarUsuarioHandler(locadoraContext, repositorioUsuario);
            });

            servicos.AddScoped((serviceProvider) => 
            {
                var locadoraContext = serviceProvider.GetRequiredService<LocadoraContext>();
                var repositorioAluguel = serviceProvider.GetRequiredService<IAluguelRepository>();
                var repositorioProduto = serviceProvider.GetRequiredService<IProdutoRepository>();
                var repositorioUsuario = serviceProvider.GetRequiredService<IUsuarioRepository>();
                return new SolicitarAluguelHandler(locadoraContext, repositorioAluguel, repositorioProduto, repositorioUsuario);
            });

            servicos.AddScoped((serviceProvider) => 
            {
                var repositorioProduto = serviceProvider.GetRequiredService<IProdutoRepository>();
                return new ListarProdutosHandler(repositorioProduto);
            });
            
            servicos.AddScoped((serviceProvider) => 
            {
                var locadoraContext = serviceProvider.GetRequiredService<LocadoraContext>();
                var produtoRepository = serviceProvider.GetRequiredService<IProdutoRepository>();
                return new CadastrarProdutoHandler(locadoraContext, produtoRepository);
            });
        }
    }
}