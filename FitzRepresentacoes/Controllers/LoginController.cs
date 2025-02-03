using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
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
        public IActionResult Index()
        {
            ViewBag.Error = _log.Messagem;
            var cookie = Request.Cookies["token"];
            if (Request.Cookies.ContainsKey("token"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Login(UsuarioDTO usuario)
        {
            if (usuario.Email == null || usuario.Password == null) { return BadRequest("Email e senha deve ser inseridos"); }

            var token = await _service.LoginAutenticacao(usuario);
            if (string.IsNullOrEmpty(token)) { ViewBag.Error = _log.Messagem ; return View("Index"); }
            SalvarCookie("token", token);
            Thread.Sleep(1000);
            return RedirectToAction("Index", "Login");
        }
        public IActionResult LimpaCookies()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("Index","Login");
        }
        private void SalvarCookie(string nomeCookie, string valor)
        {
            CookieOptions cookieOptions = new CookieOptions()
            {
                HttpOnly = true, // Protege contra ataques XSS
                Expires = DateTime.UtcNow.AddHours(1), // Tempo de expiração
                Secure = false
            };

            Response.Cookies.Append("token", valor, cookieOptions);


        }

    }
}
