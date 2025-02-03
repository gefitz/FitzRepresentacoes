using FitzRepresentacoes.Context;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitzRepresentacoes.Repository
{
    public class UsuariosRepository : IDbMethods<UsuarioModel>
    {
        private readonly AppDbContext _context;
        private readonly LogRepository _log;

        public UsuariosRepository(AppDbContext context, LogRepository log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> Create(UsuarioModel usuario)
        {
            try
            {
                var cidade = await _context.Cidades.Where(x => x.id == usuario.Cidade.id).FirstOrDefaultAsync();
                if (cidade != null)
                {
                    usuario.Cidade = cidade;
                }
                var validaSeExisteUsuario = _context.Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefault();
                if(validaSeExisteUsuario != null) { _log.Error("Esse email ja ta cadastrado"); return false; }
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return false;
            }

        }

        public Task<bool> Delete(UsuarioModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioModel>> Filtrar(UsuarioModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UsuarioModel obj)
        {
            throw new NotImplementedException();
        }
        public async Task<UsuarioModel> BuscaDireto(UsuarioModel usuario)
        {
            return await _context.Usuarios.Where(u => u.Email == usuario.Email).FirstAsync();
        }
    }
}
