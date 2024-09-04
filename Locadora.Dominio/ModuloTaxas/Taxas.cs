using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloAlugueis;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Locadora.Dominio.ModuloTaxas
{
    public partial class Taxas : EntidadeBase
    {

        public string ? Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }
        public IEnumerable<Alugueis> ? Locacoes { get; set; }

        protected Taxas()
        {
            Locacoes = new List<Alugueis>();
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

        public decimal CalcularValor(int quantidadeDeDias)
        {
            if (TipoCobranca == TipoCobrancaEnum.Diaria)
            {
                return Valor * quantidadeDeDias;
            }

            return Valor;
        }
    }
}
