using ApiSistemaStreaming.Dto.Conteudo;
using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Services.Conteudo;
using ApiSistemaStreaming.Services.Playlist;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudoController : Controller
    {
        private readonly IConteudoInterface _conteudoInterface;
        public ConteudoController(IConteudoInterface conteudoInterface)
        {
            _conteudoInterface = conteudoInterface;
        }

        [HttpGet("ListarConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ListarConteudo()
        {
            var conteudo = await _conteudoInterface.ListarConteudo();
            return Ok(conteudo);
        }

        [HttpPost("CriarConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto)
        {
            var conteudo = await _conteudoInterface.CriarConteudo(conteudoCriacaoDto);
            return Ok(conteudo);
        }

        [HttpPut("EditarConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> EditarConteudo(ConteudoEdicaoDto conteudoEdicaoDto)
        {
            var conteudo = await _conteudoInterface.EditarConteudo(conteudoEdicaoDto);
            return Ok(conteudo);
        }

        [HttpDelete("ExcluirConteudo")]
        public async Task<ActionResult<ResponseModel<List<ConteudoModel>>>> ExcluirConteudo(int idConteudo)
        {
            var conteudo = await _conteudoInterface.ExcluirConteudo(idConteudo);
            return Ok(conteudo);
        }
    }
}
