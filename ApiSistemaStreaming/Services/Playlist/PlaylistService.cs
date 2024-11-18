using ApiSistemaStreaming.Data;
using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Services.Playlist
{
    public class PlaylistService : IPlaylistInterface
    {
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public PlaylistService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<PlaylistModel>>> CriarPlaylist(PlaylistCriacaoDto playlistCriacaoDto)
        {
            ResponseModel<List<PlaylistModel>> resposta = new ResponseModel<List<PlaylistModel>>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == playlistCriacaoDto.Usuario.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro de usuario localizado";
                    return resposta;
                }

                var playlist = new PlaylistModel
                {
                    Nome = playlistCriacaoDto.Nome,
                    Usuario = usuario,
                };

                _context.Add(playlist);
                await _context.SaveChangesAsync();


                resposta.Dados = await _context.Playlists.Include(a => a.Usuario).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistModel>>> EditarPlaylist(PlaylistEdicaoDto playlistEdicaoDto)
        {
            ResponseModel<List<PlaylistModel>> resposta = new ResponseModel<List<PlaylistModel>>();

            try
            {
                var playlist = await _context.Playlists.Include(a => a.Usuario).FirstOrDefaultAsync(playlistBanco => playlistBanco.Id == playlistEdicaoDto.Id);

                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == playlistEdicaoDto.Usuario.Id);

                if (playlist == null)
                {
                    resposta.Mensagem = "Playlist não encontrado";
                    return resposta;
                }

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro de usuario localizado";
                    return resposta;
                }

                playlist.Nome = playlistEdicaoDto.Nome;
                playlist.Usuario = usuario;

                _context.Update(playlist);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Playlists.ToListAsync();
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistModel>>> ExcluirPlaylist(int idPlaylist)
        {
            ResponseModel<List<PlaylistModel>> resposta = new ResponseModel<List<PlaylistModel>>();

            try
            {

                var playlist = await _context.Playlists.Include(a => a.Usuario).FirstOrDefaultAsync(playlistBanco => playlistBanco.Id == idPlaylist);

                if (playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizada!";
                    return resposta;
                }

                _context.Remove(playlist);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Playlists.ToListAsync();
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

        public async Task<ResponseModel<List<PlaylistModel>>> ListarPlaylist()
        {
            ResponseModel<List<PlaylistModel>> resposta = new ResponseModel<List<PlaylistModel>>();
            try
            {
                var playlist = await _context.Playlists.Include(a => a.Usuario).ToListAsync();

                resposta.Dados = playlist;
                resposta.Mensagem = "Todos as playlists foram listadas";

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
