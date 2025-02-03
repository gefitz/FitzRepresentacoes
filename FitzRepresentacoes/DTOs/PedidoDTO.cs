using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class PedidoDTO
    {
        public int id { get; set; }
        public int qtd { get; set; }
        public ClienteDTO Cliente { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public ProdutoDTO Produto { get; set; }
        public short Finalizado { get; set; }
        public DateTime dthPedido { get; set; }
    }
}
