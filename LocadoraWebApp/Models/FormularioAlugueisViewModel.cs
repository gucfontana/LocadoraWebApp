using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.ModuloAlugueis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Models
{
    public class FormularioAlugueisViewModel
    {
        [Required(ErrorMessage = "O ve�culo � obrigat�rio")]
    public int VeiculoId { get; set; }

    [Required(ErrorMessage = "O condutor � obrigat�rio")]
    public int CondutorId { get; set; }

    [Required(ErrorMessage = "O tipo de plano � obrigat�rio")]
    public TipoPlanoCobrancaEnum TipoPlano { get; set; }

    [Required(ErrorMessage = "O marcador de combust�vel � obrigat�rio")]
    public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

    [Required(ErrorMessage = "A quilometragem percorrida � obrigat�ria")]
    [Range(0, int.MaxValue, ErrorMessage = "A quilometragem percorrida deve ser maior ou igual a 0")]
    public int QuilometragemPercorrida { get; set; }

    [Required(ErrorMessage = "A data da loca��o � obrigat�ria")]
    [DataType(DataType.Date)]
    public DateTime DataLocacao { get; set; }

    [Required(ErrorMessage = "A data prevista de devolu��o � obrigat�ria")]
    [DataType(DataType.Date)]
    public DateTime DevolucaoPrevista { get; set; }

    public IEnumerable<int> TaxasSelecionadas { get; set; }

    public IEnumerable<SelectListItem>? Veiculos { get; set; }
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    public IEnumerable<SelectListItem>? Taxas { get; set; }

    public FormularioAlugueisViewModel()
    {
        DataLocacao = DateTime.Now;
        DevolucaoPrevista = DateTime.Now.AddDays(1);
        MarcadorCombustivel = MarcadorCombustivelEnum.Cheio;
    }
}

public class InserirLocacaoViewModel : FormularioAlugueisViewModel
{
}

public class EditarLocacaoViewModel : FormularioAlugueisViewModel
{
    public int Id { get; set; }
}

public class RealizarDevolucaoViewModel : FormularioAlugueisViewModel
{
    public int Id { get; set; }
}

public class ConfirmarAberturaLocacaoViewModel : FormularioAlugueisViewModel
{
    public decimal ValorParcial { get; set; }
}

public class ConfirmarDevolucaoLocacaoViewModel : FormularioAlugueisViewModel
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
}

public class ListarLocacaoViewModel
{
    public int Id { get; set; }
    public string Veiculo { get; set; }
    public string Condutor { get; set; }
    public string TipoPlano { get; set; }
    public int QuilometragemPercorrida { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DevolucaoPrevista { get; set; }
    public DateTime? DataDevolucao { get; set; }
}

public class DetalhesLocacaoViewModel
{
    public int Id { get; set; }
    public string Veiculo { get; set; }
    public string Condutor { get; set; }
    public string TipoPlano { get; set; }
    public string MarcadorCombustivel { get; set; }
    public int QuilometragemPercorrida { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DevolucaoPrevista { get; set; }
    public DateTime? DataDevolucao { get; set; }
    }
}
