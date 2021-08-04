using Locadora.Infrastructure.Contextos;
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
    }
}