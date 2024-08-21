using LocadoraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocadoraWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
