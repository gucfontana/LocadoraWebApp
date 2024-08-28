using Locadora.Dominio.ModuloCondutores;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;

namespace Locadora.Testes.Unidade.ModuloCondutores
{
    [TestClass]
    [TestCategory("Unidade")]
    public class CondutoresTestes
    {
        [TestMethod]
        public void DeveCriarCondutores()
        {
            var condutor = new Condutores(
                clienteId: 1,
                clienteCondutor: true,
                nome: "John Testes",
                email: "testes.john@gmail.com",
                telefone: "(24) 12345-1234",
                cpf: "123.456.789-00",
                cnh: "12345678901",
                validadeCnh: DateTime.Today.AddYears(1)
            );

            var erros = condutor.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void DeveCriarErroEmail()
        {
            var condutor = new Condutores(
                clienteId: 1,
                clienteCondutor: true,
                nome: "John Testes",
                email: "",
                telefone: "(21) 12345-1234",
                cpf: "123.456.789-00",
                cnh: "12345678901",
                validadeCnh: DateTime.Today.AddYears(1)
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O email é obrigatório"
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void DeveCriarErroTelefone()
        {
            var condutor = new Condutores(
                clienteId: 1,
                clienteCondutor: true,
                nome: "John Testes",
                email: "testes.john@gmail.com",
                telefone: "",
                cpf: "123.456.789-00",
                cnh: "12345678901",
                validadeCnh: DateTime.Today.AddYears(1)
            );

            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>
            {
                "O telefone é obrigatório"
            };

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void NaoDeveCriarCondutores()
        {
            var condutor = new Condutores(
                clienteId: 1,
                clienteCondutor: true,
                nome: "",
                email: "",
                telefone: "",
                cpf: "",
                cnh: "",
                // fazer a validadecnh estar vencida
                validadeCnh: DateTime.Today.AddYears(-1)
            );
            
            var erros = condutor.Validar();

            List<string> errosEsperados = new List<string>()
            {
                "O nome é obrigatório",
                "O email é obrigatório",
                "O telefone é obrigatório",
                "O número do CPF é obrigatório",
                "O número da CNH é obrigatório",
                "A CNH está vencida"
            };
            
            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
}
}
