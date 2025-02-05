using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitzRepresentacoes.Controllers
{
    public class UsuarioController:Controller
    {
        private readonly UsuarioService _service;
        private readonly LogModel _log;

        public UsuarioController(UsuarioService service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        [HttpGet]
        public async Task<IActionResult> CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroUsuario(UsuarioDTO usuarioDTO)
        {
            if(!ModelState.IsValid) { ViewBag.Error = "Não foi passado usuario para o cadastro";  return View(); }
            if (await _service.CriarUsuario(usuarioDTO)) 
            {
                return RedirectToAction("Index","Login"); 
            }
            ViewBag.Error = _log.Messagem;
            return View();

        }
    }
}
