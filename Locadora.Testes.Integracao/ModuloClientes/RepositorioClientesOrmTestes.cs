using FizzWare.NBuilder;
using Locadora.Dominio.ModuloClientes;
using Locadora.Testes.Integracao.Compartilhado;

namespace Locadora.Testes.Integracao.ModuloClientes
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioClientesOrmTestes : RepositorioEmOrmTestsBase
    {
        [TestMethod]
        public void DeveInserirClientes()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Build();

            repositorioCliente.Inserir(cliente);

            var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteSelecionado);
            Assert.AreEqual(cliente, clienteSelecionado);
        }

        [TestMethod]
        public void DeveEditarClientes()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            cliente.Nome = "Nome Atualizado";
            cliente.Email = "novoemail@dominio.com";

            repositorioCliente.Editar(cliente);

            var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteSelecionado);
            Assert.AreEqual(cliente, clienteSelecionado);
        }

        [TestMethod]
        public void DeveExcluirClientes()
        {
            var cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            repositorioCliente.Excluir(cliente);

            var clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            var clientes = repositorioCliente.SelecionarTodos();

            Assert.IsNull(clienteSelecionado);
            Assert.AreEqual(0, clientes.Count);
        }
    }
}
