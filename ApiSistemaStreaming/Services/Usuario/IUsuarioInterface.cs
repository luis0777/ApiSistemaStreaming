using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;

namespace ApiSistemaStreaming.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<ResponseModel<List<UsuarioModel>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto);
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<List<UsuarioModel>>> ExcluirUsuario(int idUsuario);
    }
}
