using AutoMapper;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloTaxas;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class TaxasSelecionadasValueResolver : IValueResolver<FormularioAlugueisViewModel, Alugueis, List<Taxas>>
    {
        private readonly IRepositorioTaxas repositorioTaxa;

        public TaxasSelecionadasValueResolver(IRepositorioTaxas repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }
        
        public List<Taxas> Resolve(FormularioAlugueisViewModel source, Alugueis destination, List<Taxas> destMember, ResolutionContext context)
        {
            var idsTaxasSelecionadas = source.TaxasSelecionadas.ToList();

            return repositorioTaxa.SelecionarMuitos(idsTaxasSelecionadas);
        }
    }
}
