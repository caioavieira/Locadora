using Locadora.Infrastructure.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infrastructure.Fabricas
{
    public class LocadoraContextFactory : IDesignTimeDbContextFactory<LocadoraContext>
    {
        public LocadoraContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocadoraContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=locadora;User Id=SA;Password=abc,123456");

            return new LocadoraContext(optionsBuilder.Options);
        }
    }
}
