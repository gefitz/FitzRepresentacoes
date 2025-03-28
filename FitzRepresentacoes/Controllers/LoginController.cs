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
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UsuarioDTO usuario)
        {
            if (usuario.Email == null || usuario.Password == null)
            {
                _log.Messagem = "Deve passar Email e a senha para efetuar login";
                return BadRequest(_log);
            }

            if (!await _service.LoginAutenticacao(usuario, HttpContext)) {
                return BadRequest(_log) ; 
            }
            return Ok();
        }
        public IActionResult LimpaCookies()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}
