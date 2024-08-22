using AutoMapper;
using Locadora.Dominio.ModuloGrupoVeiculos;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class GrupoVeiculosProfile : Profile
    {
        public GrupoVeiculosProfile()
        {
            CreateMap<InserirGrupoVeiculosViewModel, GrupoVeiculos>();
CreateMap<EditarGrupoVeiculosViewModel, GrupoVeiculos>();

            CreateMap<GrupoVeiculos, ListarGrupoVeiculosViewModel>();
            CreateMap<GrupoVeiculos, DetalhesGrupoVeiculosViewModel>();
            CreateMap<GrupoVeiculos, EditarGrupoVeiculosViewModel>();
        }
    }
}