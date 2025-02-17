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
            IEnumerable<TipoProdutoDTO> tpProduto = await _service.BuscarTpProudo(new TipoProdutoDTO());
            if (tpProduto.Count() == 0 && string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.TpProduto = tpProduto;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(TipoProdutoDTO tipoProdutoDTO)
        {
            ModelState.Remove("TpProduto");
            ModelState.Remove("Descricao");
            IEnumerable<TipoProdutoDTO> ret = await _service.BuscarTpProudo(tipoProdutoDTO);
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_log.Messagem))
            {
                ViewBag.Error = _log.Messagem;
            }
            ViewBag.TpProduto = ret;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CadastrarTpProduto(int? id)
        {
            TipoProdutoDTO tipoProduto = new TipoProdutoDTO();
            if (id != 0 && id != null)
            {
                tipoProduto = await _service.BuscarId((int)id);
            }
            return View(tipoProduto);
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarTpProduto(TipoProdutoDTO tipoProduto)
        {
            string origem = HttpContext.Request.Headers["Referer"].ToString();
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Cliente foi passado sem nenhuma informação";
                return Json(new { succes = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
            if (tipoProduto.id != 0)
            {
                if (await _service.UpdateTpProduto(tipoProduto)) { return Redirect(origem); }
            }
            else
            {
                if (await _service.CadastrarTpProduto(tipoProduto)) { return Redirect(origem); }
            }
            ViewBag.Error = _log.Messagem;
            return Json(new { succes = false, errors = _log.Messagem});


        }
        public async Task<IActionResult> InativarTpProduto(int id)
        {
            if (await _service.InativarTpProduto(id))
            {
                return RedirectToAction("Index", "TpProduto");
            }
            ViewBag.Error = _log.Messagem;
            return RedirectToAction("Index", "TpProduto");

        }
    }
}
