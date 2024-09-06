using System.ComponentModel.DataAnnotations;

namespace LocadoraWebApp.Models;

    public class InserirFuncionarioViewModel
    {
        [Required(ErrorMessage = "O nome do funcion�rio � obrigat�rio")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O nome de usu�rio � obrigat�rio")]
        public string NomeUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password), Compare("Senha", ErrorMessage = "As senhas n�o conferem")]
        public string ConfirmarSenha { get; set; }

        [DataType(DataType.Date)]
        public DateTime Admissao { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        public InserirFuncionarioViewModel()
        {
            Admissao = DateTime.Now;
        }
    }

    public class ListarFuncionarioViewModel
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime Admissao { get; set; }
        public decimal Salario { get; set; }
    }
