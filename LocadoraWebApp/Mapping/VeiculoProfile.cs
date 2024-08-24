using AutoMapper;
using Locadora.Dominio.ModuloVeiculos;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class VeiculosProfile : Profile
    {
        public VeiculosProfile()
        {
            CreateMap<InserirVeiculosViewModel, Veiculos>();
            CreateMap<EditarVeiculosViewModel, Veiculos>();

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

            CreateMap<Veiculos, EditarVeiculosViewModel>();
        }
    }
}