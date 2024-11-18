using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;
using ApiSistemaStreaming.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);

        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(usuarioCriacaoDto);
            return Ok(usuarios);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var usuarios = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
            return Ok(usuarios);
        }

        [HttpDelete("ExcluirUsuario")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ExcluirUsuario(int idUsuario)
        {
            var usuarios = await _usuarioInterface.ExcluirUsuario(idUsuario);
            return Ok(usuarios);
        }
    }
}
