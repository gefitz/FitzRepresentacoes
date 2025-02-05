using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitzRepresentacoes.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;
        private readonly LogModel _log;

        public ClienteController(ClienteService service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteDTO cliente)
        {
            if (cliente == null)
            {
                ViewBag.Error = "Cliente foi passado sem nenhuma informação";
                return View();
            }
            if(await _service.CadastrarCliente(cliente)) { return View("Index"); }
            ViewBag.Error = _log.Messagem;
            return View();
        }

    }
}
