using System.Net.Mail;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloClientes;

namespace Locadora.Dominio.ModuloCondutores
{
    public class Condutores : EntidadeBase
    {
        public int ClienteId { get; set; }
        public Clientes ? Cliente { get; set; }
        public bool ClienteCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime ValidadeCnh { get; set; }

        protected Condutores() {} // frameworks

        public Condutores
        (
            int clienteId,
            bool clienteCondutor,
            string nome,
            string email,
            string telefone,
            string cpf,
            string cnh,
            DateTime validadeCnh
        ) : this()
        {
            ClienteId = clienteId;
            ClienteCondutor = clienteCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Cnh = cnh;
            ValidadeCnh = validadeCnh;
        }

    public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O nome � obrigat�rio");

            if (string.IsNullOrWhiteSpace(Email))
                erros.Add("O email � obrigat�rio");

            else if (MailAddress.TryCreate(Email, out _) is false)
                erros.Add("O email deve seguir um padr�o v�lido");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O telefone � obrigat�rio");

            if (string.IsNullOrWhiteSpace(Cpf))
                erros.Add("O n�mero do CPF � obrigat�rio");

            if (string.IsNullOrWhiteSpace(Cnh))
                erros.Add("O n�mero da CNH � obrigat�rio");

            if (ValidadeCnh < DateTime.Today)
                erros.Add("A CNH est� vencida");

            return erros;
        }
    }
}
