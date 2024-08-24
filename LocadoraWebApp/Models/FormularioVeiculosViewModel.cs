using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Models
{
    public class FormularioVeiculosViewModel
    {
        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória")]
        [MinLength(2, ErrorMessage = "A marca deve conter ao menos 2 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O tipo de combustível é obrigatório")]
        public int TipoCombustivel { get; set; }

        [Required(ErrorMessage = "A capacidade do tanque é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade do tanque deve ser maior que 0")]
        public int CapacidadeTanque { get; set; }

        [Required(ErrorMessage = "O grupo de veículos é obrigatório")]
        public int GrupoVeiculosId { get; set; }

        public IEnumerable<SelectListItem> ? GrupoVeiculos { get; set; }

        [Required(ErrorMessage = "A foto é obrigatória")]
        public IFormFile Fotos { get; set; }
    }

    public class InserirVeiculosViewModel : FormularioVeiculosViewModel
    {
    }

    public class EditarVeiculosViewModel : FormularioVeiculosViewModel
    {
        public int Id { get; set; }
    }

    public class ListarVeiculosViewModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public string GrupoVeiculos { get; set; }
    }

    public class DetalhesVeiculosViewModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public string GrupoVeiculos { get; set; }
    }
}