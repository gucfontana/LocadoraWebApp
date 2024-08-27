using FizzWare.NBuilder;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloTaxas;

namespace Locadora.Testes.Integracao.ModuloTaxas
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioTaxasTestes
    {
        private LocadoraDbContext dbContext;
        private RepositorioTaxasOrm repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.Taxas.RemoveRange(dbContext.Taxas);

            repositorio = new RepositorioTaxasOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Taxas>(repositorio.Inserir);
        }

        [TestMethod]
        public void DeveInserirTaxa()
        {
            var taxa = Builder<Taxas>
                .CreateNew()
                .With(t => t.Id = 0)
                .With(t => t.Nome = "Taxa de servico")
                .With(t => t.Valor = 50.0m)
                .With(t => t.TipoCobranca = Taxas.TipoCobrancaEnum.Diaria)
                .Build();
            
            repositorio.Inserir(taxa);

            var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);
            
            Assert.IsNotNull(taxaSelecionada);
            Assert.AreEqual(taxa, taxaSelecionada);
        }

        [TestMethod]
        public void DeveEditarTaxa()
        {
            var taxa = Builder<Taxas>
                .CreateNew()
                .With(t => t.Id = 0)
                .Persist();

            taxa.Nome = "Taxa Atualizada";
            taxa.Valor = 100.0m;

            repositorio.Editar(taxa);

            var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaSelecionada);
            Assert.AreEqual(taxa, taxaSelecionada);
        }

        [TestMethod]
        public void DeveExcluirTaxa()
        {
            var taxa = Builder<Taxas>
                .CreateNew()
                .With(t => t.Id = 0)
                .Persist();

            repositorio.Excluir(taxa);

            var taxaSelecionada = repositorio.SelecionarPorId(taxa.Id);

            var taxas = repositorio.SelecionarTodos();

            Assert.IsNull(taxaSelecionada);
            Assert.AreEqual(0, taxas.Count);
        }
}
}
