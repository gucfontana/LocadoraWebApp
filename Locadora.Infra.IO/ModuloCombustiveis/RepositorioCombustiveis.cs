using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Infra.IO.Extensions;

namespace Locadora.Infra.IO.ModuloCombustiveis;

public class RepositorioCombustiveis : IRepositorioCombustiveis 
{
    private readonly string caminhoArquivoConfiguracao;

    public RepositorioCombustiveis()
    {
        caminhoArquivoConfiguracao = Path.Join(
            Directory.GetCurrentDirectory(),
            "configuracaoCombustivel.json"
        );
    }

    public async Task GravarConfiguracaoCombustiveis(Combustiveis configCombustiveis)
    {
        FileInfo arquivo = new FileInfo(caminhoArquivoConfiguracao);

        await arquivo.SerializarAsync(configCombustiveis);
    }

    public async Task<Combustiveis ?> ObterConfiguracaoCombustiveis()
    {
        FileInfo arquivo = new FileInfo(caminhoArquivoConfiguracao);

        if (!arquivo.Exists) return null;

        return await arquivo.DeserializarAsync<Combustiveis>();
    }
}
