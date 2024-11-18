namespace ApiSistemaStreaming.Models
{
    public class ItemPlaylistModel
    {
        public int PlaylistID { get; set; }
        public PlaylistModel Playlist { get; set; }
        public int ConteudoID { get; set; }
        public ConteudoModel Conteudo { get; set; }
    }
}
