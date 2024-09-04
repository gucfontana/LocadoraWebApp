using AutoMapper;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.ModuloAlugueis;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class VeiculosValueResolver : IValueResolver<Alugueis, FormularioAlugueisViewModel, IEnumerable<SelectListItem>?>
    {
        private readonly ServicoVeiculos _servicoVeiculo;

        public VeiculosValueResolver(ServicoVeiculos servicoVeiculo)
        {
            _servicoVeiculo = servicoVeiculo;
        }
        
        public IEnumerable<SelectListItem> ? Resolve(Alugueis source, FormularioAlugueisViewModel destination, IEnumerable<SelectListItem> ? destMember, ResolutionContext context)
        {
            if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
            {
                var veiculoSelecionado = _servicoVeiculo.SelecionarPorId(source.VeiculoId).Value;

                return [new SelectListItem(veiculoSelecionado!.Modelo, veiculoSelecionado.Id.ToString())];
            }

            return _servicoVeiculo
                .SelecionarTodos()
                .Value
                .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
        } 
    }
}
