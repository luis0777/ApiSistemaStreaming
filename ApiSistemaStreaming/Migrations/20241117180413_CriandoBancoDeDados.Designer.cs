﻿// <auto-generated />
using ApiSistemaStreaming.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSistemaStreaming.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241117180413_CriandoBancoDeDados")]
    partial class CriandoBancoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiSistemaStreaming.Models.ConteudoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CriadorID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CriadorID");

                    b.ToTable("Conteudos");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.CriadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Criadores");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.ItemPlaylistModel", b =>
                {
                    b.Property<int>("PlaylistID")
                        .HasColumnType("int");

                    b.Property<int>("ConteudoID")
                        .HasColumnType("int");

                    b.HasKey("PlaylistID", "ConteudoID");

                    b.HasIndex("ConteudoID");

                    b.ToTable("ItensPlaylist");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.PlaylistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.ConteudoModel", b =>
                {
                    b.HasOne("ApiSistemaStreaming.Models.CriadorModel", "Criador")
                        .WithMany("Conteudos")
                        .HasForeignKey("CriadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criador");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.ItemPlaylistModel", b =>
                {
                    b.HasOne("ApiSistemaStreaming.Models.ConteudoModel", "Conteudo")
                        .WithMany("ItensPlaylist")
                        .HasForeignKey("ConteudoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiSistemaStreaming.Models.PlaylistModel", "Playlist")
                        .WithMany("Itens")
                        .HasForeignKey("PlaylistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conteudo");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.PlaylistModel", b =>
                {
                    b.HasOne("ApiSistemaStreaming.Models.UsuarioModel", "Usuario")
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.ConteudoModel", b =>
                {
                    b.Navigation("ItensPlaylist");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.CriadorModel", b =>
                {
                    b.Navigation("Conteudos");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.PlaylistModel", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("ApiSistemaStreaming.Models.UsuarioModel", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
