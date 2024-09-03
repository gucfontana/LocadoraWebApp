using FluentResults;
using Locadora.Dominio.ModuloCombustiveis;

namespace Locadora.Aplicacao.ModuloCombustiveis
{
    public class ServicoCombustiveis
    {
        private readonly IRepositorioCombustiveis repositorioConfig;

        public ServicoCombustiveis(IRepositorioCombustiveis repositorioConfig)
        {
            this.repositorioConfig = repositorioConfig;
        }

        public Result SalvarConfiguracao(Combustiveis configuracao)
        {
            configuracao.DataCriacao = DateTime.Now;

            repositorioConfig.GravarConfiguracao(configuracao);

            return Result.Ok();
        }

        public Result<Combustiveis> ObterConfiguracao()
        {
            var config = repositorioConfig.ObterConfiguracao();

            if (config is null)
            {
                config = new Combustiveis(
                    valorAlcool: 0.0m,
                    valorDiesel: 0.0m,
                    valorGas: 0.0m,
                    valorGasolina: 0.0m
                );
            }

            return Result.Ok(config);
        }
    }
}