using AutoMapper;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Aplicacao.ModuloPlanoCobrancas;
using Locadora.Dominio.ModuloPlanoCobrancas;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Controllers
{
    public class PlanoCobrancasController : WebControllerBase
    {
        private readonly ServicoPlanoCobrancas servico;
        private readonly ServicoGrupoVeiculos servicoGrupos;
        private readonly IMapper mapeador;

        public PlanoCobrancasController
        (
            ServicoPlanoCobrancas servico,
            ServicoGrupoVeiculos servicoGrupos,
            IMapper mapeador
        )
        {
            this.servico = servico;
            this.servicoGrupos = servicoGrupos;
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

            var planosCobranca = resultado.Value;

            var listarPlanosVm = mapeador.Map<IEnumerable<ListarPlanoCobrancasViewModel>>(planosCobranca);

            return View(listarPlanosVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirPlanoCobrancasViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var planoCobranca = mapeador.Map<PlanoCobrancas>(inserirVm);

            var resultado = servico.Inserir(planoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi inserido com sucesso!");

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

            var planoCobranca = resultado.Value;

            var editarVm = mapeador.Map<EditarPlanoCobrancasViewModel>(planoCobranca);

            var grupos = servicoGrupos.SelecionarTodos().Value;

            editarVm.GruposVeiculos = grupos
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarVm);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarPlanoCobrancasViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var planoCobranca = mapeador.Map<PlanoCobrancas>(editarVm);

            var resultado = servico.Editar(planoCobranca);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{planoCobranca.Id}] foi editado com sucesso!");

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

            var planoCobranca = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesPlanoCobrancasViewModel>(planoCobranca);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesPlanoCobrancasViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
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

            var planoCobranca = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesPlanoCobrancasViewModel>(planoCobranca);

            return View(detalhesVm);
        }

        private FormularioPlanoCobrancasViewModel ? CarregarDadosFormulario(FormularioPlanoCobrancasViewModel ? dadosPrevios = null)
        {
            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            if (dadosPrevios is null)
            {
                var formularioVm = new FormularioPlanoCobrancasViewModel
                {
                    GruposVeiculos = resultadoGrupos.Value
                        .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };

                return formularioVm;
            }

            dadosPrevios.GruposVeiculos = resultadoGrupos.Value
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}
