using AutoMapper;
using Locadora.Dominio.ModuloVeiculos;
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

            CreateMap<Veiculos, EditarVeiculosViewModel>();
        }
    }
}

public class FotosValueResolver : IValueResolver<FormularioVeiculosViewModel, Veiculos, byte[]>
{
    public FotosValueResolver() {}

    public byte[] Resolve
    (
        FormularioVeiculosViewModel source,
        Veiculos destination,
        byte[] destMember,
        ResolutionContext context
    )
    {
        using ( var memoryStream = new MemoryStream() )
        {
            source.Fotos.CopyTo(memoryStream);

            return memoryStream.ToArray();
        }
    }
}