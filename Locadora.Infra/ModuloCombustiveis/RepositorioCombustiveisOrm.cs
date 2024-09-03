using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.ModuloCombustiveis;

    public class RepositorioCombustiveisOrm : IRepositorioCombustiveis
    {
        private readonly LocadoraDbContext dbContext;

        public RepositorioCombustiveisOrm(LocadoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GravarConfiguracao(Combustiveis configuracaoCombustivel)
        {
            dbContext.Combustiveis.Add(configuracaoCombustivel);

            dbContext.SaveChanges();
        }

        public Combustiveis ? ObterConfiguracao()
        {
            return dbContext.Combustiveis
                .OrderByDescending(c => c.Id)
                .FirstOrDefault();
        }
    }
