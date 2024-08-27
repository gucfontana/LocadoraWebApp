using AutoMapper;
using Locadora.Infra.ModuloGrupoVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class GrupoVeiculosResolver : IValueResolver<object, object, IEnumerable<SelectListItem>?>
    {
        private readonly IRepositorioGrupoVeiculos repositorioGrupo;

        public GrupoVeiculosResolver(IRepositorioGrupoVeiculos repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public IEnumerable<SelectListItem> Resolve
        (
            object source,
            object destination,
            IEnumerable<SelectListItem>? destMember,
            ResolutionContext context
        )
        {
            return repositorioGrupo
                .SelecionarTodos()
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
        }
    }
}
