using System.ComponentModel.DataAnnotations;
using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloTaxas
{
    public class Taxas(string ? nome, decimal valor, Taxas.TipoCobrancaEnum tipoCobranca) : EntidadeBase
    {

        private string ? Nome { get; set; } = nome;
        private decimal Valor { get; set; } = valor;
        public TipoCobrancaEnum TipoCobranca { get; set; }

        public enum TipoCobrancaEnum
        {
            [Display(Name = "Diária")]
            Diaria,
            Fixa
        } 
        
        public override List<string> Validar()
        {
            List<string> erros = [];
            
            if (Nome?.Length < 3)
                erros.Add("Nome deve ter pelo menos 3 caracteres");
            
            if (Valor < 1.0m)
                erros.Add("Valor deve ser maior que zero");

            return erros;
        }
    }
}
