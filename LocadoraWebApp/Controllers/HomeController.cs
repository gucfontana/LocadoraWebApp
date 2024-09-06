using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace LocadoraWebApp.Controllers;

[Authorize(Roles = "Empresa,Funcionario")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }

