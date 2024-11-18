using System.Text.Json.Serialization;

namespace ApiSistemaStreaming.Models
{
    public class CriadorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<ConteudoModel> Conteudos { get; set; }
    }
}
