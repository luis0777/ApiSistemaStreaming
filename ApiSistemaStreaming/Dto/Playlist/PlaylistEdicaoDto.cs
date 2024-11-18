using ApiSistemaStreaming.Dto.Vinculo;

namespace ApiSistemaStreaming.Dto.Playlist
{
    public class PlaylistEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UsuarioVinculoDto Usuario { get; set; }
    }
}
