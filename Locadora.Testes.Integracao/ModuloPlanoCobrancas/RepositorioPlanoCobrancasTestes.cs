using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloPlanoCobrancas;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloPlanoCobrancas;

namespace Locadora.Testes.Integracao.ModuloPlanoCobrancas
{
    [TestClass]
    [TestCategory("Integracao")]
    public class RepositorioPlanoCobrancasTestes
    {
        private LocadoraDbContext dbContext;
        private RepositorioPlanoCobrancasOrm repositorio;
        private RepositorioGrupoVeiculosOrm repositorioGrupoVeiculos;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.PlanoCobrancas.RemoveRange(dbContext.PlanoCobrancas);
            dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
            dbContext.GrupoVeiculos.RemoveRange(dbContext.GrupoVeiculos);

            repositorio = new RepositorioPlanoCobrancasOrm(dbContext);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<PlanoCobrancas>(repositorio.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorioGrupoVeiculos.Inserir);
        }

        [TestMethod]
        public void DeveInserirPlanoCobrancas()
        {
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            PlanoCobrancas ? planoCobrancas = Builder<PlanoCobrancas>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(p => p.GrupoVeiculosId = grupo.Id)
                .Build();

            repositorio.Inserir(planoCobrancas);

            PlanoCobrancas ? planoCobrancasInserido = repositorio.SelecionarPorId(planoCobrancas.Id);

            Assert.IsNotNull(planoCobrancasInserido);
            Assert.AreEqual(planoCobrancas, planoCobrancasInserido);
        }

        [TestMethod]
        public void DeveEditarPlanoCobrancas()
        {
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            PlanoCobrancas ? planoCobrancas = Builder<PlanoCobrancas>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(p => p.GrupoVeiculosId = grupo.Id)
                .Persist();

            planoCobrancas.ValorDiario = 100;

            repositorio.Editar(planoCobrancas);

            PlanoCobrancas ? planoCobrancasEditado = repositorio.SelecionarPorId(planoCobrancas.Id);

            Assert.IsNotNull(planoCobrancasEditado);
            Assert.AreEqual(planoCobrancas, planoCobrancasEditado);
        }

        [TestMethod]
        public void DeveExcluirPlanoCobrancas()
        {
            GrupoVeiculos ? grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            PlanoCobrancas ? planoCobrancas = Builder<PlanoCobrancas>
                .CreateNew()
                .With(p => p.Id = 0)
                .With(p => p.GrupoVeiculosId = grupo.Id)
                .Persist();

            repositorio.Excluir(planoCobrancas);

            PlanoCobrancas ? planoCobrancasExcluido = repositorio.SelecionarPorId(planoCobrancas.Id);

            List<PlanoCobrancas> ? planosCobrancas = repositorio.SelecionarTodos();

            Assert.IsNull(planoCobrancasExcluido);
            Assert.AreEqual(0, planosCobrancas.Count);
        }
    }
}
