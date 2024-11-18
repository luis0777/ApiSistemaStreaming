using ApiSistemaStreaming.Data;
using ApiSistemaStreaming.Dto.Criador;
using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Services.Criador
{
    public class CriadorService : ICriadorInterface
    {
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public CriadorService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<CriadorModel>>> CriarCriador(CriadorCriacaoDto criadorCriacaoDto)
        {
            ResponseModel<List<CriadorModel>> resposta = new ResponseModel<List<CriadorModel>>();

            try
            {
                var criador = new CriadorModel()
                {
                    Nome = criadorCriacaoDto.Nome,
                };

                _context.Add(criador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Criadores.ToListAsync();
                resposta.Mensagem = "Criador criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CriadorModel>>> EditarCriador(CriadorEdicaoDto criadorEdicaoDto)
        {
            ResponseModel<List<CriadorModel>> resposta = new ResponseModel<List<CriadorModel>>();

            try
            {
                var criador = await _context.Criadores.FirstOrDefaultAsync(criadorBanco => criadorBanco.Id == criadorEdicaoDto.Id);

                if (criador == null)
                {
                    resposta.Mensagem = "Nenhum usuario localizado";
                    return resposta;
                }

                criador.Nome = criadorEdicaoDto.Nome;

                _context.Update(criador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Criadores.ToListAsync();
                resposta.Mensagem = "Alterações feitas com sucesso!!!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CriadorModel>>> ExcluirCriador(int idCriador)
        {
            ResponseModel<List<CriadorModel>> resposta = new ResponseModel<List<CriadorModel>>();

            try
            {
                var criador = await _context.Criadores.FirstOrDefaultAsync(criadorBanco => criadorBanco.Id == idCriador);

                if (criador == null)
                {
                    resposta.Mensagem = "Nenhum criador localizado";
                    return resposta;
                }

                _context.Remove(criador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Criadores.ToListAsync();
                resposta.Mensagem = "Criador removido com sucessso!!!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CriadorModel>>> ListarCriadores()
        {
            ResponseModel<List<CriadorModel>> resposta = new ResponseModel<List<CriadorModel>>();
            try
            {
                var criadores = await _context.Criadores.ToListAsync();

                resposta.Dados = criadores;
                resposta.Mensagem = "Todos os criadores foram listados";

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
