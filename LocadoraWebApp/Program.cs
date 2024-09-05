using System.Reflection;
using Locadora.Aplicacao.ModuloAlugueis;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloClientes;
using Locadora.Aplicacao.ModuloCombustiveis;
using Locadora.Aplicacao.ModuloCondutores;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Aplicacao.ModuloPlanoCobrancas;
using Locadora.Aplicacao.ModuloTaxas;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloAutenticacao;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloAlugueis;
using Locadora.Infra.ModuloClientes;
using Locadora.Infra.ModuloCombustiveis;
using Locadora.Infra.ModuloCondutores;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloPlanoCobrancas;
using Locadora.Infra.ModuloTaxas;
using Locadora.Infra.ModuloVeiculos;
using LocadoraWebApp.Mapping.Resolvers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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
            builder.Services.AddScoped<IRepositorioCombustiveis, RepositorioCombustiveisOrm>();
            builder.Services.AddScoped<IRepositorioAlugueis, RepositorioAlugueisOrm>();


            // servicos
            builder.Services.AddScoped<ServicoGrupoVeiculos>();
            builder.Services.AddScoped<ServicoVeiculos>();
            builder.Services.AddScoped<ServicoPlanoCobrancas>();
            builder.Services.AddScoped<ServicoTaxas>();
            builder.Services.AddScoped<ServicoClientes>();
            builder.Services.AddScoped<ServicoCondutores>();
            builder.Services.AddScoped<ServicoCombustiveis>();
            builder.Services.AddScoped<ServicoAlugueis>();
            
            // identity
            builder.Services.AddScoped<ServicoAutenticacao>();
            builder.Services.AddIdentity<Usuario, Perfil>().AddEntityFrameworkStores<LocadoraDbContext>().AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "AspNetCore.Cookies";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Autenticacao/Login";
                options.AccessDeniedPath = "/AcessoNegado";
            });

            // features
            builder.Services.AddScoped<FotosValueResolver>();
            builder.Services.AddScoped<GrupoVeiculosValueResolver>();
            builder.Services.AddScoped<TaxasSelecionadasValueResolver>();

            builder.Services.AddScoped<TaxasValueResolver>();
            builder.Services.AddScoped<CondutoresValueResolver>();
            builder.Services.AddScoped<VeiculosValueResolver>();
            builder.Services.AddScoped<ValorParcialValueResolver>();
            builder.Services.AddScoped<ValorTotalValueResolver>();

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
