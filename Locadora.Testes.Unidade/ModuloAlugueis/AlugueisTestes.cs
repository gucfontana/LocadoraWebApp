using Locadora.Dominio.ModuloAlugueis;

namespace Locadora.Testes.Unidade.ModuloAlugueis
{
    [TestClass]
    [TestCategory("Unidade")]
    public class AlugueisTestes
    {
        [TestMethod]
        public void DeveCriarAluguelValido()
        {
            // Arrange
            var aluguel = new Alugueis(
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataAluguel: DateTime.Now,
                devolucaoPrevista: DateTime.Now.AddDays(3)
            );

            // Act
            var erros = aluguel.Validar();

            // Assert
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarAluguelInvalido()
        {
                // Arrange
                var aluguel = new Alugueis(
                    veiculoId: 0,
                    condutorId: 0,
                    configuracaoCombustivelId: 1,
                    planoCobranca: TipoPlanoCobrancaEnum.Diario,
                    dataAluguel: DateTime.MinValue,
                    devolucaoPrevista: DateTime.MinValue
                );

                // Act
                var erros = aluguel.Validar();

                // Assert
                List<string> errosEsperados =
                [
                    "O condutor é obrigatório",
                    "O veículo é obrigatório",
                    "Selecione a data da locação",
                    "Selecione a data prevista da entrega"
                ];

                Assert.AreEqual(errosEsperados.Count, erros.Count);
                CollectionAssert.AreEqual(errosEsperados, erros);
            }
        }
    }

