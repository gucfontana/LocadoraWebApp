using Locadora.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Locadora.Dominio.ModuloTaxas
{
    public partial class Taxas : EntidadeBase
    {

        public string ? Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }

        protected Taxas()
        {
        }

        public Taxas(string nome, decimal valor, TipoCobrancaEnum tipoCobranca) : this()
        {
            Nome = nome;
            Valor = valor;
            TipoCobranca = tipoCobranca;
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
