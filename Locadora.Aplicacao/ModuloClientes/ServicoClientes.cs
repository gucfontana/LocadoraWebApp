using FluentResults;
using Locadora.Dominio.ModuloClientes;

namespace Locadora.Aplicacao.ModuloClientes
{
    public class ServicoClientes
    {
            private readonly IRepositorioClientes repositorioCliente;

    public ServicoClientes(IRepositorioClientes repositorioCliente)
    {
        this.repositorioCliente = repositorioCliente;
    }

    public Result<Clientes> Inserir(Clientes cliente)
    {
        var errosValidacao = cliente.Validar();

        if (errosValidacao.Count > 0)
            return Result.Fail(errosValidacao);

        repositorioCliente.Inserir(cliente);

        return Result.Ok(cliente);
    }

    public Result<Clientes> Editar(Clientes clienteAtualizado)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteAtualizado.Id);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado!");

        var errosValidacao = clienteAtualizado.Validar();

        if (errosValidacao.Count > 0)
            return Result.Fail(errosValidacao);

        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;
        cliente.TipoCadastroCliente = clienteAtualizado.TipoCadastroCliente;
        cliente.NumeroDocumento = clienteAtualizado.NumeroDocumento;
        cliente.Cidade = clienteAtualizado.Cidade;
        cliente.Estado = clienteAtualizado.Estado;
        cliente.Cep = clienteAtualizado.Cep;
        cliente.Bairro = clienteAtualizado.Bairro;
        cliente.Rua = clienteAtualizado.Rua;

        repositorioCliente.Editar(cliente);

        return Result.Ok(cliente);
    }

    public Result<Clientes> Excluir(int clienteId)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteId);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado!");

        repositorioCliente.Excluir(cliente);

        return Result.Ok(cliente);
    }

    public Result<Clientes> SelecionarPorId(int clienteId)
    {
        var cliente = repositorioCliente.SelecionarPorId(clienteId);

        if (cliente is null)
            return Result.Fail("O cliente não foi encontrado!");

        return Result.Ok(cliente);
    }

    public Result<List<Clientes>> SelecionarTodos()
    {
        var clientes = repositorioCliente.SelecionarTodos();

        return Result.Ok(clientes);
    }
    }
}
