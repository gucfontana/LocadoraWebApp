using Locadora.Dominio.ModuloGrupoVeiculos;

namespace Locadora.Testes.Unidade.ModuloGrupoVeiculos
{
    [TestClass]
    [TestCategory("Unidade")]
    public class GrupoVeiculosTestes
    {
        [TestMethod]
        public void DeveCriarGrupoVeiculos()
        {
            // arrange
            var nome = "Grupo A";

            // act
            var grupoVeiculos = new GrupoVeiculos(nome);

            var erros = grupoVeiculos.Validar();

            // assert
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void NaoDeveCriarGrupoVeiculosComNomeVazio()
        {
            // arrange
            var grupo = new GrupoVeiculos("");

            // act
            var erros = grupo.Validar();

            List<string> errosEsperados = ["Nome é obrigatório"];

            // assert
            Assert.AreEqual(1, erros.Count);
            Assert.AreEqual(errosEsperados, erros);
        }
    }
}
