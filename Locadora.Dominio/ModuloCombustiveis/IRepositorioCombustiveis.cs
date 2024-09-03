namespace Locadora.Dominio.ModuloCombustiveis
{
    public interface IRepositorioCombustiveis
    {
        void GravarConfiguracao(Combustiveis configuracao);
        Combustiveis ObterConfiguracao();
    }
}
