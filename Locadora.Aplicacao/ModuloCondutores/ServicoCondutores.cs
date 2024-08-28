using FluentResults;
using Locadora.Dominio.ModuloCondutores;

namespace Locadora.Aplicacao.ModuloCondutores
{
    public class ServicoCondutores
    {
        private readonly IRepositorioCondutores repositorioCondutores;
        
        public ServicoCondutores(IRepositorioCondutores repositorioCondutor)
        {
            this.repositorioCondutores = repositorioCondutor;
        }

        public Result<Condutores> Inserir(Condutores condutor)
        {
            var errosValidacao = condutor.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);

            repositorioCondutores.Inserir(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutores> Editar(Condutores condutorAtualizado)
        {
            var condutor = repositorioCondutores.SelecionarPorId(condutorAtualizado.Id);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            var errosValidacao = condutorAtualizado.Validar();

            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);

            condutor.ClienteId = condutorAtualizado.ClienteId;
            condutor.Nome = condutorAtualizado.Nome;
            condutor.Email = condutorAtualizado.Email;
            condutor.Telefone = condutorAtualizado.Telefone;
            condutor.Cpf = condutorAtualizado.Cpf;
            condutor.Cnh = condutorAtualizado.Cnh;
            condutor.ValidadeCnh = condutorAtualizado.ValidadeCnh;

            repositorioCondutores.Editar(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutores> Excluir(int condutorId)
        {
            var condutor = repositorioCondutores.SelecionarPorId(condutorId);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            repositorioCondutores.Excluir(condutor);

            return Result.Ok(condutor);
        }

        public Result<Condutores> SelecionarPorId(int condutorId)
        {
            var condutor = repositorioCondutores.SelecionarPorId(condutorId);

            if (condutor is null)
                return Result.Fail("O condutor não foi encontrado!");

            return Result.Ok(condutor);
        }

        public Result<List<Condutores>> SelecionarTodos()
        {
            var condutores = repositorioCondutores.SelecionarTodos();

            return Result.Ok(condutores);
        }

    }
}
