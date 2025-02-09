using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitzRepresentacoes.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _service;
        private readonly LogModel _log;

        public ProdutoController(ProdutoService service, LogModel log)
        {
            _service = service;
            _log = log;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProdutoDTO> produtos = await _service.FiltrarProduto(new ProdutoDTO() { TpProduto = new TipoProdutoDTO() });
            if (produtos.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Produtos = produtos;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProdutoDTO produto)
        {
            IEnumerable<ProdutoDTO> produtos = await _service.FiltrarProduto(produto);
            if (produtos.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.Produtos = produtos;
            return View();
        }
        public IActionResult CadastrarProduto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) { return View(); }
            if (produtoDTO.id == 0)
            {

                if (await _service.CadastrarProduto(produtoDTO))
                {
                    return RedirectToAction("Index","Produto");
                }
            }
            else
            {
                if(await _service.Update(produtoDTO))
                {
                    return RedirectToAction("Index", "Produto");
                }
            }
            ViewBag.Error = _log.Messagem;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            if(await _service.InativarProduto(id))
            {
                return RedirectToAction("Index","Produto");
            }
            ViewBag.Error = _log.Messagem;
            return RedirectToAction("Index","Produto"); 
        }

    }
}
