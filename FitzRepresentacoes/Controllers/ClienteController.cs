using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ClienteDTO> cliente = await _service.BuscarClientes(new ClienteDTO() { Cidade = new CidadeDTO() });
            if (cliente.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = cliente;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ClienteDTO clienteDTO)
        {
            IEnumerable<ClienteDTO> ret = await _service.BuscarClientes(clienteDTO);
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = ret;
            return View();
        }
        public async Task<IActionResult> Cadastrar(int? id)
        {
            ClienteDTO cliente = new ClienteDTO();
            if (id != 0 && id != null)
            {
                cliente = await _service.BuscarId((int)id);
            }
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteDTO cliente)
        {
            ModelState.Remove("Pedidos");
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Cliente foi passado sem nenhuma informação";
                return View();
            }
            if (cliente.id != 0)
            {
                if (await _service.UpdateCliente(cliente)) { return RedirectToAction("Index", "Cliente"); }
            }
            else
            {
                if (await _service.CadastrarCliente(cliente)) { return RedirectToAction("Index", "Cliente"); }
            }
            ViewBag.Error = _log.Messagem;
            return View();

        }
        public async Task<IActionResult> InativarCliente(int id)
        {
            if(await _service.InativarCliente(id))
            {
                return RedirectToAction("Index", "Cliente");
            }
            ViewBag.Error = _log.Messagem;
            return RedirectToAction("Index","Cliente");

        }

    }
}
