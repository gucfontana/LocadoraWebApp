using Locadora.Dominio.ModuloTaxas;

namespace Locadora.Testes.Unidade.ModuloTaxas
{
    [TestClass]
    [TestCategory("Unidade")]
    public class TaxaTestes
    {
        [TestMethod]
        public void DeveCriarTaxa()
        {
            var taxa = new Taxas(
                "Taxa de serviço",
                10.0m,
                Taxas.TipoCobrancaEnum.Diaria
            );

            var erros = taxa.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarTaxaErroNome()
        {
            var taxa = new Taxas(
                "Tx",
                10.0m,
                Taxas.TipoCobrancaEnum.Diaria
            );

            var erros = taxa.Validar();

            List<string> errosEsperados =
                ["Nome deve ter pelo menos 3 caracteres"];

            Assert.AreEqual(erros.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void DeveCriarTaxaErroValor()
        {
            var taxa = new Taxas(
                "Taxa de servico",
                0.5m,
                Taxas.TipoCobrancaEnum.Diaria
            );

            var erros = taxa.Validar();

            List<string> errosEsperados = ["Valor deve ser maior que zero"];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void DeveCriarTaxaErroAmbos()
        {
            var taxa = new Taxas(
                "Tx",
                0.5m,
                Taxas.TipoCobrancaEnum.Diaria
            );
            
            var erros = taxa.Validar();
            
            List<string> errosEsperados =
                [
                    "Nome deve ter pelo menos 3 caracteres",
                    "Valor deve ser maior que zero"
                ];
            
            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
}
}
