using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.ModuloClientes;

namespace LocadoraWebApp.Models
{
    public class FormularioClientesViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email deve ser válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "O telefone deve ser válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O tipo de cadastro é obrigatório")]
        public TipoCadastroClienteEnum TipoCadastro { get; set; }

        [Required(ErrorMessage = "O número do documento é obrigatório")]
        [MinLength(11, ErrorMessage = "O número do documento deve conter ao menos 11 caracteres")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O Cep é obrigatório")]
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