using ApiSistemaStreaming.Data;
using ApiSistemaStreaming.Dto.ItemPlaylist;
using ApiSistemaStreaming.Dto.ItemPLaylist;
using ApiSistemaStreaming.Dto.Playlist;
using ApiSistemaStreaming.Dto.Vinculo;
using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Services.Criador
{
    public class ItemPlaylistService : IItemPlaylistInterface
    {
        private readonly AppDbContext _context;

        //recebe o metodo AppDbContext
        public ItemPlaylistService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<ItemPlaylistModel>>> CriarItemPlaylist(ItemPlaylistCriacaoDto itemPlaylistCriacaoDto)
        {
            var response = new ResponseModel<List<ItemPlaylistModel>>();

            try
            {
                // Verifica se a Playlist e o Conteúdo existem no banco de dados.
                var playlist = await _context.Playlists.FindAsync(itemPlaylistCriacaoDto.PlaylistID);
                if (playlist == null)
                {
                    response.Mensagem = "Playlist não encontrada.";
                    return response;
                }

                var conteudo = await _context.Conteudos.FindAsync(itemPlaylistCriacaoDto.ConteudoID);
                if (conteudo == null)
                {
                    response.Mensagem = "Conteúdo não encontrado.";
                    return response;
                }

                // Cria uma nova instância de ItemPlaylistModel
                var itemPlaylist = new ItemPlaylistModel
                {
                    PlaylistID = itemPlaylistCriacaoDto.PlaylistID,
                    ConteudoID = itemPlaylistCriacaoDto.ConteudoID,
                    Playlist = playlist,
                    Conteudo = conteudo
                };

                // Adiciona o item ao DbContext
                _context.ItensPlaylist.Add(itemPlaylist);
                await _context.SaveChangesAsync();

                // Retorna o item criado em uma lista, pois o tipo de retorno é uma lista de itens
                response.Dados = new List<ItemPlaylistModel> { itemPlaylist };
                response.Mensagem = "Item adicionado à playlist com sucesso.";
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao criar item da playlist: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseModel<List<ItemPlaylistModel>>> ListarItemPlaylist()
        {
            ResponseModel<List<ItemPlaylistModel>> resposta = new ResponseModel<List<ItemPlaylistModel>>();
            try
            {
                var itemPlaylist = await _context.ItensPlaylist
                    .Include(ip => ip.Playlist)      // Inclui a entidade Playlist
                    .Include(ip => ip.Conteudo)      // Inclui a entidade Conteudo
                    .ToListAsync();


                resposta.Dados = itemPlaylist;
                resposta.Mensagem = "Todos os itens da playlist foram listados";

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
