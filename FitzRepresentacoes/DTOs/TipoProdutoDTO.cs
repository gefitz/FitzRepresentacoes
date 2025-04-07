using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class TipoProdutoDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Necessario o Tipo do Produto")]
        [Display(Name ="Tipo de Produto")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Necessario a Descrição do Tipo")]
        [Display(Name = "Descrição do Tipo")]
        public string Descricao { get; set; }
    }
}