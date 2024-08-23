using FizzWare.NBuilder;
using Locadora.Dominio.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloVeiculos;
using Locadora.Infra.Compartilhado;
using Locadora.Infra.ModuloGrupoVeiculos;
using Locadora.Infra.ModuloVeiculos;

namespace Locadora.Testes.Integracao.ModuloVeiculos
{
    [TestClass]
[TestCategory("Integração")]
public class RepositorioVeiculosOrmTestes
    {
    private LocadoraDbContext dbContext;
    private RepositorioVeiculosOrm repositorio;
    private RepositorioGrupoVeiculosOrm repositorioGrupo;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
        dbContext.GrupoVeiculos.RemoveRange(dbContext.GrupoVeiculos);

        repositorio = new RepositorioVeiculosOrm(dbContext);
        repositorioGrupo = new RepositorioGrupoVeiculosOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<Veiculos>(repositorio.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorioGrupo.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_Veiculo()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Veiculos>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .Persist();

        var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

        Assert.IsNotNull(veiculoSelecionado);
        Assert.AreEqual(veiculo, veiculoSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Veiculo()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Veiculos>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .Persist();

        veiculo.Modelo = "Novo Modelo";

        repositorio.Editar(veiculo);

        var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

        Assert.IsNotNull(veiculoSelecionado);
        Assert.AreEqual(veiculo, veiculoSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_Veiculo()
    {
        var grupo = Builder<GrupoVeiculos>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var veiculo = Builder<Veiculos>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoVeiculosId = grupo.Id)
            .Persist();

        repositorio.Excluir(veiculo);

        var veiculoSelecionado = repositorio.SelecionarPorId(veiculo.Id);

        var veiculos = repositorio.SelecionarTodos();

        Assert.IsNull(veiculoSelecionado);
        Assert.AreEqual(0, veiculos.Count);
    }
}
}
