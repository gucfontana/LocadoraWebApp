using Locadora.Dominio.ModuloAlugueis;

namespace Locadora.Testes.Unidade.ModuloAlugueis
{
    [TestClass]
    [TestCategory("Unidade")]
    public class AlugueisTestes
    {
        [TestMethod]
        public void DeveCriarAluguel()
        {
            // Arrange
            var aluguel = new Alugueis(
                1,
                1,
                1,
                TipoPlanoCobrancaEnum.Diario,
                DateTime.Now,
                DateTime.Now.AddDays(3)
            );

            // Act
            var erros = aluguel.Validar();

            // Assert
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarAluguelComErros()
        {
            // Arrange
            var aluguel = new Alugueis(
                condutorId: 0,
                veiculoId: 0,
                combustivelId: 0,
                tipoPlano: TipoPlanoCobrancaEnum.Diario,
                dataAluguel: DateTime.MinValue,
                dataPrevistaDevolucao: DateTime.MinValue
            );
            
            // Act
            var erros = aluguel.Validar();
            
            // Assert
            List<string> errosEsperados = new List<string>
            {
                "O condutor é obrigatório",
                "O veículo é obrigatório",
                "O combustível é obrigatório",
                "A data de aluguel é obrigatória",
                "A data prevista de devolução é obrigatória"
            };
            
            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void DeveCriarAtrasoEntrega()
        {
            // arrange
            var aluguel = new Alugueis(
                1,
                1,
                1,
                TipoPlanoCobrancaEnum.Diario,
                DateTime.Now,
                DateTime.Now.AddDays(-3)
            );
            
            // act
            var erros = aluguel.Validar();
            
            // assert
            Assert.AreEqual(1, erros.Count);
        }
    }
}
