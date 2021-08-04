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
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Funcionario>();
            builder.Entity<Cliente>();

            base.OnModelCreating(builder);
        }
    }
}