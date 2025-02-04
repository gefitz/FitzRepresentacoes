using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Nome necessario")]
        public string Nome { get; set; }
       
        [Required(ErrorMessage = "Documento necessario")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Email necessario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha necessario")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Cidade necessario")]

        public CidadeDTO Cidade { get; set; }
        [Required(ErrorMessage = "CEP necessario")]

        public string CEP { get; set; }
        [Required(ErrorMessage = "Rua necessario")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Data de Nascimento necessario")]
        [DataType(DataType.Date)]
        [Display(Name ="Data de Nascimento")]
        public DateTime? dthNascimento { get; set; }

    }
}
