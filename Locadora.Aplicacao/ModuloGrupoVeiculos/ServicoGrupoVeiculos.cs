using FluentResults;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloGrupoVeiculos;

namespace Locadora.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private readonly IRepositorioGrupoVeiculos repositorioGrupo;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public Result<GrupoVeiculos> Inserir(GrupoVeiculos grupo)
        {
            repositorioGrupo.Inserir(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoVeiculos> Editar(GrupoVeiculos grupoEditado)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoEditado.Id);

            if (grupo == null)
                return Result.Fail("Grupo não encontrado");

            grupo.Nome = grupoEditado.Nome;

            repositorioGrupo.Editar(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoVeiculos> Excluir(int grupoId)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoId);

            if (grupo == null)
                return Result.Fail("Grupo não encontrado");

            repositorioGrupo.Excluir(grupo);

            return Result.Ok(grupo);
        }

        public Result<GrupoVeiculos> SelecionarPorId(int grupoId)
        {
            var grupo = repositorioGrupo.SelecionarPorId(grupoId);

            if (grupo == null)
                return Result.Fail("Grupo não encontrado");

            return Result.Ok(grupo);
        }

        public Result<List<GrupoVeiculos>> SelecionarTodos()
        {
            var grupos = repositorioGrupo.SelecionarTodos();

            return Result.Ok(grupos);
        }
    }
}
