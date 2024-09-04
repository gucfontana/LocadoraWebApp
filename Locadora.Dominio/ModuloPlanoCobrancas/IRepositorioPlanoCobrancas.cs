using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloPlanoCobrancas
{
    public interface IRepositorioPlanoCobrancas : IRepositorio<PlanoCobrancas>
    {
        PlanoCobrancas ? FiltrarPlano(Func<PlanoCobrancas, bool> predicate);
    }
}
