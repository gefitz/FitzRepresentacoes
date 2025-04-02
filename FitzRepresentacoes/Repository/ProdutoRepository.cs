using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Repository
{
    public class ProdutoRepository : IDbMethods<ProdutoModel>
    {
        private readonly AppDbContext _context;
        private readonly LogRepository _logRepository;

        public ProdutoRepository(AppDbContext context, LogRepository logRepository)
        {
            _context = context;
            _logRepository = logRepository;
        }

        public async Task<ProdutoModel> BuscaDireto(ProdutoModel obj)
        {

            try
            {

                var produto = await _context.Produtos.Include(tp => tp.id == obj.TpProduto.id).Where(p => p.id == obj.id).FirstOrDefaultAsync();
                if(produto != null)
                {
                    return produto;
                }
                _logRepository.Error("Nenhum produto encontrado com esse id",false);
                return null;
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return null;
            }
        }

        public async Task<bool> Create(ProdutoModel obj)
        {
            try
            {
                var tpProduto = await _context.TpProdutos.Where(tp => tp.id == obj.TpProduto.id).FirstOrDefaultAsync();
                if (tpProduto != null)
                {
                    obj.TpProduto = tpProduto;
                }
                _context.Produtos.Add(obj);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }
        }

        public async Task<bool> Delete(ProdutoModel obj)
        {
            try
            {
                _context.Produtos.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }
        }

        public async Task<IEnumerable<ProdutoModel>> Filtrar(ProdutoModel obj)
        {
            try
            {

                return await _context.Produtos.Include(tp => tp.id)
                    .Where(p =>
                        (string.IsNullOrEmpty(obj.Nome) || p.Nome.Contains(obj.Nome))
                        &&
                        (string.IsNullOrEmpty(obj.Descricao) || p.Descricao.Contains(obj.Descricao))
                        &&
                        (string.IsNullOrEmpty(obj.TpProduto.Tipo) || p.TpProduto.Tipo.Contains(obj.TpProduto.Tipo))
                    ).ToListAsync();
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return null;
            }
        }

        public async Task<bool> Update(ProdutoModel obj)
        {
            try
            {
                var tp = await _context.TpProdutos.Where(tp => tp.id == obj.TpProduto.id).FirstOrDefaultAsync();
                if (tp != null)
                    obj.TpProduto = tp;
                _context.Produtos.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }

        }
    }
}
