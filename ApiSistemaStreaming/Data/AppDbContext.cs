using ApiSistemaStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaStreaming.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PlaylistModel> Playlists { get; set; }
        public DbSet<ConteudoModel> Conteudos { get; set; }
        public DbSet<CriadorModel> Criadores { get; set; }
        public DbSet<ItemPlaylistModel> ItensPlaylist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definindo a chave composta para a entidade ItemPlaylist
            modelBuilder.Entity<ItemPlaylistModel>()
                .HasKey(ip => new { ip.PlaylistID, ip.ConteudoID });

            modelBuilder.Entity<ItemPlaylistModel>()
                .HasOne(ip => ip.Playlist)
                .WithMany(p => p.Itens)
                .HasForeignKey(ip => ip.PlaylistID);

            modelBuilder.Entity<ItemPlaylistModel>()
                .HasOne(ip => ip.Conteudo)
                .WithMany(c => c.ItensPlaylist)
                .HasForeignKey(ip => ip.ConteudoID);
        }
    }
}
