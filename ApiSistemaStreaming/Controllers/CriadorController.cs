using ApiSistemaStreaming.Dto.Criador;
using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Services.Criador;
using ApiSistemaStreaming.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriadorController : Controller
    {
        private readonly ICriadorInterface _criadorInterface;
        public CriadorController(ICriadorInterface criadorInterface)
        {
            _criadorInterface = criadorInterface;
        }

        [HttpGet("ListarCriadores")]
        public async Task<ActionResult<ResponseModel<List<CriadorModel>>>> ListarCriadores()
        {
            var criadores = await _criadorInterface.ListarCriadores();
            return Ok(criadores);

        }

        [HttpPost("CriarCriador")]
        public async Task<ActionResult<ResponseModel<List<CriadorModel>>>> CriarCriador(CriadorCriacaoDto criadorCriacaoDto)
        {
            var criadores = await _criadorInterface.CriarCriador(criadorCriacaoDto);
            return Ok(criadores);
        }

        [HttpPut("EditarCriador")]
        public async Task<ActionResult<ResponseModel<List<CriadorModel>>>> EditarCriador(CriadorEdicaoDto criadorEdicaoDto)
        {
            var criadores = await _criadorInterface.EditarCriador(criadorEdicaoDto);
            return Ok(criadores);
        }

        [HttpDelete("ExcluirCriador")]
        public async Task<ActionResult<ResponseModel<List<CriadorModel>>>> ExcluirCriador(int idCriador)
        {
            var criadores = await _criadorInterface.ExcluirCriador(idCriador);
            return Ok(criadores);
        }
    }
}
