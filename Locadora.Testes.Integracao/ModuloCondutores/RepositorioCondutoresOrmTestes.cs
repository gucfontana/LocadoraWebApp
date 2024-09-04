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
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Build();

            repositorioCondutor.Inserir(condutor);

            Condutores ? condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorSelecionado);
            Assert.AreEqual(condutor, condutorSelecionado);
        }

        [TestMethod]
        public void DeveEditarCondutor()
        {
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            condutor.Nome = "Nome Atualizado";
            condutor.Email = "novoemail@dominio.com";

            repositorioCondutor.Editar(condutor);

            Condutores ? condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorSelecionado);
            Assert.AreEqual(condutor, condutorSelecionado);
        }

        [TestMethod]
        public void DeveExcluirCondutor()
        {
            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            repositorioCondutor.Excluir(condutor);

            Condutores ? condutorSelecionado = repositorioCondutor.SelecionarPorId(condutor.Id);

            List<Condutores> ? condutores = repositorioCondutor.SelecionarTodos();

            Assert.IsNull(condutorSelecionado);
            Assert.AreEqual(0, condutores.Count);
        }
    }
}
