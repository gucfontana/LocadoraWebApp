using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Locadora.Infra.Compartilhado
{
    public class LocadoraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculos());
            modelBuilder.ApplyConfiguration(new MapeadorVeiculos());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; } 
    }
}
