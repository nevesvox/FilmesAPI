using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Database
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(e => e.Cinema)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Cinema>(c => c.EnderecoId);

            builder.Entity<Cinema>()
                .HasOne(c => c.Gerente)
                .WithMany(g => g.Cinemas)
                .HasForeignKey(c => c.GerenteId);

            builder.Entity<Sessao>()
                .HasOne(s => s.Filme)
                .WithMany(f => f.Sessoes)
                .HasForeignKey(s => s.FilmeId);

            builder.Entity<Sessao>()
                .HasOne(s => s.Cinema)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(s => s.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
