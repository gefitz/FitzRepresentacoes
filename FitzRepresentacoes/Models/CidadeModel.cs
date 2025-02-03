using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.Models
{
    public class CidadeModel
    {
        public int id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }

    }
}
