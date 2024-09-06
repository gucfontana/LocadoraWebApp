using AutoMapper;
using Locadora.Dominio.ModuloFuncionario;
using LocadoraWebApp.Mapping.Resolvers;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping;

    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<InserirFuncionarioViewModel, Funcionario>()
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom<EmpresaIdValueResolver>());

            CreateMap<Funcionario, ListarFuncionarioViewModel>();
        }
    }
