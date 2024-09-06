using AutoMapper;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloClientes;
using Locadora.Dominio.ModuloClientes;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraWebApp.Controllers
{
    public class ClientesController : WebControllerBase
    {
        private readonly ServicoClientes servico;
        private readonly IMapper mapeador;

        public ClientesController(ServicoAutenticacao servicoAutenticacao,ServicoClientes servico, IMapper mapeador) : base(servicoAutenticacao)
        {
            this.servico = servico;
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

            var clientes = resultado.Value;

            var listarTaxasVm = mapeador.Map<IEnumerable<ListarClientesViewModel>>(clientes);

            return View(listarTaxasVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirClientesViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(InserirClientesViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var cliente = mapeador.Map<Clientes>(inserirVm);

            var resultado = servico.Inserir(cliente);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(inserirVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{cliente.Id}] foi inserido com sucesso!");

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Editar(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            var cliente = resultado.Value;

            var editarVm = mapeador.Map<EditarClientesViewModel>(cliente);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarClientesViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var cliente = mapeador.Map<Clientes>(editarVm);

            var resultado = servico.Editar(cliente);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(editarVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{cliente.Id}] foi editado com sucesso!");

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClientesViewModel>(cliente);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesClientesViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O cliente ID [{detalhesVm.Id}] foi excluído com sucesso!");

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            var cliente = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesClientesViewModel>(cliente);

            return View(detalhesVm);
        }
    }
}
