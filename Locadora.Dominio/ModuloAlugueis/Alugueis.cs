using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Dominio.ModuloAlugueis
{
    public class Alugueis : EntidadeBase
    {
        // infos condutor
        public int CondutorId { get; set; } // propriedade
        public Condutores ? Condutor { get; set; } // objeto

        // infos veiculo
        public int VeiculoId { get; set; } // propriedade
        public Veiculos ? Veiculo { get; set; } // objeto

        // infos combustivel
        public int CombustivelId { get; set; } // propriedade
        public Combustiveis ? Combustiveis { get; set; } // objeto

        public TipoPlanoCobrancaEnum TipoPlano { get; set; } // propriedade
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; } // propriedade

        public int KmPercorrido { get; set; } // propriedade

        public DateTime DataAluguel { get; set; } // propriedade
        public DateTime DataPrevistaDevolucao { get; set; } // propriedade
        public DateTime ? DataDevolucao { get; set; } // propriedade

        public List<Taxas> TaxasSelecionadas { get; set; } // propriedade

        // construtor
        protected Alugueis()
        {
            TaxasSelecionadas = new List<Taxas>();
            DataDevolucao = null;
            MarcadorCombustivel = MarcadorCombustivelEnum.Cheio;
        }

        public Alugueis
        (
            int condutorId,
            int veiculoId,
            int combustivelId,
            TipoPlanoCobrancaEnum tipoPlano,
            DateTime dataAluguel,
            DateTime dataPrevistaDevolucao
        ) : this()
        {
            CondutorId = condutorId;
            VeiculoId = veiculoId;
            CombustivelId = combustivelId;
            TipoPlano = tipoPlano;
            DataAluguel = dataAluguel;
            DataPrevistaDevolucao = dataPrevistaDevolucao;
        }

        public void Abrir()
        {
            if (Veiculo is null) return;

            Veiculo.Alugar();
        }

        public void Devolver()
        {
            DataDevolucao = DateTime.Now;

            if (Veiculo is null) return;

            Veiculo.Entregar();
        }

        // validar
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (CondutorId == 0)
                erros.Add("O condutor é obrigatório");
            if (VeiculoId == 0)
                erros.Add("O veículo é obrigatório");
            if (CombustivelId == 0)
                erros.Add("O combustível é obrigatório");
            if (DataAluguel == DateTime.MinValue)
                erros.Add("A data de aluguel é obrigatória");
            if (DataPrevistaDevolucao == DateTime.MinValue)
                erros.Add("A data prevista de devolução é obrigatória");
            if (DataPrevistaDevolucao < DataAluguel)
                erros.Add("A data prevista de devolução deve ser maior que a data de aluguel");

            return erros;
        }

        public decimal CalcularValorTotal(PlanoCobrancas planoCobranca)
        {
            var valorParcial = CalcularValorParcial(planoCobranca);

            decimal totalAbastecimento = 0;

            if (Veiculo is not null && Combustiveis is not null)
            {
                var valorCombustivel = Combustiveis.ObterValorCombustivel(Veiculo.TipoCombustivel);

                totalAbastecimento = (decimal)Veiculo.CalcularLitrosParaAbastecimento(MarcadorCombustivel) * (decimal)valorCombustivel;
            }

            decimal valorTotal = valorParcial + totalAbastecimento;

            if (TemMulta()) // Multa de 10%
                valorTotal += valorTotal * ( 10m / 100m );

            return valorTotal;
        }

        public decimal CalcularValorParcial(PlanoCobrancas planoSelecionado)
            {
                int quantidadeDiasPercorridos = ObterQuantidadeDeDiasPercorridos();

                decimal valorPlano = planoSelecionado.CalcularValor(
                    quantidadeDiasPercorridos,
                    KmPercorrido,
                    TipoPlano
                );

                decimal valorTaxas = 0;

                if (TaxasSelecionadas.Count > 0)
                    valorTaxas = TaxasSelecionadas.Sum(tx => tx.CalcularValor(quantidadeDiasPercorridos));

                return valorPlano + valorTaxas;
            }

            private int ObterQuantidadeDeDiasPercorridos()
            {
                int qtdDiasLocacao;

                if (DataDevolucao is null)
                    qtdDiasLocacao = ( DataPrevistaDevolucao.Date - DataAluguel.Date ).Days;
                else
                    qtdDiasLocacao = ( DataDevolucao - DataAluguel ).Value.Days;

                return qtdDiasLocacao;
            }

            private bool TemMulta()
            {
                if (DataDevolucao is null)
                    return ( DateTime.Now - DataPrevistaDevolucao ).Days > 0;

                return ( DataDevolucao - DataPrevistaDevolucao ).Value.Days > 0;
            }

            public void RealizarDevolucao()
            {
                throw new NotImplementedException();
            }
    }
}