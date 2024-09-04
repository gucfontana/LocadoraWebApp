using AutoMapper;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloCondutores;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class CondutoresValueResolver : IValueResolver<Alugueis, FormularioAlugueisViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly IRepositorioCondutores repositorioCondutor;

        public CondutoresValueResolver(IRepositorioCondutores repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }
        
        public IEnumerable<SelectListItem> ? Resolve(Alugueis source, FormularioAlugueisViewModel destination, IEnumerable<SelectListItem> ? destMember, ResolutionContext context)
        {
            if (destination is RealizarDevolucaoViewModel or
                ConfirmarAberturaLocacaoViewModel or
                ConfirmarDevolucaoLocacaoViewModel)
            {
                var condutorSelecionado = repositorioCondutor.SelecionarPorId(source.CondutorId);

                return [new SelectListItem(condutorSelecionado!.Nome, condutorSelecionado.Id.ToString())];
            }

            return repositorioCondutor
                .SelecionarTodos()
                .Select(c => new SelectListItem(c.Nome, c.Id.ToString()));
        }
    }
}
