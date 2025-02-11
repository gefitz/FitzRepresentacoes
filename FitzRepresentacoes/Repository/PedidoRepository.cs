using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Repository
{
    public class PedidoRepository : IDbMethods<PedidoModel>
    {
        private readonly AppDbContext _context;
        private readonly LogRepository _log;
        private readonly IDbMethods<ClienteModel> _cliente;
        private readonly IDbMethods<ProdutoModel> _produto;

        public PedidoRepository(AppDbContext context, LogRepository log, IDbMethods<ClienteModel> cliente, IDbMethods<ProdutoModel> produto)
        {
            _context = context;
            _log = log;
            _cliente = cliente;
            _produto = produto;
        }

        public Task<PedidoModel> BuscaDireto(PedidoModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(PedidoModel obj)
        {
            try
            {
                var cliente = await _cliente.BuscaDireto(obj.Cliente);
                var produto = await _produto.BuscaDireto(obj.Produto);
                if(cliente == null) { _log.Error("Cliente não encontrado",false); return false; }
                if(produto == null) { _log.Error("Produto não foi selecionado",false); return false; }
                obj.Cliente = cliente;
                obj.Produto = produto;
                _context.Pedidos.Add(obj);
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }
        }

        public Task<bool> Delete(PedidoModel obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PedidoModel>> Filtrar(PedidoModel obj)
        {
            try
            {
                return await _context.Pedidos
                    .Include(p => p.Produto).ThenInclude(tp => tp.TpProduto)
                    .Include(c => c.Cliente).ThenInclude(c => c.Cidade)
                    .Where(pe =>
                    (string.IsNullOrEmpty(obj.Produto.Nome) || pe.Produto.Nome == obj.Produto.Nome)
                    &&
                    (string.IsNullOrEmpty(obj.Cliente.Nome) || pe.Cliente.Nome == obj.Cliente.Nome)
                    ).ToListAsync();
            }catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        public Task<bool> Update(PedidoModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
