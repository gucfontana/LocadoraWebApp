using AutoMapper;
using Locadora.Dominio.ModuloPlanoCobrancas;
using LocadoraWebApp.Mapping.Resolvers;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class PlanoCobrancaProfile : Profile
    {
        public PlanoCobrancaProfile()
        {
            CreateMap<InserirPlanoCobrancasViewModel, PlanoCobrancas>();
            CreateMap<EditarPlanoCobrancasViewModel, PlanoCobrancas>();

            CreateMap<PlanoCobrancas, ListarPlanoCobrancasViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome));

            CreateMap<PlanoCobrancas, DetalhesPlanoCobrancasViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome));

            CreateMap<PlanoCobrancas, EditarPlanoCobrancasViewModel>()
                .ForMember(dest => dest.GruposVeiculos, opt => opt.MapFrom<GrupoVeiculosResolver>());
        }
    }
}
