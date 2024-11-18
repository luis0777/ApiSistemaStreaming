using ApiSistemaStreaming.Dto.Criador;
using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;

namespace ApiSistemaStreaming.Services.Criador
{
    public interface ICriadorInterface
    {
        Task<ResponseModel<List<CriadorModel>>> CriarCriador(CriadorCriacaoDto criadorCriacaoDto);
        Task<ResponseModel<List<CriadorModel>>> EditarCriador(CriadorEdicaoDto criadorEdicaoDto);
        Task<ResponseModel<List<CriadorModel>>> ListarCriadores();
        Task<ResponseModel<List<CriadorModel>>> ExcluirCriador(int idCriador);
    }
}
