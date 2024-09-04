using AutoMapper;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class GrupoVeiculosValueResolver : IValueResolver<object, object, IEnumerable<SelectListItem> ?>
    {
        private readonly IRepositorioGrupoVeiculos repositorioGrupo;

        public GrupoVeiculosValueResolver(IRepositorioGrupoVeiculos repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }
        
        public IEnumerable<SelectListItem> ? Resolve(object source, object destination, IEnumerable<SelectListItem> ? destMember, ResolutionContext context)
        {
            return repositorioGrupo
                .SelecionarTodos()
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
        }
    }
}
