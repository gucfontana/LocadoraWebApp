using AutoMapper;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloTaxas;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class TaxasValueResolver : IValueResolver<Alugueis, FormularioAlugueisViewModel, IEnumerable<SelectListItem> ?>
    {
        private readonly IRepositorioTaxas repositorioTaxa;

        public TaxasValueResolver(IRepositorioTaxas repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public IEnumerable<SelectListItem> ? Resolve(Alugueis source, FormularioAlugueisViewModel destination, IEnumerable<SelectListItem> ? destMember, ResolutionContext context)
        {
            return repositorioTaxa
                .SelecionarTodos()
                .Select(t => new SelectListItem(t.ToString(), t.Id.ToString()));
        }
    }
}
