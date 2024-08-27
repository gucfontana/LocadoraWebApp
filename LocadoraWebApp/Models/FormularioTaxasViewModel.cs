using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.ModuloTaxas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Models
{
    public class FormularioTaxasViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O tipo de cobrança é obrigatório")]
        public Taxas.TipoCobrancaEnum TipoCobranca { get; set; }

        public IEnumerable<SelectListItem> ? TiposCobranca { get; set; }
    }

    public class InserirTaxasViewModel : FormularioTaxasViewModel
    {
    }

    public class EditarTaxasViewModel : FormularioTaxasViewModel
    {
        public int Id { get; set; }
    }

    public class ListarTaxasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string TipoCobranca { get; set; }
    }

    public class DetalhesTaxasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string TipoCobranca { get; set; }
    }
}
