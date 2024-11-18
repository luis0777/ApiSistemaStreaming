using System.Text.Json.Serialization;

namespace ApiSistemaStreaming.Models
{
    public class PlaylistModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioID { get; set; }
        public UsuarioModel Usuario { get; set; }
        [JsonIgnore]
        public ICollection<ItemPlaylistModel> Itens { get; set; }
    }
}
