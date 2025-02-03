using AutoMapper;
using FitzRepresentacoes.DTOs;
using FitzRepresentacoes.Models;

namespace FitzRepresentacoes.DTOs.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<UsuarioDTO,UsuarioModel>().ReverseMap();
            CreateMap<ClienteDTO,ClienteModel>().ReverseMap();
            CreateMap<PedidoDTO,PedidoModel>().ReverseMap();
            CreateMap<ProdutoDTO,ProdutoModel>().ReverseMap();
            CreateMap<CidadeDTO,CidadeModel>().ReverseMap();
            CreateMap<TipoProdutoDTO,TipoProdutoModel>().ReverseMap();
        }
    }
}
