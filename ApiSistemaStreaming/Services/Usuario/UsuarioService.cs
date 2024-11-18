using ApiSistemaStreaming.Data;
using ApiSistemaStreaming.Dto.Usuario;
using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public UsuarioService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<ResponseModel<List<UsuarioModel>>> CriarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = usuarioCriacaoDto.Nome,
                    Email = usuarioCriacaoDto.Email
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuario criado com sucesso!!!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async  Task<ResponseModel<List<UsuarioModel>>> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == usuarioEdicaoDto.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuario localizado";
                    return resposta;
                }

                usuario.Nome = usuarioEdicaoDto.Nome;
                usuario.Email = usuarioEdicaoDto.Email;

                _context.Update(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
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

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Todos os usuarios foram listados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ExcluirUsuario(int idUsuario)
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuario localizado";
                    return resposta;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Usuarios.ToListAsync();
                resposta.Mensagem = "Usuario removido com sucessso!!!";

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
