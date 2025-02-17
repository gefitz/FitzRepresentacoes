using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitzRepresentacoes.Controllers
{
    public class TpProdutoController : Controller
    {
        private readonly TpProdutoService _service;
        private readonly LogModel _log;

        public TpProdutoController(TpProdutoService service, LogModel log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TipoProdutoDTO> cliente = await _service.BuscarTpProudo(new TipoProdutoDTO());
            if (cliente.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = cliente;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(TipoProdutoDTO tipoProdutoDTO)
        {
            IEnumerable<TipoProdutoDTO> ret = await _service.BuscarTpProudo(tipoProdutoDTO);
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Clientes = ret;
            return View();
        }
        public async Task<IActionResult> Cadastrar(int? id)
        {
            TipoProdutoDTO tipoProduto = new TipoProdutoDTO();
            if (id != 0 && id != null)
            {
                tipoProduto = await _service.BuscarId((int)id);
            }
            return View(tipoProduto);
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(TipoProdutoDTO tipoProduto)
        {
            ModelState.Remove("Pedidos");
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Cliente foi passado sem nenhuma informação";
                return View();
            }
            if (tipoProduto.id != 0)
            {
                if (await _service.UpdateTpProduto(tipoProduto)) { return RedirectToAction("Index", "Cliente"); }
            }
            else
            {
                if (await _service.CadastrarTpProduto(tipoProduto)) { return RedirectToAction("Index", "Cliente"); }
            }
            ViewBag.Error = _log.Messagem;
            return View();

        }
        public async Task<IActionResult> InativarCliente(int id)
        {
            if (await _service.InativarTpProduto(id))
            {
                return RedirectToAction("Index", "Cliente");
            }
            ViewBag.Error = _log.Messagem;
            return RedirectToAction("Index", "Cliente");

        }
    }
}
