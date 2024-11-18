using ApiSistemaStreaming.Dto.ItemPlaylist;
using ApiSistemaStreaming.Dto.ItemPLaylist;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Services.Conteudo;
using ApiSistemaStreaming.Services.Criador;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPlaylistController : Controller
    {
        private readonly IItemPlaylistInterface _itemPlaylistInterface;
        public ItemPlaylistController(IItemPlaylistInterface itemPlaylistInterface)
        {
            _itemPlaylistInterface = itemPlaylistInterface;
        }

        [HttpGet("ListarItemPlaylist")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ListarItemPlaylist()
        {
            var itensPlaylist = await _itemPlaylistInterface.ListarItemPlaylist();
            return Ok(itensPlaylist);
        }

        [HttpPost("CriarItemPlaylist")]
        public async Task<ActionResult<ResponseModel<List<ItemPlaylistModel>>>> CriarItemPlaylist([FromBody] ItemPlaylistCriacaoDto playlistConteudoVinculoDto)
        {
            if (playlistConteudoVinculoDto == null)
                return BadRequest("Dados inválidos");

            var response = await _itemPlaylistInterface.CriarItemPlaylist(playlistConteudoVinculoDto);

            if (response.Dados == null)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
