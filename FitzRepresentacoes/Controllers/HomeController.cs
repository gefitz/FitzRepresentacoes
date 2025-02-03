using FitzRepresentacoes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FitzRepresentacoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (!Request.Cookies.ContainsKey("token"))
                return RedirectToAction("Index", "Login");
            return View();

        }

    }
}
