using Locadora.Dominio.ModuloTaxas;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloTaxas
{
    public class RepositorioTaxasOrm(LocadoraDbContext dbContext) : RepositorioBaseOrm<Taxas>(dbContext), IRepositorioTaxas
    {
        protected override DbSet<Taxas> ObterRegistros()
        {
            return dbContext.Taxas;
        }

        public List<Taxas> SelecionarMuitos(List<int> idsTaxasSelecionadas)
        {
            throw new NotImplementedException();
        }
    }
}
