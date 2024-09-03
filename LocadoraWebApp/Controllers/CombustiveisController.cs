using AutoMapper;
using Locadora.Aplicacao.ModuloCombustiveis;
using Locadora.Dominio.ModuloCombustiveis;
using LocadoraWebApp.Controllers.Compartilhado;
using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;

public class CombustiveisController : WebControllerBase
{
    private readonly ServicoCombustiveis servicoCombustivel;
    private readonly IMapper mapeador;

    public CombustiveisController(ServicoCombustiveis servicoCombustivel, IMapper mapeador)
    {
        this.servicoCombustivel = servicoCombustivel;
        this.mapeador = mapeador;
    }

    public IActionResult Configurar()
    {
        var resultado = servicoCombustivel.ObterConfiguracao();

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        var configuracaoCombustivel = resultado.Value;

        var formularioVm = mapeador.Map<FormularioCombustiveisViewModel>(configuracaoCombustivel);

        return View(formularioVm);
    }

    [HttpPost]
    public IActionResult Configurar(FormularioCombustiveisViewModel formularioVm)
    {
        var config = mapeador.Map<Combustiveis>(formularioVm);

        var resultado = servicoCombustivel.SalvarConfiguracao(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}
