using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;

namespace ApiSistemaStreaming.Services.Playlist
{
    public interface IPlaylistInterface
    {
        Task<ResponseModel<List<PlaylistModel>>> CriarPlaylist(PlaylistCriacaoDto playlistCriacaoDto);
        Task<ResponseModel<List<PlaylistModel>>> EditarPlaylist(PlaylistEdicaoDto playlistEdicaoDto);
        Task<ResponseModel<List<PlaylistModel>>> ListarPlaylist();
        Task<ResponseModel<List<PlaylistModel>>> ExcluirPlaylist(int idPlaylist);
    }
}
