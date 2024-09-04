using FluentResults;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Aplicacao.ModuloAlugueis
{
    public class ServicoAlugueis
    {
        private readonly IRepositorioAlugueis repositorioLocacao;
        private readonly IRepositorioCombustiveis repositorioCombustivel;
        private readonly IRepositorioVeiculos repositorioVeiculo;

        public ServicoAlugueis
        (
            IRepositorioAlugueis repositorioLocacao,
            IRepositorioCombustiveis repositorioCombustivel,
            IRepositorioVeiculos repositorioVeiculo
        )
        {
            this.repositorioLocacao = repositorioLocacao;
            this.repositorioCombustivel = repositorioCombustivel;
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Alugueis> Inserir(Alugueis locacao)
        {
            var config = repositorioCombustivel.ObterConfiguracao();

            if (config is null)
                return Result.Fail("Não foi possível obter a configuração de valores de combustíveis.");

            locacao.CombustivelId = config.Id;

            var erros = locacao.Validar();

            if (erros.Count > 0)
                return Result.Fail(erros);

            AbrirLocacao(locacao);

            repositorioLocacao.Inserir(locacao);

            return Result.Ok(locacao);
        }

        public Result<Alugueis> RealizarDevolucao(Alugueis locacaoParaDevolucao)
        {
            var locacao = repositorioLocacao.SelecionarPorId(locacaoParaDevolucao.Id);

            if (locacao is null)
                return Result.Fail("A locação não foi encontrada!");

            if (locacao.DataDevolucao is not null)
                return Result.Fail("A devolução já foi realizada!");

            FecharLocacao(locacao);

            repositorioLocacao.Editar(locacao);

            return Result.Ok(locacao);
        }

        public Result<Alugueis> Editar(Alugueis locacaoAtualizada)
        {
            var locacao = repositorioLocacao.SelecionarPorId(locacaoAtualizada.Id);

            if (locacao is null)
                return Result.Fail("A locação não foi encontrada!");

            if (locacao.DataDevolucao is not null)
                return Result.Fail("A devolução já foi realizada!");

            var erros = locacaoAtualizada.Validar();

            if (erros.Count > 0)
                return Result.Fail(erros);

            locacao.Veiculo!.Entregar();

            locacao.VeiculoId = locacaoAtualizada.VeiculoId;
            locacao.CondutorId = locacaoAtualizada.CondutorId;
            locacao.CombustivelId = locacaoAtualizada.CombustivelId;
            locacao.TipoPlano = locacaoAtualizada.TipoPlano;
            locacao.MarcadorCombustivel = locacaoAtualizada.MarcadorCombustivel;
            locacao.KmPercorrido = locacaoAtualizada.KmPercorrido;
            locacao.DataAluguel = locacaoAtualizada.DataAluguel;
            locacao.DataPrevistaDevolucao = locacaoAtualizada.DataPrevistaDevolucao;
            locacao.DataDevolucao = locacaoAtualizada.DataDevolucao;
            locacao.TaxasSelecionadas = locacaoAtualizada.TaxasSelecionadas;

            repositorioLocacao.Editar(locacao);

            return Result.Ok(locacao);
        }

        public Result<Alugueis> Excluir(int locacaoId)
        {
            var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

            if (locacao is null)
                return Result.Fail("A locação não foi encontrada!");

            repositorioLocacao.Excluir(locacao);

            return Result.Ok(locacao);
        }

        public Result<Alugueis> SelecionarPorId(int locacaoId)
        {
            var locacao = repositorioLocacao.SelecionarPorId(locacaoId);

            if (locacao is null)
                return Result.Fail("A locação não foi encontrada!");

            return Result.Ok(locacao);
        }

        public Result<List<Alugueis>> SelecionarTodos()
        {
            var locacoes = repositorioLocacao.SelecionarTodos();

            return Result.Ok(locacoes);
        }

        private void AbrirLocacao(Alugueis locacao)
        {
            var veiculoSelecionado = repositorioVeiculo.SelecionarPorId(locacao.VeiculoId);

            locacao.Veiculo = veiculoSelecionado;

            locacao.Abrir();

            repositorioVeiculo.Editar(locacao.Veiculo!);
        }

        private void FecharLocacao(Alugueis locacao)
        {
            var veiculoSelecionado = repositorioVeiculo.SelecionarPorId(locacao.VeiculoId);

            locacao.Veiculo = veiculoSelecionado;

            locacao.RealizarDevolucao();

            repositorioVeiculo.Editar(locacao.Veiculo!);
        }
    }
}