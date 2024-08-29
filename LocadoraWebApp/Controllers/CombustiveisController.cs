using Locadora.Aplicacao.ModuloCombustiveis;
using Locadora.Dominio.ModuloCombustiveis;
using LocadoraWebApp.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraWebApp.Controllers;

public class CombustiveisController : WebControllerBase
{
    private readonly ServicoCombustiveis servicoCombustiveis;
    
    public CombustiveisController(ServicoCombustiveis servicoCombustiveis)
    {
        this.servicoCombustiveis = servicoCombustiveis;
    }
    
    public async Task<IActionResult> Configurar()
    {
        var resultado = await servicoCombustiveis.ObterConfiguracaoAsync();
        
        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");
        
        Combustiveis configuracaoCombustiveis = resultado.Value;
        
        return View(configuracaoCombustiveis);
    }

    [HttpPost]
    public async Task<IActionResult> Configurar(Combustiveis config)
    {
        var resultado = await servicoCombustiveis.SalvarConfiguracaoAsync(config);

        if (resultado.IsFailed)
            return RedirectToAction("Index", "Home");

        ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

        return RedirectToAction("Index", "Home");
    }
}

