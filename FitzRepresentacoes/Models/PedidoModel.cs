using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.Models
{
    public class PedidoModel
    {
        public int id { get; set; }
        public int qtd { get; set; }
        public ClienteModel Cliente { get; set; }
        public UsuarioModel Usuario { get; set; }
        public ProdutoModel Produto { get; set; }
        public short Finalizado { get; set; }
        public DateTime dthPedido { get; set; }
    }
}
