using System.Reflection;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Dominio.Compartilhado;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloGrupoVeiculos;

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

            // servicos
            builder.Services.AddScoped<ServicoGrupoVeiculos>();

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
