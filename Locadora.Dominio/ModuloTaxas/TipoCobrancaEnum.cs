using System.ComponentModel.DataAnnotations;

namespace Locadora.Dominio.ModuloTaxas
{
    public partial class Taxas
    {
        public enum TipoCobrancaEnum
        {
            [Display(Name = "Diária")]
            Diaria,
            Fixa
        }
    }
}
