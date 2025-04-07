using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.Models
{
    public class TipoProdutoModel
    {
        public int id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}