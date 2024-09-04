using Locadora.Dominio.Compartilhado;

namespace Locadora.Dominio.ModuloTaxas
{
    public interface IRepositorioTaxas : IRepositorio<Taxas>
    {

        List<Taxas> SelecionarMuitos(List<int> idsTaxasSelecionadas);
    }
}
