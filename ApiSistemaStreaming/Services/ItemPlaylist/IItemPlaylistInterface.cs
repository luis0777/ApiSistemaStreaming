using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Dto.ItemPLaylist;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Dto.ItemPlaylist;

namespace ApiSistemaStreaming.Services.Criador
{
    public interface IItemPlaylistInterface
    {
        Task<ResponseModel<List<ItemPlaylistModel>>> ListarItemPlaylist();
        Task<ResponseModel<List<ItemPlaylistModel>>> CriarItemPlaylist(ItemPlaylistCriacaoDto playlistConteudoVinculoDto);
    }
}
