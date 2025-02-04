using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FitzRepresentacoes.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _service;
        private readonly LogModel _log;
        public LoginController(UsuarioService service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated) { return RedirectToAction("Index", "Home"); }
            return View();
        }
        public async Task<IActionResult> Login(UsuarioDTO usuario)
        {
            if (usuario.Email == null || usuario.Password == null) { return BadRequest("Email e senha deve ser inseridos"); }

            if (!await _service.LoginAutenticacao(usuario, HttpContext)) { ViewBag.Error = _log.Messagem ; return View("Index"); }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LimpaCookies()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}
