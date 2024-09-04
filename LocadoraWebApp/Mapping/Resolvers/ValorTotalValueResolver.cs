using AutoMapper;
using Locadora.Aplicacao.ModuloPlanoCobrancas;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.ModuloAlugueis;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class ValorTotalValueResolver : IValueResolver<Alugueis, ConfirmarDevolucaoLocacaoViewModel, decimal>
    {
        private readonly ServicoVeiculos servicoVeiculo;
        private readonly ServicoPlanoCobrancas servicoPlano;

        public ValorTotalValueResolver(ServicoVeiculos servicoVeiculo, ServicoPlanoCobrancas servicoPlano)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlano = servicoPlano;
        }
        
        public decimal Resolve(Alugueis source, ConfirmarDevolucaoLocacaoViewModel destination, decimal destMember, ResolutionContext context)
        {
                var veiculo = servicoVeiculo.SelecionarPorId(source.VeiculoId).Value;

                var planoSelecionado = servicoPlano.SelecionarPorIdGrupoVeiculos(veiculo.GrupoVeiculosId).Value;

                return source.CalcularValorTotal(planoSelecionado);
            }
        }
}

