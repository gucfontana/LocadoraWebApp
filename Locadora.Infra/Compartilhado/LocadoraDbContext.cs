﻿using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloAutenticacao;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Locadora.Infra.Compartilhado
{
    public class LocadoraDbContext : IdentityDbContext<Usuario, Perfil, int>
    {
        public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
        public DbSet<Veiculos> Veiculos { get; set; }
        public DbSet<PlanoCobrancas> PlanoCobrancas { get; set; }
        public DbSet<Taxas> Taxas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<Combustiveis> Combustiveis { get; set; }
        public DbSet<Alugueis> Locacoes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

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
            var assembly = typeof(LocadoraDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
