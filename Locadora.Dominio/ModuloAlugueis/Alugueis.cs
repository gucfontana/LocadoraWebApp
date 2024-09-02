using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
using Locadora.Dominio.ModuloTaxas;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Dominio.ModuloAlugueis
{
    public class Alugueis : EntidadeBase
    {
        public int CondutorId { get; set; }
        public Condutores ? Condutor { get; set; }

        public int VeiculoId { get; set; }
        public Veiculos ? Veiculo { get; set; }

        public int ConfiguracaoCombustivelId { get; set; }
        public Combustiveis ? ConfiguracaoCombustivel { get; set; }

        public TipoPlanoCobrancaEnum TipoPlano { get; set; }
        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        public DateTime DataAluguel { get; set; }
        public DateTime DevolucaoPrevista { get; set; }
        public DateTime ? DataDevolucao { get; set; }

        public List<Taxas> TaxasSelecionadas { get; set; }

        protected Alugueis()
        {
            TaxasSelecionadas = new List<Taxas>();
            DataDevolucao = null;
            MarcadorCombustivel = MarcadorCombustivelEnum.Completo;
        }

        public Alugueis
        (
            int condutorId,
            int veiculoId,
            int configuracaoCombustivelId,
            TipoPlanoCobrancaEnum planoCobranca,
            DateTime dataAluguel,
            DateTime devolucaoPrevista
        ) : this()
        {
            CondutorId = condutorId;
            VeiculoId = veiculoId;
            ConfiguracaoCombustivelId = configuracaoCombustivelId;
            TipoPlano = planoCobranca;
            DataAluguel = dataAluguel;
            DevolucaoPrevista = devolucaoPrevista;
        }

        public void Abrir()
        {
            if (Veiculo is null) return;

            Veiculos.Alugar();
        }

        public void RealizarDevolucao()
        {
            DataDevolucao = DateTime.Now;

            if (Veiculo is null) return;

            Veiculos.Desocupar();
        }

        public bool TemMulta()
        {
            if (DataDevolucao is null)
                return ( DateTime.Now - DevolucaoPrevista ).Days > 0;

            return ( DataDevolucao - DevolucaoPrevista ).Value.Days > 0;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (CondutorId == 0)
                erros.Add("O condutor é obrigatório");

            if (VeiculoId == 0)
                erros.Add("O veículo é obrigatório");

            if (DataAluguel == DateTime.MinValue)
                erros.Add("Selecione a data da locação");

            if (DevolucaoPrevista == DateTime.MinValue)
                erros.Add("Selecione a data prevista da entrega");

            if (DevolucaoPrevista < DataAluguel)
                erros.Add("A data prevista da entrega não pode ser menor que data da locação");

            return erros;
        }
    }
}