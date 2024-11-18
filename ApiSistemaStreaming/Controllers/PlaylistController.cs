using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Services.Playlist;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistInterface _playlistInterface;
        public PlaylistController(IPlaylistInterface playlistInterface)
        {
            _playlistInterface = playlistInterface;
        }

        [HttpGet("ListarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistModel>>>> ListarPlaylist()
        {
            var playlist = await _playlistInterface.ListarPlaylist();
            return Ok(playlist);
        }

        [HttpPost("CriarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistModel>>>> CriarPlaylist(PlaylistCriacaoDto playlistCriacaoDto)
        {
            var playlist = await _playlistInterface.CriarPlaylist(playlistCriacaoDto);
            return Ok(playlist);
        }

        [HttpPut("EditarPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistModel>>>> EditarPlaylist(PlaylistEdicaoDto playlistEdicaoDto)
        {
            var playlist = await _playlistInterface.EditarPlaylist(playlistEdicaoDto);
            return Ok(playlist);
        }

        [HttpDelete("ExcluirPlaylist")]
        public async Task<ActionResult<ResponseModel<List<PlaylistModel>>>> ExcluirPlaylist(int idPlaylist)
        {
            var playlist = await _playlistInterface.ExcluirPlaylist(idPlaylist);
            return Ok(playlist);
        }
    }
}
