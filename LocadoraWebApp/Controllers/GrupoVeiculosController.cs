using AutoMapper;
using Locadora.Aplicacao.ModuloAutenticacao;
using Locadora.Aplicacao.ModuloGrupoVeiculos;
using Locadora.Dominio.ModuloGrupoVeiculos;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraWebApp.Controllers
{
    public class GrupoVeiculosController : WebControllerBase
    {
        private readonly ServicoGrupoVeiculos servico;
        private readonly IMapper mapper;

        public GrupoVeiculosController(ServicoAutenticacao servicoAutenticacao,ServicoGrupoVeiculos servico, IMapper mapper) : base(servicoAutenticacao)
        {
            this.servico = servico;
            this.mapper = mapper;
        }

        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var grupos = resultado.Value;

            var listarGrupoVm = mapper.Map<IEnumerable<ListarGrupoVeiculosViewModel>>(grupos);

            return View(listarGrupoVm);
        }

        public IActionResult Inserir()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Inserir(InserirGrupoVeiculosViewModel inserirVm)
        {
            if (!ModelState.IsValid)
            {
                return View(inserirVm);
            }

            var grupo = mapper.Map<GrupoVeiculos>(inserirVm);

            var resultado = servico.Inserir(grupo);


            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());
                return RedirectToAction(nameof ( Listar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi inserido com sucesso!");
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof ( Listar ));
            }

            var grupo = resultado.Value;

            var editarVm = mapper.Map<EditarGrupoVeiculosViewModel>(grupo);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarGrupoVeiculosViewModel editarVm)
        {
            if (!ModelState.IsValid)
            {
                return View(editarVm);
            }

            var grupo = mapper.Map<GrupoVeiculos>(editarVm);

            var resultado = servico.Editar(grupo);


            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());
                return RedirectToAction(nameof ( Editar ));
            }

            ApresentarMensagemSucesso($"O registro ID [{grupo.Id}] foi editado com sucesso!");
            return RedirectToAction(nameof(Editar));
        }

        public IActionResult Excluir(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult()); 
                return RedirectToAction(nameof(Listar));
            }

            var grupo = resultado.Value;

            var detalhesVm = mapper.Map<DetalhesGrupoVeiculosViewModel>(grupo);

            return View(detalhesVm);
        }

        [HttpPost]
        public IActionResult Excluir(DetalhesGrupoVeiculosViewModel detalhesVm)
        {
            var resultado = servico.Excluir(detalhesVm.Id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }
            else
            {
                ApresentarMensagemSucesso($"O registro ID [{detalhesVm.Id}] foi excluído com sucesso!");
                return RedirectToAction(nameof(Listar));
            }
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = servico.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction(nameof(Listar));
            }

            var grupo = resultado.Value;

            var detalhesVm = mapper.Map<DetalhesGrupoVeiculosViewModel>(grupo);

            return View(detalhesVm);
        }
    }
}

