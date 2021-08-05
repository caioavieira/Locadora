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
            optionsBuilder.UseSqlServer("Data Source=192.168.100.100,1433;Initial Catalog=LocadoraDB;User Id=SA;Password=Nescaubola@1");

            return new LocadoraContext(optionsBuilder.Options);
        }
    }
}
