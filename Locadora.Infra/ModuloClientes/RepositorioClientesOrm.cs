using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloClientes;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloClientes;

public class RepositorioClientesOrm : RepositorioBaseOrm<Clientes>, IRepositorioClientes
{
    public RepositorioClientesOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Clientes> ObterRegistros()
    {
        return dbContext.Clientes;
    }
}
