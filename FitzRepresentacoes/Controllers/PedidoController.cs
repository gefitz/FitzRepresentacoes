using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
using Microsoft.AspNetCore.Mvc;
using FitzRepresentacoes.Services;
using FitzRepresentacoes.DTOs;

namespace FitzRepresentacoes.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoServices _service;
        private readonly LogModel _log;

        public PedidoController(PedidoServices service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PedidoDTO> cliente = await _service.BuscarPedidos(new PedidoDTO());
            if (cliente.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = cliente;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(PedidoDTO pedidoDTO)
        {
            IEnumerable<PedidoDTO> ret = await _service.BuscarPedidos(pedidoDTO);
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = ret;
            return View();
        }
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(PedidoDTO pedido)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Pedido foi passado sem nenhuma informação";
                return View();
            }
            if (await _service.CadastrarPedido(pedido)) { return RedirectToAction("Index", "Cliente"); }
            
            ViewBag.Error = _log.Messagem;
            return View();

        }

    }
}
