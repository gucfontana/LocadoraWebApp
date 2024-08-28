using System.Reflection;
using Locadora.Aplicacao.ModuloClientes;
using Locadora.Aplicacao.ModuloCondutores;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Aplicacao.ModuloPlanoCobrancas;
using Locadora.Aplicacao.ModuloTaxas;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloClientes;
using Locadora.Infra.ModuloCondutores;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloPlanoCobrancas;
using Locadora.Infra.ModuloTaxas;
using Locadora.Infra.ModuloVeiculos;
using LocadoraWebApp.Mapping.Resolvers;

namespace LocadoraWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LocadoraDbContext>();

            // repositorios
             builder.Services.AddScoped<IRepositorioGrupoVeiculos, RepositorioGrupoVeiculosOrm>();
             builder.Services.AddScoped<IRepositorioVeiculos, RepositorioVeiculosOrm>();
             builder.Services.AddScoped<IRepositorioPlanoCobrancas, RepositorioPlanoCobrancasOrm>();
             builder.Services.AddScoped<IRepositorioTaxas, RepositorioTaxasOrm>();
             builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesOrm>();
             builder.Services.AddScoped<IRepositorioCondutores, RepositorioCondutoresOrm>();

            // servicos
            builder.Services.AddScoped<ServicoGrupoVeiculos>();
            builder.Services.AddScoped<ServicoVeiculos>();
            builder.Services.AddScoped<ServicoPlanoCobrancas>();
            builder.Services.AddScoped<ServicoTaxas>();
            builder.Services.AddScoped<ServicoClientes>();
            builder.Services.AddScoped<ServicoCondutores>();

            // features
            builder.Services.AddScoped<FotosValueResolver>();
            builder.Services.AddScoped<GrupoVeiculosResolver>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
