using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;

namespace FitzRepresentacoes.Services
{
    public class ProdutoService
    {
        private readonly IDbMethods<ProdutoModel> _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IDbMethods<ProdutoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CadastrarProduto(ProdutoDTO produtoDTO)
        {
            ProdutoModel produto = _mapper.Map<ProdutoModel>(produtoDTO);
            if (await _repository.Create(produto))
                return true;
            return false;
        }
        public async Task<IEnumerable<ProdutoDTO>> FiltrarProduto(ProdutoDTO produto)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _repository.Filtrar(_mapper.Map<ProdutoModel>(produto)));
        }
        public async Task<bool> InativarProduto(int id)
        {
            ProdutoModel produto = new ProdutoModel() { id = id};
            produto = await _repository.BuscaDireto(produto);
            if(produto == null) {return false; }
            if(await _repository.Delete(produto)) return true;
            return false;
        }
        public async Task<bool> Update(ProdutoDTO produto)
        {
            if(await _repository.Update(_mapper.Map<ProdutoModel>(produto))) return true;
            return false;
        }
    }
}
