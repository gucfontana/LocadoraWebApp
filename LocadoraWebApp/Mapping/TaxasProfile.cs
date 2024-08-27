using AutoMapper;
using Locadora.Dominio.ModuloTaxas;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class TaxasProfile : Profile
    {
        public TaxasProfile()
        {
            CreateMap<InserirTaxasViewModel, Taxas>();
            CreateMap<EditarTaxasViewModel, Taxas>();

            CreateMap<Taxas, ListarTaxasViewModel>()
                .ForMember(
                    dest => dest.TipoCobranca,
                    opt => opt.MapFrom(x => x.TipoCobranca.ToString())
                );

            CreateMap<Taxas, DetalhesTaxasViewModel>()
                .ForMember(
                    dest => dest.TipoCobranca,
                    opt => opt.MapFrom(x => x.TipoCobranca.ToString())
                );

            CreateMap<Taxas, EditarTaxasViewModel>();
        }
    }
}