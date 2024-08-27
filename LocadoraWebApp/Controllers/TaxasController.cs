using AutoMapper;
using Locadora.Aplicacao.ModuloTaxas;
using Locadora.Dominio.ModuloTaxas;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraWebApp.Controllers
{
    public class TaxasController : WebControllerBase
    {
        private readonly ServicoTaxas servico;
        private readonly IMapper mapeador;

        public TaxasController(ServicoTaxas servico, IMapper mapeador)
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

            var taxas = resultado.Value;

            var listarTaxasVm = mapeador.Map<IEnumerable<ListarTaxasViewModel>>(taxas);

            return View(listarTaxasVm);
        }

        public IActionResult Inserir()
        {
            return View(new InserirTaxasViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(InserirTaxasViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(inserirVm);

            var taxa = mapeador.Map<Taxas>(inserirVm);

            var resultado = servico.Inserir(taxa);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi inserido com sucesso!");

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

            var taxa = resultado.Value;

            var editarVm = mapeador.Map<EditarTaxasViewModel>(taxa);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarTaxasViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var taxa = mapeador.Map<Taxas>(editarVm);

            var resultado = servico.Editar(taxa);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{taxa.Id}] foi editado com sucesso!");

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

            var taxa = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesTaxasViewModel>(taxa);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesTaxasViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return View(detalhesVm);
            }

            ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");

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

            var taxa = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesTaxasViewModel>(taxa);

            return View(detalhesVm);
        }
    }
}