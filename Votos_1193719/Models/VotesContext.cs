using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Votos_1193719.Models;

public partial class VotesContext : DbContext
{
    public VotesContext()
    {
    }

    public VotesContext(DbContextOptions<VotesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Votante> Votantes { get; set; }

    public virtual DbSet<Voto> Votos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
            var connectionString = configuration.GetConnectionString("VotesDB");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidato");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.PartidoPolitico)
                .HasMaxLength(30)
                .HasColumnName("partido_politico");
        });

        modelBuilder.Entity<Votante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("votante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Ip)
                .HasMaxLength(15)
                .HasColumnName("ip");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Voto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("votos");

            entity.HasIndex(e => e.IdCandidato, "votos_fk0");

            entity.HasIndex(e => e.IdVotante, "votos_fk1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCandidato).HasColumnName("id_candidato");
            entity.Property(e => e.IdVotante).HasColumnName("id_votante");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdCandidato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("votos_fk0");

            entity.HasOne(d => d.IdVotanteNavigation).WithMany(p => p.Votos)
                .HasForeignKey(d => d.IdVotante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("votos_fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
