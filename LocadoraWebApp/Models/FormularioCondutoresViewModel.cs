using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.ModuloClientes;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Models
{
    public class SelecionarClientesViewModel
    {
        [Required(ErrorMessage = "O cliente � obrigat�rio")]
        public int ClienteId { get; set; }

        public bool ClienteCondutores { get; set; }

        public IEnumerable<SelectListItem> ? Clientes { get; set; }
    }

    public class FormularioCondutoresViewModel
    {
        [Required(ErrorMessage = "O cliente � obrigat�rio")]
        public int ClienteId { get; set; }

        public bool ClienteCondutores { get; set; }

        [Required(ErrorMessage = "O nome � obrigat�rio")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email � obrigat�rio")]
        [EmailAddress(ErrorMessage = "O email deve ser v�lido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone � obrigat�rio")]
        [Phone(ErrorMessage = "O telefone deve ser v�lido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF � obrigat�rio")]
        [MinLength(11, ErrorMessage = "O CPF deve conter ao menos 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O n�mero da CNH � obrigat�rio")]
        public string Cnh { get; set; }

        [Required(ErrorMessage = "A validade da CNH � obrigat�ria")]
        [DataType(DataType.Date, ErrorMessage = "A validade da CNH deve ser uma data v�lida")]
        public DateTime ValidadeCnh { get; set; }

        public IEnumerable<SelectListItem> Clientes { get; set; }
    }

    public class InserirCondutoresViewModel : FormularioCondutoresViewModel
    {
    }

    public class ListarCondutoresViewModel
    {
        public int Id { get; set; }

        public string Cliente { get; set; }
        public bool ClienteCondutor { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string CPF { get; set; }
        public string CNH { get; set; }
        public string ValidadeCNH { get; set; }
    }

    public class DetalhesCondutoresViewModel
    {
        public int Id { get; set; }

        public string Cliente { get; set; }
        public bool ClienteCondutor { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string CPF { get; set; }
        public string CNH { get; set; }
        public string ValidadeCNH { get; set; }
    }
}

