using System.ComponentModel.DataAnnotations;

namespace LocadoraWebApp.Models
{
    public class RegistrarViewModel
    {
        [Required]
        public string ? Usuario { get; set; }

        [Required]
        [EmailAddress]
        public string ? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ? Senha { get; set; }

        [Display(Name = "Confirme a senha)")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas nao conferem")]
        public string ? ConfirmarSenha { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string ? Usuario { get; set; }
        
        [Required(ErrorMessage = "A senha e obrigatoria")]
        [DataType(DataType.Password)]
        public string ? Senha { get; set; }
    }
}
