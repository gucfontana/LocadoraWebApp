using AutoMapper;
using Locadora.Dominio.ModuloAlugueis;
using LocadoraWebApp.Mapping.Resolvers;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping
{
    public class AlugueisProfile : Profile
    {
        public AlugueisProfile()
        {
            CreateMap<InserirLocacaoViewModel, Alugueis>()
                .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

            CreateMap<RealizarDevolucaoViewModel, Alugueis>()
                .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

            CreateMap<Alugueis, ListarLocacaoViewModel>()
                .ForMember(l => l.Veiculo, opt => opt.MapFrom(src => src.Veiculo!.Modelo))
                .ForMember(l => l.Condutor, opt => opt.MapFrom(src => src.Condutor!.Nome))
                .ForMember(l => l.TipoPlano, opt => opt.MapFrom(src => src.TipoPlano.ToString()));

            CreateMap<Alugueis, RealizarDevolucaoViewModel>()
                .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
                .ForMember(l => l.Veiculos, opt => opt.MapFrom<VeiculosValueResolver>())
                .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
                .ForMember(l => l.TaxasSelecionadas,
                    opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

            // Check-in
            CreateMap<Alugueis, ConfirmarAberturaLocacaoViewModel>()
                .ForMember(l => l.ValorParcial, opt => opt.MapFrom<ValorParcialValueResolver>())
                .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
                .ForMember(l => l.Veiculos, opt => opt.MapFrom<VeiculosValueResolver>())
                .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
                .ForMember(l => l.TaxasSelecionadas,
                    opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

            CreateMap<ConfirmarAberturaLocacaoViewModel, Alugueis>()
                .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());

            // Check-out
            CreateMap<Alugueis, ConfirmarDevolucaoLocacaoViewModel>()
                .ForMember(vm => vm.ValorTotal, opt => opt.MapFrom<ValorTotalValueResolver>())
                .ForMember(l => l.Condutores, opt => opt.MapFrom<CondutoresValueResolver>())
                .ForMember(l => l.Veiculos, opt => opt.MapFrom<VeiculosValueResolver>())
                .ForMember(l => l.Taxas, opt => opt.MapFrom<TaxasValueResolver>())
                .ForMember(l => l.TaxasSelecionadas,
                    opt => opt.MapFrom(src => src.TaxasSelecionadas.Select(tx => tx.Id)));

            CreateMap<ConfirmarDevolucaoLocacaoViewModel, Alugueis>()
                .ForMember(l => l.TaxasSelecionadas, opt => opt.MapFrom<TaxasSelecionadasValueResolver>());
        }
    }
}
