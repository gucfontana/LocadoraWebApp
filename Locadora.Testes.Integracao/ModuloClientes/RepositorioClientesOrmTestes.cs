using FizzWare.NBuilder;
using Locadora.Dominio.ModuloClientes;
using Locadora.Testes.Integracao.Compartilhado;

namespace Locadora.Testes.Integracao.ModuloClientes
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioClientesOrmTestes : RepositorioEmOrmTestesBase
    {
        [TestMethod]
        public void DeveInserirClientes()
        {
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Build();

            repositorioCliente.Inserir(cliente);

            Clientes ? clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteSelecionado);
            Assert.AreEqual(cliente, clienteSelecionado);
        }

        [TestMethod]
        public void DeveEditarClientes()
        {
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            cliente.Nome = "Nome Atualizado";
            cliente.Email = "novoemail@dominio.com";

            repositorioCliente.Editar(cliente);

            Clientes ? clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteSelecionado);
            Assert.AreEqual(cliente, clienteSelecionado);
        }

        [TestMethod]
        public void DeveExcluirClientes()
        {
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            repositorioCliente.Excluir(cliente);

            Clientes ? clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            List<Clientes> ? clientes = repositorioCliente.SelecionarTodos();

            Assert.IsNull(clienteSelecionado);
            Assert.AreEqual(0, clientes.Count);
        }
    }
}
