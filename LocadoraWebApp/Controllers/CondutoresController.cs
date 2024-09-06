using AutoMapper;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloClientes;
using Locadora.Aplicacao.ModuloCondutores;
using Locadora.Dominio.ModuloCondutores;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Controllers
{
    public class CondutoresController : WebControllerBase
    {
    private readonly ServicoCondutores servico;
    private readonly ServicoClientes servicoCliente;
    private readonly IMapper mapeador;

    public CondutoresController(
        ServicoAutenticacao servicoAutenticacao,
        ServicoCondutores servico,
        ServicoClientes servicoCliente,
        IMapper mapeador) : base(servicoAutenticacao)
    {
        this.servico = servico;
        this.servicoCliente = servicoCliente;
        this.mapeador = mapeador;
    }

    public IActionResult Listar()
    {
        var resultado = servico.SelecionarTodos();

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction("Index", "Home");
        }

        var condutores = resultado.Value;

        var listarCondutoresVm = mapeador.Map<IEnumerable<ListarCondutoresViewModel>>(condutores);

        return View(listarCondutoresVm);
    }

    public IActionResult SelecionarClientes()
    {
        var clientesResult = servicoCliente.SelecionarTodos();

        if (clientesResult.IsFailed)
            return RedirectToAction("Index", "Home");

        var clientes = clientesResult.Value;

        var selecionarVm = new SelecionarClientesViewModel()
        {
            Clientes = clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
        };

        return View(selecionarVm);
    }

    [HttpPost]
    public IActionResult SelecionarClientes(SelecionarClientesViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        int clienteId = viewModel.ClienteId;
        bool clienteCondutor = viewModel.ClienteCondutores;

        return RedirectToAction("PreencherCondutor", new { clienteId, clienteCondutor });
    }

    public IActionResult PreencherCondutor(int clienteId, bool clienteCondutor)
    {
        var clienteResult = servicoCliente.SelecionarPorId(clienteId);

        if (clienteResult.IsFailed)
            return RedirectToAction("SelecionarClientes");

        var cliente = clienteResult.Value;

        var viewModel = new FormularioCondutoresViewModel();

        if (clienteCondutor)
        {
            viewModel.ClienteId = clienteId;
            viewModel.ClienteCondutores = clienteCondutor;
            viewModel.Nome = cliente.Nome;
            viewModel.Email = cliente.Email;
            viewModel.Telefone = cliente.Telefone;
            viewModel.Cpf = cliente.NumeroDocumento;
        }

        ViewBag.ClienteSelecionado = cliente.Nome;

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult PreencherCondutor(FormularioCondutoresViewModel inserirVm)
    {
        if (!ModelState.IsValid)
            return View(inserirVm);

        var condutor = mapeador.Map<Condutores>(inserirVm);

        var resultado = servico.Inserir(condutor);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{condutor.Id}] foi inserido com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var condutor = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesCondutoresViewModel>(condutor);

        return View(detalhesVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesCondutoresViewModel detalhesVm)
    {
        var resultado = servico.Excluir(detalhesVm.Id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = servico.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());

            return RedirectToAction(nameof(Listar));
        }

        var condutor = resultado.Value;

        var detalhesVm = mapeador.Map<DetalhesCondutoresViewModel>(condutor);

        return View(detalhesVm);
    }
    }
}
