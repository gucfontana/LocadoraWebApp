using Locadora.Dominio.ModuloPlanoCobrancas;

namespace Locadora.Testes.Unidade.ModuloPlanoCobrancas
{
    [TestClass]
    [TestCategory("Unidade")]
    public class PlanoCobrancasTestes
    {
        [TestMethod]
        public void DeveCriarInstanciaValida()
        {
            var planoCobrancas = new PlanoCobrancas(
                1, // GrupoVeiculosId
                100.0m, // ValorDiario
                1.0m, // ValorKmDiario
                200.0m, // ValorKmControlado
                80.0m, // ValorDiarioControlado
                2.0m, // ValorKmExcedido
                150.0m // ValorDiarioKmLivre
            );

            var erros = planoCobrancas.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void NaoDeveCriarInstanciaValida()
        {
            var planoCobrancas = new PlanoCobrancas(
                0, // GrupoVeiculosId
                0.0m, // ValorDiario
                0.0m, // ValorKmDiario
                0.0m, // ValorKmControlado
                0.0m, // ValorDiarioControlado
                0.0m, // ValorKmExcedido
                0.0m // ValorDiarioKmLivre
            );

            var erros = planoCobrancas.Validar();

            List<string> errosEsperados = new List<string>
            {
                "Grupo de veículos é obrigatório"
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
