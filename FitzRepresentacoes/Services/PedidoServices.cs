using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
using FitzRepresentacoes.Repository.Interfaces;

namespace FitzRepresentacoes.Services
{
    public class PedidoServices
    {
        private readonly IDbMethods<PedidoModel> _repository;
        private readonly IMapper _mapper;

        public PedidoServices(IDbMethods<PedidoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarPedido(PedidoDTO pedidoDTO)
        {
            PedidoModel pedido = _mapper.Map<PedidoModel>(pedidoDTO);
            if (await _repository.Create(pedido))
                return true;
            return false;

        }
        public async Task<IEnumerable<PedidoDTO>> BuscarPedidos(PedidoDTO? pedidoDTO)
        {
            PedidoModel pedido = new PedidoModel();
            pedido.Cliente = new ClienteModel();
            pedido.Produto = new ProdutoModel();
            if (pedidoDTO != null) { pedido = _mapper.Map<PedidoModel>(pedidoDTO); }
            return _mapper.Map<IEnumerable<PedidoDTO>>(await _repository.Filtrar(pedido));
        }

    }
}
