using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Testes.Unidade.ModuloVeiculos
{
    [TestClass]
    [TestCategory("Unidade")]
    public class VeiculoTestes
    {
        [TestMethod]
        public void DeveCriarVeiculo()
        {
            var grupo = new GrupoVeiculos("Camionete");

            var veiculo = new Veiculos("Hilux", "Toyota", TipoCombustivel.Flex, 80, 1);

            var erros = veiculo.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void NaoDeveCriarVeiculo()
        {
            var grupo = new GrupoVeiculos("Camionete");

            var veiculo = new Veiculos("", "", TipoCombustivel.Flex, 0, 0);

            var erros = veiculo.Validar();

            Assert.AreEqual(4, erros.Count);
            Assert.IsTrue(erros.Contains("Modelo é obrigatório"));
            Assert.IsTrue(erros.Contains("Marca é obrigatória"));
            Assert.IsTrue(erros.Contains("Capacidade do tanque é obrigatória"));
            Assert.IsTrue(erros.Contains("Grupo de veículos é obrigatório"));


        }
    }
}
