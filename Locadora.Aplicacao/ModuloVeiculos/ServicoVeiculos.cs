using FluentResults;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Aplicacao.ModuloVeiculos
{
    public class ServicoVeiculos
    {
        private readonly IRepositorioVeiculos repositorioVeiculos;

        public ServicoVeiculos(IRepositorioVeiculos repositorioVeiculos)
        {
            this.repositorioVeiculos = repositorioVeiculos;
        }

        public Result<Veiculos> Inserir(Veiculos veiculos)
        {
            repositorioVeiculos.Inserir(veiculos);

            return Result.Ok(veiculos);
        }

        public Result<Veiculos> Editar(Veiculos veiculosEditados)
        {
            var veiculos = repositorioVeiculos.SelecionarPorId(veiculosEditados.Id);

            if (veiculos is null)
                return Result.Fail<Veiculos>("Veiculo não encontrado!");

veiculos.Modelo = veiculosEditados.Modelo;
            veiculos.Marca = veiculosEditados.Marca;
            veiculos.TipoCombustivel = veiculosEditados.TipoCombustivel;
            veiculos.CapacidadeTanque = veiculosEditados.CapacidadeTanque;
            veiculos.GrupoVeiculosId = veiculosEditados.GrupoVeiculosId;

            repositorioVeiculos.Editar(veiculos);

            return Result.Ok(veiculos);
        }

        public Result<Veiculos> Excluir(int id)
        {
            var veiculos = repositorioVeiculos.SelecionarPorId(id);

            if (veiculos is null)
                return Result.Fail<Veiculos>("Veiculo não encontrado!");

            repositorioVeiculos.Excluir(veiculos);

            return Result.Ok(veiculos);
        }

        public Result<Veiculos> SelecionarPorId(int id)
        {
            var veiculos = repositorioVeiculos.SelecionarPorId(id);

            if (veiculos is null)
                return Result.Fail<Veiculos>("Veiculo não encontrado!");

            return Result.Ok(veiculos);
        }

        public Result<List<Veiculos>> SelecionarTodos()
        {
            var veiculos = repositorioVeiculos.SelecionarTodos();

            return Result.Ok(veiculos);
        }
    }
}
