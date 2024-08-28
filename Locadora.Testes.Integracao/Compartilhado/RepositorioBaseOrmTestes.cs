using FizzWare.NBuilder;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloClientes;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloPlanoCobrancas;
using Locadora.Infra.ModuloTaxas;
using Locadora.Infra.ModuloVeiculos;

namespace Locadora.Testes.Integracao.Compartilhado
{
    public abstract class RepositorioEmOrmTestsBase
    {
        protected LocadoraDbContext dbContext;
        protected RepositorioTaxasOrm repositorioTaxa;
        protected RepositorioClientesOrm repositorioCliente;
        protected RepositorioVeiculosOrm repositorioVeiculo;
        protected RepositorioGrupoVeiculosOrm repositorioGrupo;
        protected RepositorioPlanoCobrancasOrm repositorioPlano;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Taxas.RemoveRange(dbContext.Taxas);
            dbContext.PlanoCobrancas.RemoveRange(dbContext.PlanoCobrancas);
            dbContext.Clientes.RemoveRange(dbContext.Clientes);
            dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
            dbContext.GrupoVeiculos.RemoveRange(dbContext.GrupoVeiculos);

            dbContext.SaveChanges();

            repositorioTaxa = new RepositorioTaxasOrm(dbContext);
            repositorioPlano = new RepositorioPlanoCobrancasOrm(dbContext);
            repositorioCliente = new RepositorioClientesOrm(dbContext);
            repositorioVeiculo = new RepositorioVeiculosOrm(dbContext);
            repositorioGrupo = new RepositorioGrupoVeiculosOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Taxas>(repositorioTaxa.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobrancas>(repositorioPlano.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Clientes>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Veiculos>(repositorioVeiculo.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorioGrupo.Inserir);
        }
    }
}
