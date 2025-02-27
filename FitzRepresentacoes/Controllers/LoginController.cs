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
        private readonly ReturnModel _ret;
        public LoginController(UsuarioService service, ReturnModel ret)
        {
            _service = service;
            _ret = ret;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated) { return RedirectToAction("Index", "Home"); }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO usuario)
        {
            if (usuario.Email == null || usuario.Password == null)
            {
                _ret.Succes = false;
                _ret.Menssagem = "Email ou senha invalidos";
                return Json(_ret);
            }

            if (!await _service.LoginAutenticacao(usuario, HttpContext)) {
                return Json(_ret); 
            }
            _ret.Succes=true;
            return Json(_ret); ;
        }
        public IActionResult LimpaCookies()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}
