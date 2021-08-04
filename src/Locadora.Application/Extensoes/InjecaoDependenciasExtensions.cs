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
            servicos.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        public static void AddHandlers(this IServiceCollection servicos)
        {
            servicos.AddScoped((serviceProvider) => 
            {
                var locadoraContext = serviceProvider.GetRequiredService<LocadoraContext>();
                var usuarioRepository = serviceProvider.GetRequiredService<IUsuarioRepository>();
                return new CadastrarUsuarioHandler(locadoraContext, usuarioRepository);
            });
        }
    }
}