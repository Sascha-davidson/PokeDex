using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;

namespace PokeDex.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharactersRole> CharactersRoles { get; set; }

    public virtual DbSet<DexEntry> DexEntries { get; set; }

    public virtual DbSet<DexEntryTranslation> DexEntryTranslations { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Pokedex> Pokedices { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonForm> PokemonForms { get; set; }

    public virtual DbSet<PokemonTranslation> PokemonTranslations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Characte__3213E83FA4D4684D");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.role).WithMany(p => p.Characters)
                .HasForeignKey(d => d.role_id)
                .HasConstraintName("FK__Character__role___18EBB532");
        });

        modelBuilder.Entity<CharactersRole>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Characte__3213E83FB03A58B9");

            entity.HasIndex(e => e.name, "UQ__Characte__72E12F1B78A78F64").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DexEntry>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__DexEntry__3213E83FC824733D");

            entity.ToTable("DexEntry");

            entity.HasIndex(e => new { e.pokedex_id, e.dex_number }, "UQ__DexEntry__546DDD5C06F7D98D").IsUnique();

            entity.HasIndex(e => new { e.pokemon_id, e.pokedex_id }, "UQ__DexEntry__7E092047B40C31C8").IsUnique();

            entity.HasOne(d => d.pokedex).WithMany(p => p.DexEntries)
                .HasForeignKey(d => d.pokedex_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntry__pokede__787EE5A0");

            entity.HasOne(d => d.pokemon).WithMany(p => p.DexEntries)
                .HasForeignKey(d => d.pokemon_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntry__pokemo__778AC167");
        });

        modelBuilder.Entity<DexEntryTranslation>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.language_code }).HasName("PK__DexEntry__ECCCB8FE88B9FF05");

            entity.ToTable("DexEntryTranslation");

            entity.Property(e => e.language_code)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IDNavigation).WithMany(p => p.DexEntryTranslations)
                .HasForeignKey(d => d.ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntryT__dex_e__7B5B524B");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.code).HasName("PK__Language__357D4CF892ACF19E");

            entity.Property(e => e.code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.name).HasMaxLength(50);
        });

        modelBuilder.Entity<Pokedex>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__pokedex__3213E83F84ED71CB");

            entity.ToTable("Pokedex");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.game)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.region)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PokemonForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.HasIndex(e => e.PokemonId, "IX_PokemonForms_PokemonId");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonForms).HasForeignKey(d => d.PokemonId);
        });

        modelBuilder.Entity<PokemonTranslation>(entity =>
        {
            entity.HasKey(e => new { e.pokemon_id, e.language_code });

            entity.ToTable("PokemonTranslation");

            entity.Property(e => e.name).HasMaxLength(100);

            entity.HasOne(d => d.pokemon).WithMany(p => p.PokemonTranslations)
                .HasForeignKey(d => d.pokemon_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonTranslation_Pokemon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
