using AutoMapper;
using Locadora.Dominio.ModuloCombustiveis;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping;

    public class ConfiguracaoCombustivelProfile : Profile
    {
        public ConfiguracaoCombustivelProfile()
        {
            CreateMap<FormularioCombustiveisViewModel, Combustiveis>();
            CreateMap<Combustiveis, FormularioCombustiveisViewModel>();
        }
    }