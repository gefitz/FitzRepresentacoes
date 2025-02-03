using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class CidadeDTO
    {
        public int id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }

    }
}
