using ApiSistemaStreaming.Data;
using ApiSistemaStreaming.Dto.Conteudo;
using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Services.Conteudo
{
    public class ConteudoService : IConteudoInterface
    {
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public ConteudoService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<ConteudoModel>>> CriarConteudo(ConteudoCriacaoDto conteudoCriacaoDto)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {
                var criador = await _context.Criadores.FirstOrDefaultAsync(criadorBanco => criadorBanco.Id == conteudoCriacaoDto.Criador.Id);

                if (criador == null)
                {
                    resposta.Mensagem = "Nenhum registro de criador localizado";
                    return resposta;
                }

                var conteudo = new ConteudoModel
                {
                    Titulo = conteudoCriacaoDto.Titulo,
                    Descricao = conteudoCriacaoDto.Descricao,
                    Criador = criador,
                };

                _context.Add(conteudo);
                await _context.SaveChangesAsync();


                resposta.Dados = await _context.Conteudos.Include(a => a.Criador).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> EditarConteudo(ConteudoEdicaoDto conteudoEdicaoDto)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {
                var conteudo = await _context.Conteudos.Include(a => a.Criador).FirstOrDefaultAsync(conteudoBanco => conteudoBanco.Id == conteudoEdicaoDto.Id);

                var criador = await _context.Criadores.FirstOrDefaultAsync(criadorBanco => criadorBanco.Id == conteudoEdicaoDto.Criador.Id);

                if (conteudo == null)
                {
                    resposta.Mensagem = "Conteudo não encontrado";
                    return resposta;
                }

                if (criador == null)
                {
                    resposta.Mensagem = "Nenhum registro de criador localizado";
                    return resposta;
                }

                conteudo.Titulo = conteudoEdicaoDto.Titulo;
                conteudo.Descricao = conteudoEdicaoDto.Descricao;
                conteudo.Criador = criador;

                _context.Update(conteudo);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Conteudos.ToListAsync();
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> ExcluirConteudo(int idConteudo)
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();

            try
            {

                var conteudo = await _context.Conteudos.Include(a => a.Criador).FirstOrDefaultAsync(conteudoBanco => conteudoBanco.Id == idConteudo);

                if (conteudo == null)
                {
                    resposta.Mensagem = "Nenhum conteudo localizado!";
                    return resposta;
                }

                _context.Remove(conteudo);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Conteudos.ToListAsync();
                resposta.Mensagem = "Playlist Removida com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConteudoModel>>> ListarConteudo()
        {
            ResponseModel<List<ConteudoModel>> resposta = new ResponseModel<List<ConteudoModel>>();
            try
            {
                var conteudo = await _context.Conteudos.Include(a => a.Criador).ToListAsync();

                resposta.Dados = conteudo;
                resposta.Mensagem = "Todos os conteudos foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
