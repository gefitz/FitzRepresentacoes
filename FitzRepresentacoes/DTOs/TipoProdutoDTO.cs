using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class TipoProdutoDTO
    {
        public int id { get; set; }
        public string TpProduto { get; set; }
        public string Descricao { get; set; }
    }
}