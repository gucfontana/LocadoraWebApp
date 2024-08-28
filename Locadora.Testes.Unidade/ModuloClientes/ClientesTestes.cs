using Locadora.Dominio.ModuloClientes;

namespace Locadora.Testes.Unidade.ModuloClientes
{
    [TestClass]
    [TestCategory("Unidade")]
    public class ClientesTestes
    {
        [TestMethod]
        public void DeveCriarClientes()
        {
            var cliente = new Clientes(
                "John Doe",
                "johndoe@gmail.com",
                "123456789",
                TipoCadastroClienteEnum.Cpf,
                "123.123.123-12",
                "Lages",
                "Santa Catarina",
                "88555-55",
                "Rua Teste",
                "Centro"
            );

            var erros = cliente.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void NaoDeveCriarClientes()
        {
            var cliente = new Clientes(
                "",
                "",
                "",
                TipoCadastroClienteEnum.Cpf,
                "",
                "",
                "",
                "",
                "",
                ""
            );
            
            var erros = cliente.Validar();
            
            Assert.AreEqual(8, erros.Count);
        }
}
}
