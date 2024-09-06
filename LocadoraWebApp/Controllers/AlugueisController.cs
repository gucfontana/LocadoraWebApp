using AutoMapper;
using Locadora.Aplicacao.ModuloAlugueis;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloCondutores;
using Locadora.Aplicacao.ModuloTaxas;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.ModuloAlugueis;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace LocadoraWebApp.Controllers
{
    public class AlugueisController : WebControllerBase
    {
        private readonly ServicoAlugueis servicoLocacao;
        private readonly ServicoVeiculos servicoVeiculo;
        private readonly ServicoCondutores servicoCondutor;
        private readonly ServicoTaxas servicoTaxa;
        private readonly IMapper mapeador;

        public AlugueisController
        (
            ServicoAutenticacao servicoAutenticacao,
            ServicoAlugueis servicoLocacao,
            ServicoVeiculos servicoVeiculo,
            ServicoCondutores servicoCondutor,
            ServicoTaxas servicoTaxa,
            IMapper mapeador
        ) : base(servicoAutenticacao)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoCondutor = servicoCondutor;
            this.servicoTaxa = servicoTaxa;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var locacoes = resultado.Value;

            var listarLocacoesVm = mapeador.Map<IEnumerable<ListarLocacaoViewModel>>(locacoes);

            return View(listarLocacoesVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirLocacaoViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var locacao = mapeador.Map<Alugueis>(inserirVm);

            var confirmarVm = mapeador.Map<ConfirmarAberturaLocacaoViewModel>(locacao);

            TempData["LocacaoParaInsercao"] = JsonConvert.SerializeObject(confirmarVm);

            return RedirectToAction("ConfirmarAbertura");
        }

        public IActionResult ConfirmarAbertura()
        {
            if (TempData["LocacaoParaInsercao"] is null)
                return RedirectToAction(nameof ( Inserir ));

            var locacaoDataJson = TempData["LocacaoParaInsercao"]!.ToString();

            var confirmarVm = JsonConvert.DeserializeObject<ConfirmarAberturaLocacaoViewModel>(locacaoDataJson);

            return View(confirmarVm);
        }

        [HttpPost]
        public IActionResult ConfirmarAbertura(ConfirmarAberturaLocacaoViewModel confirmarVm)
        {
            var locacao = mapeador.Map<Alugueis>(confirmarVm);

            var resultado = servicoLocacao.Inserir(locacao);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"A locação ID [{locacao.Id}] foi aberta com sucesso!");

            return RedirectToAction(nameof ( Listar ));
        }

        public IActionResult RealizarDevolucao(int id)
        {
            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            var locacao = resultado.Value;

            var devolucaoVm = mapeador.Map<RealizarDevolucaoViewModel>(locacao);

            return View(devolucaoVm);
        }

        [HttpPost]
        public IActionResult RealizarDevolucao(RealizarDevolucaoViewModel devolucaoVm)
        {
            var locacao = mapeador.Map<Alugueis>(devolucaoVm);

            var confirmarVm = mapeador.Map<ConfirmarDevolucaoLocacaoViewModel>(locacao);

            TempData["LocacaoParaInsercao"] = JsonConvert.SerializeObject(confirmarVm);

            return RedirectToAction("ConfirmarDevolucao");

        }

        public IActionResult ConfirmarDevolucao()
        {
            if (TempData["LocacaoParaDevolucao"] is null)
                return RedirectToAction(nameof ( Listar ));

            var locacaoDataJson = TempData["LocacaoParaDevolucao"]!.ToString();

            var confirmarVm = JsonConvert.DeserializeObject<ConfirmarDevolucaoLocacaoViewModel>(locacaoDataJson);

            return View(confirmarVm);
        }

        [HttpPost]
        public IActionResult ConfirmarDevolucao(ConfirmarDevolucaoLocacaoViewModel confirmarVm)
        {
            var locacaoOriginal = servicoLocacao.SelecionarPorId(confirmarVm.Id).Value;

            var locacaoAtualizada = mapeador.Map<ConfirmarDevolucaoLocacaoViewModel, Alugueis>(confirmarVm, locacaoOriginal);

            var resultado = servicoLocacao.RealizarDevolucao(locacaoAtualizada);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"A locação ID [{locacaoAtualizada.Id}] foi concluída com sucesso!");

            return RedirectToAction(nameof ( Listar ));
        }

        private InserirLocacaoViewModel CarregarDadosFormulario(InserirLocacaoViewModel ? formularioVm = null)
        {
            var condutores = servicoCondutor.SelecionarTodos().Value;
            var veiculos = servicoVeiculo.SelecionarTodos().Value;
            var taxas = servicoTaxa.SelecionarTodos().Value;

            if (formularioVm is null)
                formularioVm = new InserirLocacaoViewModel();

            formularioVm.Condutores =
                condutores.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

            formularioVm.Veiculos =
                veiculos.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

            formularioVm.Taxas =
                taxas.Select(c => new SelectListItem(c.ToString(), c.Id.ToString()));

            return formularioVm;
        }
    }
}
