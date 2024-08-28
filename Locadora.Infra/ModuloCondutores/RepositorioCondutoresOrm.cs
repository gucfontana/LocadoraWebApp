using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloCondutores
{
    public class RepositorioCondutoresOrm : RepositorioBaseOrm<Condutores>, IRepositorioCondutores
    {
        public RepositorioCondutoresOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Condutores> ObterRegistros()
        {
            return dbContext.Condutores;
        }

        public override Condutores ? SelecionarPorId(int Id)
        {
            return ObterRegistros()
                .Include(c => c.Cliente)
                .FirstOrDefault(c => c.Id == Id);
        }
        
        public override List<Condutores> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(c => c.Cliente)
                .ToList();
        }
    }
}
