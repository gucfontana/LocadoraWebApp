namespace Locadora.Dominio.ModuloCombustiveis
{
    public interface IRepositorioCombustiveis
    {
        Task GravarConfiguracaoCombustiveis(ConfigCombustiveis configCombustiveis);
        Task<ConfigCombustiveis ?> ObterConfiguracaoCombustiveis();
    }
}
