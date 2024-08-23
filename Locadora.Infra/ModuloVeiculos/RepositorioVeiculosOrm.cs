using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Infra.ModuloVeiculos
{
    public class RepositorioVeiculosOrm : RepositorioBaseEmOrm<Veiculos>, IRepositorioVeiculos
    {
        public RepositorioVeiculosOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Veiculos> ObterRegistros()
        {
            return dbContext.Veiculos;
        }

        public override Veiculos ? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(v => v.GrupoVeiculos)
                .FirstOrDefault(v => v.Id == id);
        }

        public override List<Veiculos> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(v => v.GrupoVeiculos)
                .ToList();
        }

}
}
