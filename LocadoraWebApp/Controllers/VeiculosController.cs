using AutoMapper;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Aplicacao.ModuloVeiculos;
using Locadora.Dominio.ModuloVeiculos;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraWebApp.Controllers
{
    public class VeiculosController : WebControllerBase
    {
        private readonly ServicoVeiculos servico;
        private readonly ServicoGrupoVeiculos servicoGrupos;
        private readonly IMapper mapeador;

        public VeiculosController
        (
            ServicoAutenticacao servicoAutenticacao,
            ServicoVeiculos servico,
            ServicoGrupoVeiculos servicoGrupos,
            IMapper mapeador
        ) : base(servicoAutenticacao)
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

            var veiculos = resultado.Value;

            var listarVeiculosVm = mapeador.Map<IEnumerable<ListarVeiculosViewModel>>(veiculos);

            return View(listarVeiculosVm);
        }

        public IActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        [HttpPost]
        public IActionResult Inserir(InserirVeiculosViewModel inserirVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(inserirVm));

            var veiculo = mapeador.Map<Veiculos>(inserirVm);

            var resultado = servico.Inserir(veiculo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi inserido com sucesso!");

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

            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            var veiculo = resultado.Value;

            var editarVm = mapeador.Map<EditarVeiculosViewModel>(veiculo);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarVeiculosViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var veiculo = mapeador.Map<Veiculos>(editarVm);

            var resultado = servico.Editar(veiculo);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{veiculo.Id}] foi editado com sucesso!");

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

            var veiculo = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesVeiculosViewModel>(veiculo);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesVeiculosViewModel detalhesVm)
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

            var veiculo = resultado.Value;

            var detalhesVm = mapeador.Map<DetalhesVeiculosViewModel>(veiculo);

            return View(detalhesVm);
        }

        public IActionResult ObterFotos(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return NotFound();
            }

            var veiculo = resultado.Value;

            return File(veiculo.Fotos, "image/jpeg");
        }

        private FormularioVeiculosViewModel ? CarregarDadosFormulario
        (
            FormularioVeiculosViewModel ? dadosPrevios = null
        )
        {
            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());

                return null;
            }

            var gruposDisponiveis = resultadoGrupos.Value;

            if (dadosPrevios is null)
                dadosPrevios = new FormularioVeiculosViewModel();

            dadosPrevios.GrupoVeiculos = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}