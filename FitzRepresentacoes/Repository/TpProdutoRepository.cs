using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Repository
{
    public class TpProdutoRepository : IDbMethods<TipoProdutoModel>
    {
        private readonly AppDbContext _context;
        private readonly LogRepository _log;
        public TpProdutoRepository(AppDbContext context, LogRepository log)
        {
            _context = context;
            _log = log;
        }

        public async Task<TipoProdutoModel> BuscaDireto(TipoProdutoModel obj)
        {
            try
            {
                return await _context.TpProdutos.Where(tp => tp.id == obj.id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        public async Task<bool> Create(TipoProdutoModel obj)
        {
            try
            {
                _context.TpProdutos.Add(obj);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }

        public async Task<bool> Delete(TipoProdutoModel obj)
        {
            try
            {
                var tpProduto = await BuscaDireto(obj);
                if (tpProduto == null)
                {
                    _log.Error("Usuario não encontrado", false);
                    return false;
                }
                _context.TpProdutos.Remove(tpProduto);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }

        public async Task<IEnumerable<TipoProdutoModel>> Filtrar(TipoProdutoModel obj)
        {
            try
            {
                return await _context.TpProdutos.Where(tp =>
                    (string.IsNullOrEmpty(obj.TpProduto) || tp.TpProduto == obj.TpProduto)
                    ).ToListAsync();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        public async Task<bool> Update(TipoProdutoModel obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }
    }
}
