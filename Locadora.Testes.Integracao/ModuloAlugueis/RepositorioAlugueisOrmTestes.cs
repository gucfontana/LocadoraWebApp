using FizzWare.NBuilder;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloClientes;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Testes.Integracao.Compartilhado;

namespace Locadora.Testes.Integracao.ModuloAlugueis
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioAlugueisOrmTestes : RepositorioEmOrmTestesBase
    {
        [TestMethod]
        public void Deve_Inserir_Locacao()
        {
            // Arrange
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            Veiculos ? veiculo = Builder<Veiculos>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            Combustiveis ? configCombustivel = Builder<Combustiveis>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Alugueis ? locacao = Builder<Alugueis>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.CombustivelId = configCombustivel.Id)
                .With(l => l.DataAluguel = DateTime.Now)
                .With(l => l.DataPrevistaDevolucao = DateTime.Now.AddDays(3))
                .Build();

            // Act
            repositorioLocacoes.Inserir(locacao);

            // Assert
            Alugueis ? locacaoSelecionada = repositorioLocacoes.SelecionarPorId(locacao.Id);

            Assert.IsNotNull(locacaoSelecionada);
            Assert.AreEqual(locacao, locacaoSelecionada);
        }

        [TestMethod]
        public void Deve_Editar_Locacao()
        {
            // Arrange
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            Veiculos ? veiculo = Builder<Veiculos>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            Combustiveis ? configCombustivel = Builder<Combustiveis>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Alugueis ? locacao = Builder<Alugueis>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.CombustivelId = configCombustivel.Id)
                .With(l => l.DataAluguel = DateTime.Now)
                .With(l => l.DataPrevistaDevolucao = DateTime.Now.AddDays(3))
                .Build();

            locacao.DataPrevistaDevolucao = locacao.DataPrevistaDevolucao.AddDays(2);

            // Act
            repositorioLocacoes.Editar(locacao);

            // Assert
            Alugueis ? locacaoSelecionada = repositorioLocacoes.SelecionarPorId(locacao.Id);

            Assert.IsNotNull(locacaoSelecionada);
            Assert.AreEqual(locacao, locacaoSelecionada);
        }

        [TestMethod]
        public void Deve_Excluir_Locacao()
        {
            // Arrange
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            Veiculos ? veiculo = Builder<Veiculos>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            Clientes ? cliente = Builder<Clientes>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Condutores ? condutor = Builder<Condutores>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            Combustiveis ? configCombustivel = Builder<Combustiveis>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            Alugueis ? locacao = Builder<Alugueis>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.CombustivelId = configCombustivel.Id)
                .With(l => l.DataAluguel = DateTime.Now)
                .With(l => l.DataPrevistaDevolucao = DateTime.Now.AddDays(3))
                .Persist();

            // Act
            repositorioLocacoes.Excluir(locacao);

            // Assert
            Alugueis ? locacaoSelecionada = repositorioLocacoes.SelecionarPorId(locacao.Id);
            List<Alugueis> ? locacoes = repositorioLocacoes.SelecionarTodos();

            Assert.IsNull(locacaoSelecionada);
            Assert.AreEqual(0, locacoes.Count);
        }
    }
}
