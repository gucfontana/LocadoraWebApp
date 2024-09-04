using AutoMapper;
using Locadora.Dominio.ModuloVeiculos;
using LocadoraWebApp.Mapping.Resolvers;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class VeiculosProfile : Profile
    {
        public VeiculosProfile()
        {
            CreateMap<InserirVeiculosViewModel, Veiculos>()
                .ForMember(dest => dest.Fotos,
                opt => opt.MapFrom<FotosValueResolver>());
            CreateMap<EditarVeiculosViewModel, Veiculos>()
                .ForMember(dest => dest.Fotos,
                opt => opt.MapFrom<FotosValueResolver>());

            CreateMap<Veiculos, ListarVeiculosViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome)
                );
            CreateMap<Veiculos, DetalhesVeiculosViewModel>()
                .ForMember(
                    dest => dest.GrupoVeiculos,
                    opt => opt.MapFrom(src => src.GrupoVeiculos!.Nome)
                );

            CreateMap<Veiculos, EditarVeiculosViewModel>()
                .ForMember(v => v.GrupoVeiculos, opt => opt.MapFrom<GrupoVeiculosValueResolver>());
        }
    }
}