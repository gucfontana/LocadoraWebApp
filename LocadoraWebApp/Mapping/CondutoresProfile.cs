using AutoMapper;
using Locadora.Dominio.ModuloCondutores;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class CondutoresProfile : Profile
    {
        public CondutoresProfile()
        {
            CreateMap<FormularioCondutoresViewModel, Condutores>();

            CreateMap<Condutores, ListarCondutoresViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
                .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCnh.ToShortDateString()));

            CreateMap<Condutores, DetalhesCondutoresViewModel>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(c => c.Cliente!.Nome))
                .ForMember(dest => dest.ValidadeCNH, opt => opt.MapFrom(c => c.ValidadeCnh.ToShortDateString()));
        }
    }
}
