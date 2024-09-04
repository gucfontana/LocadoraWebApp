using FluentResults;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Microsoft.Identity.Client;

namespace Locadora.Aplicacao.ModuloPlanoCobrancas
{
    public class ServicoPlanoCobrancas
    {
        private readonly IRepositorioPlanoCobrancas repositorioPlanoCobrancas;

        public ServicoPlanoCobrancas(IRepositorioPlanoCobrancas repositorioPlanoCobrancas)
        {
            this.repositorioPlanoCobrancas = repositorioPlanoCobrancas;
        }

        public Result<PlanoCobrancas> Inserir(PlanoCobrancas planoCobrancas)
        {
            repositorioPlanoCobrancas.Inserir(planoCobrancas);

            return Result.Ok(planoCobrancas);
        }

        public Result<PlanoCobrancas> Editar(PlanoCobrancas planoCobrancasEditado)
        {
            var planoCobrancas = repositorioPlanoCobrancas.SelecionarPorId(planoCobrancasEditado.Id);

            if (planoCobrancas is null)
                return Result.Fail<PlanoCobrancas>("Plano de cobrança não encontrado");

            planoCobrancas.GrupoVeiculosId = planoCobrancasEditado.GrupoVeiculosId;
            planoCobrancas.ValorDiario = planoCobrancasEditado.ValorDiario;
            planoCobrancas.ValorDiarioControlado = planoCobrancasEditado.ValorDiarioControlado;
            planoCobrancas.ValorDiarioKmLivre = planoCobrancasEditado.ValorDiarioKmLivre;
            planoCobrancas.ValorKmDiario = planoCobrancasEditado.ValorKmDiario;
            planoCobrancas.ValorKmExcedido = planoCobrancasEditado.ValorKmExcedido;
            planoCobrancas.ValorKmControlado = planoCobrancasEditado.ValorKmControlado;

            repositorioPlanoCobrancas.Editar(planoCobrancas);

            return Result.Ok(planoCobrancas);
        }

        public Result<PlanoCobrancas> Excluir(int id)
        {
            var planoCobrancas = repositorioPlanoCobrancas.SelecionarPorId(id);

            if (planoCobrancas is null)
                return Result.Fail("Plano de cobrança não encontrado");

            repositorioPlanoCobrancas.Excluir(planoCobrancas);

            return Result.Ok(planoCobrancas);
        }

        public Result<PlanoCobrancas> SelecionarPorId(int id)
        {
            var planoCobrancas = repositorioPlanoCobrancas.SelecionarPorId(id);

            if (planoCobrancas is null)
                return Result.Fail("Plano de cobrança não encontrado");

            return Result.Ok(planoCobrancas);
        }

        public Result<List<PlanoCobrancas>> SelecionarTodos()
        {
            var planosCobranca = repositorioPlanoCobrancas.SelecionarTodos();

            return Result.Ok(planosCobranca);
        }

        public Result<PlanoCobrancas> SelecionarPorIdGrupoVeiculos(int grupoVeiculosId)
        {
            var plano = repositorioPlanoCobrancas.FiltrarPlano(p => p.GrupoVeiculosId == grupoVeiculosId);

            if (plano is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(plano);
        }
    }
}
