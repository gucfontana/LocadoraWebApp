using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloPlanoCobrancas
{
    public class RepositorioPlanoCobrancasOrm : RepositorioBaseOrm<PlanoCobrancas>, IRepositorio<PlanoCobrancas>
    {
        public RepositorioPlanoCobrancasOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<PlanoCobrancas> ObterRegistros()
        {
            return dbContext.PlanoCobrancas;
        }

        public override PlanoCobrancas ? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(p => p.GrupoVeiculos)
                .FirstOrDefault(p => p.Id == id);
        }

        public override List<PlanoCobrancas> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(p => p.GrupoVeiculos)
                .AsNoTracking()
                .ToList();
        }
    }
}
