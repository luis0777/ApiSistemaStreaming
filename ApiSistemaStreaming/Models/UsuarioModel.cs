using System.Text.Json.Serialization;

namespace ApiSistemaStreaming.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<PlaylistModel> Playlists { get; set; }
    }
}
