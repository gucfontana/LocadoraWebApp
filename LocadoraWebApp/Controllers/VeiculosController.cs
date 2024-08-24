using AutoMapper;
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
        // Injeção de dependência
        private readonly ServicoVeiculos servico;
        private readonly ServicoGrupoVeiculos servicoGrupos;
        private readonly IMapper mapper;

        // Construtor
        public VeiculosController(ServicoGrupoVeiculos servicoGrupos, ServicoVeiculos servico, IMapper mapper)
        {
            this.servico = servico;
            this.servicoGrupos = servicoGrupos;
            this.mapper = mapper;
        }

        // Métodos
        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var veiculos = resultado.Value;

            var listarVeiculosVm = mapper.Map<IEnumerable<ListarVeiculosViewModel>>(veiculos);

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

            var veiculo = mapper.Map<Veiculos>(inserirVm);

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

            var editarVm = mapper.Map<EditarVeiculosViewModel>(veiculo);

            var gruposDisponiveis = resultadoGrupos.Value;

            editarVm.GrupoVeiculos = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarVeiculosViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(CarregarDadosFormulario(editarVm));

            var veiculo = mapper.Map<Veiculos>(editarVm);

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

            var detalhesVm = mapper.Map<DetalhesVeiculosViewModel>(veiculo);

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

            var detalhesVm = mapper.Map<DetalhesVeiculosViewModel>(veiculo);

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

var veiculos = resultado.Value;

            return File(veiculos.Fotos, "image/jpeg");
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
            {
                var formularioVm = new FormularioVeiculosViewModel()
                {
                    GrupoVeiculos = gruposDisponiveis
                        .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };

                return formularioVm;
            }

            dadosPrevios.GrupoVeiculos = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}