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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ObterClientes([FromBody]ClienteDTO clienteDTO)
        {
            IEnumerable<ClienteDTO> ret = await _service.BuscarClientes(clienteDTO);
            if (ret.Count() == 0 && !string.IsNullOrEmpty(_log.Messagem))
            {
                return BadRequest(_log);
            }
            return Ok(ret);
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
        public async Task<IActionResult> Cadastrar([FromBody]ClienteDTO cliente)
        {
            ModelState.Remove("Pedidos");
            if (!ModelState.IsValid)
            {
                _log.Messagem = "Cliente foi passado sem nenhuma informação";
                return BadRequest(_log);
            }
            if (cliente.id != 0)
            {
                if (await _service.UpdateCliente(cliente)) { return Ok(); }
            }
            else
            {
                if (await _service.CadastrarCliente(cliente)) { return Ok(); }
            }
            return BadRequest(_log);

        }
        public async Task<IActionResult> InativarCliente(int id)
        {
            if(await _service.InativarCliente(id))
            {
                return Ok();
            }
            return BadRequest(_log);

        }

    }
}
