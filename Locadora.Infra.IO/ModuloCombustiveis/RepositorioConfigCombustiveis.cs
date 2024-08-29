using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Infra.IO.Extensions;

namespace Locadora.Infra.IO.ModuloCombustiveis;

public class RepositorioConfigCombustiveis : IRepositorioCombustiveis 
{
    private readonly string caminhoArquivoConfiguracao;

    public RepositorioConfigCombustiveis()
    {
        caminhoArquivoConfiguracao = Path.Join(
            Directory.GetCurrentDirectory(),
            "configuracaoCombustivel.json"
        );
    }
    
    public async Task GravarConfiguracaoCombustiveis(ConfigCombustiveis configCombustiveis)
    {
        FileInfo arquivo = new FileInfo(caminhoArquivoConfiguracao);

        await arquivo.SerializarAsync(configCombustiveis);
    }

    public async Task<ConfigCombustiveis ?> ObterConfiguracaoCombustiveis()
    {
        FileInfo arquivo = new FileInfo(caminhoArquivoConfiguracao);

        if (!arquivo.Exists) return null;

        return await arquivo.DeserializarAsync<ConfigCombustiveis>();
    }
}
