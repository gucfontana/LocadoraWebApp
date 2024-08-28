using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.ModuloClientes;

namespace LocadoraWebApp.Models
{
    public class FormularioClientesViewModel
    {
        [Required(ErrorMessage = "O nome � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email � obrigat�rio")]
        [EmailAddress(ErrorMessage = "O email deve ser v�lido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio")]
        [Phone(ErrorMessage = "O telefone deve ser v�lido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O tipo de cadastro � obrigat�rio")]
        public TipoCadastroClienteEnum TipoCadastro { get; set; }

        [Required(ErrorMessage = "O n�mero do documento � obrigat�rio")]
        [MinLength(11, ErrorMessage = "O n�mero do documento deve conter ao menos 11 caracteres")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "A cidade � obrigat�ria")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado � obrigat�rio")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O bairro � obrigat�rio")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A rua � obrigat�ria")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O Cep � obrigat�rio")]
        public string Cep { get; set; }
    }

    public class InserirClientesViewModel : FormularioClientesViewModel
    {
    }

    public class EditarClientesViewModel : FormularioClientesViewModel
    {
        public int Id { get; set; }
    }

    public class ListarClientesViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string TipoCadastro { get; set; }
        public string NumeroDocumento { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
    }

    public class DetalhesClientesViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string TipoCadastro { get; set; }
        public string NumeroDocumento { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
    }
}