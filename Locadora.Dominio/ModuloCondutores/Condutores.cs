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
                erros.Add("O nome é obrigatório");

            if (string.IsNullOrWhiteSpace(Email))
                erros.Add("O email é obrigatório");

            else if (MailAddress.TryCreate(Email, out _) is false)
                erros.Add("O email deve seguir um padrão válido");

            if (string.IsNullOrWhiteSpace(Telefone))
                erros.Add("O telefone é obrigatório");

            if (string.IsNullOrWhiteSpace(Cpf))
                erros.Add("O número do CPF é obrigatório");

            if (string.IsNullOrWhiteSpace(Cnh))
                erros.Add("O número da CNH é obrigatório");

            if (ValidadeCnh < DateTime.Today)
                erros.Add("A CNH está vencida");

            return erros;
        }
    }
}
