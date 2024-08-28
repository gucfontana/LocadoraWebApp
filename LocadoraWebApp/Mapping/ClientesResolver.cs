using AutoMapper;
using Locadora.Dominio.ModuloClientes;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
            CreateMap<InserirClientesViewModel, Clientes>();
            CreateMap<EditarClientesViewModel, Clientes>();

            CreateMap<Clientes, ListarClientesViewModel>()
                .ForMember(
                    dest => dest.TipoCadastro,
                    opt => opt.MapFrom(x => x.TipoCadastroCliente.ToString())
                );

            CreateMap<Clientes, DetalhesClientesViewModel>()
                .ForMember(
                    dest => dest.TipoCadastro,
                    opt => opt.MapFrom(x => x.TipoCadastroCliente.ToString())
                );

            CreateMap<Clientes, EditarClientesViewModel>();
        }
    }
}
