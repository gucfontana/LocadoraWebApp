using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosOrm : RepositorioBaseEmOrm<GrupoVeiculos>, IRepositorioGrupoVeiculos
    {
        public RepositorioGrupoVeiculosOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<GrupoVeiculos> ObterRegistros()
        {
            return dbContext.GrupoVeiculos;
        }
    }
}
