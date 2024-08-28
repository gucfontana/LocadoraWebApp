using FizzWare.NBuilder;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Testes.Integracao.Compartilhado;

namespace Locadora.Testes.Integracao.ModuloCondutores
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioCondutoresOrmTestes : RepositorioEmOrmTestesBase
    {
        [TestMethod]
        public void DeveInserirCondutor()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            repositorioCondutor.Inserir(condutor);

            var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorSelecionado);
            Assert.AreEqual(condutor, condutorSelecionado);
        }

        [TestMethod]
        public void DeveEditarCondutor()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            condutor.Nome = "Nome Atualizado";
            condutor.Email = "novoemail@dominio.com";

            repositorioCondutor.Editar(condutor);

            var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorSelecionado);
            Assert.AreEqual(condutor, condutorSelecionado);
        }

        [TestMethod]
        public void DeveExcluirCondutor()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            repositorioCondutor.Excluir(condutor);

            var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            var condutores = repositorioCondutor.SelecionarTodos();

            Assert.IsNull(condutorSelecionado);
            Assert.AreEqual(0, condutores.Count);
        }
    }
}
