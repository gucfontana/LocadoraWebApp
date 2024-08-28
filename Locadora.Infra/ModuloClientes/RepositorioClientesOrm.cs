using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloClientes;
using Locadora.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.ModuloClientes;

public class RepositorioClientesEmOrm : RepositorioBaseOrm<Clientes>, IRepositorioClientes
{
    public RepositorioClientesEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Clientes> ObterRegistros()
    {
        return dbContext.Clientes;
    }
}
