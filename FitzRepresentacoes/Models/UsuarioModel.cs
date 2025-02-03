using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public CidadeModel Cidade { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        [DataType(DataType.Date)]
        public DateTime dthNascimento { get; set; }

    }
}
