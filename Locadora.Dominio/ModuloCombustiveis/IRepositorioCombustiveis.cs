namespace Locadora.Dominio.ModuloCombustiveis
{
    public interface IRepositorioCombustiveis
    {
        Task GravarConfiguracaoCombustiveis(Combustiveis configCombustiveis);
        Task<Combustiveis ?> ObterConfiguracaoCombustiveis();
    }
}
