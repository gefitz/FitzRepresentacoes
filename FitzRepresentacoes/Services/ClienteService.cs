using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;
using FitzRepresentacoes.Repository.Interfaces;

namespace FitzRepresentacoes.Services
{
    public class ClienteService
    {
        private readonly IDbMethods<ClienteModel> _repository;
        private readonly IMapper _mapper;

        public ClienteService(IDbMethods<ClienteModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CadastrarCliente(ClienteDTO clienteDTO)
        {
            ClienteModel cliente = _mapper.Map<ClienteModel>(clienteDTO);
            if (await _repository.Create(cliente))
                return true;
            return false;

        }
    }
}
