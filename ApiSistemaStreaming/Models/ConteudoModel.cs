using System.Text.Json.Serialization;

namespace ApiSistemaStreaming.Models
{
    public class ConteudoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CriadorID { get; set; }
        public CriadorModel Criador { get; set; }
        [JsonIgnore]    
        public ICollection<ItemPlaylistModel> ItensPlaylist { get; set; }
    }
}
