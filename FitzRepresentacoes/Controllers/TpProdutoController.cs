using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitzRepresentacoes.Controllers
{
    public class TpProdutoController : Controller
    {
        private readonly TpProdutoService _service;
        private readonly ReturnModel _ret;

        public TpProdutoController(TpProdutoService service, ReturnModel ret)
        {
            _service = service;
            _ret = ret;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TipoProdutoDTO> tpProduto = await _service.BuscarTpProudo(new TipoProdutoDTO());
            if (tpProduto.Count() == 0 && !string.IsNullOrEmpty(_ret.Menssagem))
            {
                return Json(_ret);
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
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_ret.Menssagem))
            {
                return Json(_ret);
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
                return Json(_ret);
            }
            if (tipoProduto.id != 0)
            {
                if (await _service.UpdateTpProduto(tipoProduto)) { return Redirect(origem); }
            }
            else
            {
                if (await _service.CadastrarTpProduto(tipoProduto)) { return Redirect(origem); }
            }
            return Json(_ret);


        }
        public async Task<IActionResult> InativarTpProduto(int id)
        {
            if (await _service.InativarTpProduto(id))
            {
                return RedirectToAction("Index", "TpProduto");
            }
            //ViewBag.Error = _log.Messagem;
            return RedirectToAction("Index", "TpProduto");

        }
    }
}
