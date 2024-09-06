using FluentResults;
using Locadora.Aplicacao.ModuloAutenticacao;
using LocadoraWebApp.Extensions;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraWebApp.Controllers.Compartilhado;

    public abstract class WebControllerBase : Controller
    {
        protected readonly ServicoAutenticacao servicoAuth;

        protected int ? EmpresaId
        {
            get
            {
                var empresaId = servicoAuth.ObterIdEmpresaAsync(User).Result;

                return empresaId;
            }
        }

        protected WebControllerBase(ServicoAutenticacao servicoAuth)
        {
            this.servicoAuth = servicoAuth;
        }

        protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Erro",
                Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
            });

            return RedirectToAction("Index", "Home");
        }

        protected void ApresentarMensagemFalha(Result resultado)
        {
            ViewBag.Mensagem = new MensagemViewModel
            {
                Titulo = "Falha",
                Mensagem = resultado.Errors[0].Message
            };
        }

        protected void ApresentarMensagemSucesso(string mensagem)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = mensagem
            });
        }
    }