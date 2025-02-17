using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;

namespace FitzRepresentacoes.Services
{
    public class TpProdutoService
    {
        private readonly IDbMethods<TipoProdutoModel> _repository;
        private readonly IMapper _mapper;

        public TpProdutoService(IDbMethods<TipoProdutoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CadastrarTpProduto(TipoProdutoDTO clienteDTO)
        {
            TipoProdutoModel cliente = _mapper.Map<TipoProdutoModel>(clienteDTO);
            if (await _repository.Create(cliente))
                return true;
            return false;

        }
        public async Task<IEnumerable<TipoProdutoDTO>> BuscarTpProudo(TipoProdutoDTO? clienteDTO)
        {
            TipoProdutoModel tipoProduto = new TipoProdutoModel();
            if (clienteDTO != null) { tipoProduto = _mapper.Map<TipoProdutoModel>(clienteDTO); }
            return _mapper.Map<IEnumerable<TipoProdutoDTO>>(await _repository.Filtrar(tipoProduto));
        }
        public async Task<TipoProdutoDTO> BuscarId(int id)
        {
            TipoProdutoModel cliente = new TipoProdutoModel { id = id };
            return _mapper.Map<TipoProdutoDTO>(await _repository.BuscaDireto(cliente));
        }
        public async Task<bool> UpdateTpProduto(TipoProdutoDTO clienteDTO)
        {
            TipoProdutoModel cliente = _mapper.Map<TipoProdutoModel>(clienteDTO);
            return await _repository.Update(cliente);
        }
        public async Task<bool> InativarTpProduto(int id)
        {
            TipoProdutoModel cliente = new TipoProdutoModel() { id = id };
            return await _repository.Delete(cliente);
        }

    }
}
