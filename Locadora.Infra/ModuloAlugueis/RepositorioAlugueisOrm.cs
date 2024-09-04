using Locadora.Dominio.ModuloAlugueis;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloAlugueis
{
    public class RepositorioAlugueisOrm : RepositorioBaseOrm<Alugueis>, IRepositorioAlugueis
    {
        public RepositorioAlugueisOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Alugueis> ObterRegistros()
        {
            return dbContext.Locacoes;
        }

        public override Alugueis ? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(l => l.Condutor)
                .Include(l => l.Veiculo)
                .Include(l => l.Combustiveis)
                .Include(l => l.TaxasSelecionadas)
                .FirstOrDefault(l => l.Id == id);
        }

        public override List<Alugueis> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(l => l.Condutor)
                .Include(l => l.Veiculo)
                .Include(l => l.Combustiveis)
                .ToList();
        }
    }
}