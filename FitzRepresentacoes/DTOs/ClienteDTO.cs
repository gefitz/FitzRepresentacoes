using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public CidadeDTO Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        [DataType(DataType.Date)]
        public DateTime dthNascimeto { get; set; }
        public List<PedidoDTO> Pedidos { get; set; }
    }
}
