using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class ProdutoDTO
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public TipoProdutoDTO TpProduto { get; set; }
        public float valor { get; set; }
        public int qtd { get; set; }
        public DateTime dthCriacao { get; set; }
        public DateTime dthAlteracao { get; set; }
    }
}
