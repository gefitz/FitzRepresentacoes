using System.ComponentModel.DataAnnotations;

namespace FitzRepresentacoes.Models
{
    public class LogModel
    {
        public int id { get; set; }
        public string Messagem { get; set; }
        public string InnerExecption { get; set; }
        public DateTime dthErro { get; set; }

    }
}
