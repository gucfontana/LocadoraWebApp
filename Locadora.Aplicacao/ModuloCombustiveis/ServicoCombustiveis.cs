using FluentResults;
using Locadora.Dominio.ModuloCombustiveis;

namespace Locadora.Aplicacao.ModuloCombustiveis
{
    public class ServicoCombustiveis
    {
        private readonly IRepositorioCombustiveis repositorioConfig;

        public ServicoCombustiveis
        (
            IRepositorioCombustiveis repositorioConfig
        )
        {
            this.repositorioConfig = repositorioConfig;
        }

        public async Task<Result> SalvarConfiguracaoAsync(Combustiveis configuracao)
        {
            await repositorioConfig.GravarConfiguracaoCombustiveis(configuracao);

            return Result.Ok();
        }

        public async Task<Result<Combustiveis>> ObterConfiguracaoAsync()
        {
            var config = await repositorioConfig.ObterConfiguracaoCombustiveis();

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