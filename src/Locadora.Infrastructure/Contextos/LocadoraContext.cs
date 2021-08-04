using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Domain.Entidades;


namespace Locadora.Infrastructure.Contextos
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {        
        }
    }
}