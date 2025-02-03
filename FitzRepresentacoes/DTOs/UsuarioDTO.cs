using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public CidadeDTO Cidade { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        [DataType(DataType.Date)]
        public DateTime dthNascimento { get; set; }

    }
}
