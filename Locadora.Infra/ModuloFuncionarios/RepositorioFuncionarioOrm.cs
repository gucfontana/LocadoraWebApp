using Locadora.Dominio.ModuloFuncionario;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloFuncionarios
{
    public class RepositorioFuncionarioOrm : RepositorioBaseOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Funcionario> ObterRegistros()
        {
            return dbContext.Funcionarios;
        }

        public override Funcionario ? SelecionarPorId(int funcionarioId)
        {
            return dbContext.Funcionarios
                .Include(u => u.Empresa)
                .FirstOrDefault(f => f.Id == funcionarioId);
        }

        public Funcionario ? SelecionarPorId(Func<Funcionario, bool> predicate)
        {
            return dbContext.Funcionarios
                .Include(u => u.Empresa)
                .FirstOrDefault(predicate);
        }

        public List<Funcionario> SelecionarTodos(Func<Funcionario, bool> predicate)
        {
            return dbContext.Funcionarios
                .Include(u => u.Empresa)
                .Where(predicate)
                .ToList();
        }
    }
}
