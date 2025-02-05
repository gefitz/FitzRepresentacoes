using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Repository
{
    public class ClienteRepository : IDbMethods<ClienteModel>
    {
        private readonly AppDbContext _context;
        private readonly LogRepository _logRepository;

        public ClienteRepository(AppDbContext context, LogRepository logRepository)
        {
            _context = context;
            _logRepository = logRepository;
        }

        public async Task<ClienteModel> BuscaDireto(ClienteModel obj)
        {
            try
            {
                return await _context.Clientes
                    .Include(c => c.Cidade)
                    .Include(p => p.Pedidos)
                    .ThenInclude(p => p.Produto)
                    .Where(c => c.id == obj.id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return null;
            }
        }

        public async Task<bool> Create(ClienteModel obj)
        {
            try
            {
                var cidade = _context.Cidades.Where(c => c.id == obj.Cidade.id).FirstOrDefault();
                if (cidade != null)
                {
                    obj.Cidade = cidade;
                }
                _context.Clientes.Add(obj);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }
        }

        public async Task<bool> Delete(ClienteModel obj)
        {
            try
            {
                _context.Clientes.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }
        }

        public async Task<IEnumerable<ClienteModel>> Filtrar(ClienteModel obj)
        {
            try
            {

                return await _context.Clientes
                    .Include(c => c.Cidade)
                    .Include(pe => pe.Pedidos)
                        .ThenInclude(p => p.Produto)
                     .Where(c =>
                     (string.IsNullOrEmpty(obj.Nome) || c.Nome == obj.Nome)
                     &&
                     (string.IsNullOrEmpty(obj.Documento) || c.Documento == obj.Documento)
                     &&
                     (obj.Cidade.Cidade == null || c.Cidade.Cidade == obj.Cidade.Cidade)
                     ).ToListAsync();
            }
            catch (Exception ex)
            {
                _logRepository.Error(ex);
                return Enumerable.Empty<ClienteModel>();
            }
        }

        public async Task<bool> Update(ClienteModel obj)
        {
            try
            {
                var cidadeCliente = obj.Cidade;
                if (cidadeCliente.id == 0)
                {
                    var cidade = _context.Cidades.Where(c => c.Cidade.Contains(obj.Cidade.Cidade)).FirstOrDefault();
                    if (cidade == null)
                    {
                        _context.Cidades.Add(cidadeCliente);
                        await _context.SaveChangesAsync();
                        obj.Cidade = cidadeCliente;
                    }
                    else
                    {
                        obj.Cidade = cidade;
                    }
                }
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
