using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class CidadeDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Cidade e obrigatorio")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado e obrigatorio")]

        public string Estado { get; set; }
        [Required(ErrorMessage = "Sigla e obrigatorio")]

        public string Sigla { get; set; }

    }
}
