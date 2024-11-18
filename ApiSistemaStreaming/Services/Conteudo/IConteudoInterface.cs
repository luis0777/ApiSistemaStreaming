using ApiSistemaStreaming.Dto.Conteudo;
using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;

namespace ApiSistemaStreaming.Services.Conteudo
{
    public interface IConteudoInterface
    {
        Task<ResponseModel<List<ConteudoModel>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto);
        Task<ResponseModel<List<ConteudoModel>>> EditarConteudo(ConteudoEdicaoDto conteudoEdicaoDto);
        Task<ResponseModel<List<ConteudoModel>>> ListarConteudo();
        Task<ResponseModel<List<ConteudoModel>>> ExcluirConteudo(int idConteudo);
    }
}
