using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloCondutores;
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
    }
}