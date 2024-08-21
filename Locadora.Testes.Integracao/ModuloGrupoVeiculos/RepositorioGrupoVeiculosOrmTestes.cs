using FizzWare.NBuilder;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloGrupoVeiculos;

namespace Locadora.Testes.Integracao.ModuloGrupoVeiculos
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioGrupoVeiculosEmOrmTests
    {
        private LocadoraDbContext dbContext;
        private RepositorioGrupoVeiculosOrm repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.GrupoVeiculos.RemoveRange(dbContext.GrupoVeiculos);

            repositorio = new RepositorioGrupoVeiculosOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorio.Inserir);
        }

        [TestMethod]
        public void Deve_Inserir_GrupoVeiculos()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id, 0)
                .Persist();

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoSelecionado);
            Assert.AreEqual(grupo, grupoSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_GrupoVeiculos()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .Persist();

            grupo.Nome = "Teste de Edição";
            repositorio.Editar(grupo);

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoSelecionado);
            Assert.AreEqual(grupo, grupoSelecionado);
        }

        [TestMethod]
        public void Deve_Excluir_GrupoVeiculos()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .Persist();

            repositorio.Excluir(grupo);

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

            var grupos = repositorio.SelecionarTodos();

            Assert.IsNull(grupoSelecionado);
            Assert.AreEqual(0, grupos.Count);
        }
    }
}
