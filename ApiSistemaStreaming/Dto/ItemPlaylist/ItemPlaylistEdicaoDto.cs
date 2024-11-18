namespace ApiSistemaStreaming.Dto.ItemPlaylist
{
    public class ItemPlaylistEdicaoDto
    {
        public int Id { get; set; } // ID da playlist a ser editada
        public int UsuarioId { get; set; } // ID do usuário vinculado
        public string Nome { get; set; } // Nome da playlist
    }
}
