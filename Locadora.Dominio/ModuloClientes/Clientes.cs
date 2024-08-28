using System.Net.Mail;
using Locadora.Dominio.Compartilhado;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Locadora.Dominio.ModuloClientes
{
    public class Clientes : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoCadastroClienteEnum TipoCadastroCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }

        protected Clientes() {} //frameworks

        public Clientes
        (
            string nome,
            string email,
            string telefone,
            TipoCadastroClienteEnum tipoCadastroCliente,
            string numeroDocumento,
            string cidade,
            string estado,
            string cep,
            string rua,
            string bairro
        ) : this()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoCadastroCliente = tipoCadastroCliente;
            NumeroDocumento = numeroDocumento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
        }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(Email))
            erros.Add("O e-mail do cliente deve ser informado.");
        else if (MailAddress.TryCreate(Email, out _) is false)
            erros.Add("O e-mail deve seguir o padrao informado.");
        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O telefone do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(NumeroDocumento))
            erros.Add("O numero documento do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(Cidade))
            erros.Add("A cidade do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(Estado))
            erros.Add("O estado do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(Cep))
            erros.Add("O cep do cliente deve ser informado.");
        if (string.IsNullOrWhiteSpace(Rua))
            erros.Add("A rua do cliente deve ser informado.");
        
        return erros;
    } 
    }
}
