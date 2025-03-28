using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class ClienteDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Nome e obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome e obrigatorio")]
        [RegularExpression(@"\d+$")]
        public string Documento { get; set; }

        public CidadeDTO Cidade { get; set; }

        [Required(ErrorMessage = "Rua e obrigatorio")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Bairro e obrigatorio")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP e obrigatorio")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Data Nascimento e obrigatorio")]
        [DataType(DataType.Date)]
        [Display(Name ="Data Nascimento")]
        public DateTime dthNascimeto { get; set; }
        public List<PedidoDTO>? Pedidos { get; set; }

        [Required(ErrorMessage = "Email e obrigatorio")]
        [EmailAddress(ErrorMessage ="E-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone e obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:(##)#####-####}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"\d+$")]
        public string Telefone { get; set; }
    }
}
