using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository;
using FitzRepresentacoes.Repository.Interfaces;

namespace FitzRepresentacoes.Services
{
    public class UsuarioService
    {
        private readonly IDbMethods<UsuarioModel> _repository;
        private readonly IMapper _mapper;
        private readonly LoginService _login;

        public UsuarioService(UsuariosRepository repository, IMapper mapper, LoginService login)
        {
            _repository = repository;
            _mapper = mapper;
            _login = login;
        }
        public async Task<bool> CriarUsuario(UsuarioDTO dTO)
        {
            UsuarioModel usuario = _mapper.Map<UsuarioModel>(dTO);
            Dictionary<string, byte[]> hashSalt = _login.CriptografiaSenha(dTO.Password);
            if(hashSalt.Count == 0) { return false; }
            usuario.Salt = hashSalt["salt"];
            usuario.Hash = hashSalt["hash"];
            return await _repository.Create(usuario);

        }
        public async Task<string> LoginAutenticacao(UsuarioDTO usuarioDTO)
        {
            var retornoUsuario = await _repository.BuscaDireto(_mapper.Map<UsuarioModel>(usuarioDTO));
            if (retornoUsuario == null) { return null; }
            if (!await _login.ValidaSenha(retornoUsuario, usuarioDTO.Password)) { return null; }
            return _login.GerarToken(retornoUsuario);
            
        }
    }
}
