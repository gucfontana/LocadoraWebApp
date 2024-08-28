using System.ComponentModel.DataAnnotations;

namespace Locadora.Dominio.ModuloClientes
{
    public enum TipoCadastroClienteEnum
    {
        [Display(Name = "Pessoa fisica")]
        Cpf,

        [Display(Name = "Pessoa juridica")]
        Cnpj
    }
}