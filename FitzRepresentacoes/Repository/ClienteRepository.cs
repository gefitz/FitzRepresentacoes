using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;

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

        public Task<ClienteModel> BuscaDireto(ClienteModel obj)
        {
            throw new NotImplementedException();
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

            }catch (Exception ex)
            {
                _logRepository.Error(ex);
                return false;
            }
        }

        public Task<bool> Delete(ClienteModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteModel>> Filtrar(ClienteModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ClienteModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
