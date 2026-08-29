using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokeDex.Data.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
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

    public virtual DbSet<PokemonDroppedItem> PokemonDroppedItems { get; set; }

    public virtual DbSet<PokemonForm> PokemonForms { get; set; }

    public virtual DbSet<PokemonGame> PokemonGames { get; set; }

    public virtual DbSet<PokemonGeneration> PokemonGenerations { get; set; }

    public virtual DbSet<PokemonMap> PokemonMaps { get; set; }

    public virtual DbSet<PokemonRegion> PokemonRegions { get; set; }

    public virtual DbSet<PokemonTranslation> PokemonTranslations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3213E83FA4D4684D");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Characters)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Character__role___18EBB532");
        });

        modelBuilder.Entity<CharactersRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3213E83FB03A58B9");

            entity.HasIndex(e => e.Name, "UQ__Characte__72E12F1B78A78F64").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DexEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DexEntry__3213E83FC824733D");

            entity.ToTable("DexEntry");

            entity.HasIndex(e => new { e.PokedexId, e.DexNumber }, "UQ__DexEntry__546DDD5C06F7D98D").IsUnique();

            entity.HasIndex(e => new { e.PokemonId, e.PokedexId }, "UQ__DexEntry__7E092047B40C31C8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DexNumber).HasColumnName("dex_number");
            entity.Property(e => e.PokedexId).HasColumnName("pokedex_id");
            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");

            entity.HasOne(d => d.Pokedex).WithMany(p => p.DexEntries)
                .HasForeignKey(d => d.PokedexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntry__pokede__787EE5A0");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.DexEntries)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntry__pokemo__778AC167");
        });

        modelBuilder.Entity<DexEntryTranslation>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.LanguageCode }).HasName("PK__DexEntry__ECCCB8FE88B9FF05");

            entity.ToTable("DexEntryTranslation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("language_code");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.DexEntryTranslations)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DexEntryT__dex_e__7B5B524B");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Language__357D4CF892ACF19E");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Pokedex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pokedex__3213E83F84ED71CB");

            entity.ToTable("Pokedex");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Game)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("game");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.Property(e => e.ImageUrl).HasMaxLength(1000);
        });

        modelBuilder.Entity<PokemonDroppedItem>(entity =>
        {
            entity.ToTable("PokemonDroppedItem");

            entity.Property(e => e.ItemName).HasMaxLength(100);

            entity.HasOne(d => d.Game).WithMany(p => p.PokemonDroppedItems)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonDroppedItem_Game");

            entity.HasOne(d => d.Map).WithMany(p => p.PokemonDroppedItems)
                .HasForeignKey(d => d.MapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonDroppedItem_Map");
        });

        modelBuilder.Entity<PokemonForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.HasIndex(e => e.PokemonId, "IX_PokemonForms_PokemonId");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonForms).HasForeignKey(d => d.PokemonId);
        });

        modelBuilder.Entity<PokemonGame>(entity =>
        {
            entity.ToTable("PokemonGame");

            entity.HasIndex(e => e.Name, "UQ_PokemonGame_Name").IsUnique();

            entity.HasIndex(e => e.Slug, "UQ_PokemonGame_Slug").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(100);

            entity.HasOne(d => d.Generation).WithMany(p => p.PokemonGames)
                .HasForeignKey(d => d.GenerationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonGame_Generation");
        });

        modelBuilder.Entity<PokemonGeneration>(entity =>
        {
            entity.ToTable("PokemonGeneration");

            entity.HasIndex(e => e.Name, "UQ_PokemonGeneration_Name").IsUnique();

            entity.HasIndex(e => e.Slug, "UQ_PokemonGeneration_Slug").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Slug).HasMaxLength(50);
        });

        modelBuilder.Entity<PokemonMap>(entity =>
        {
            entity.ToTable("PokemonMap");

            entity.HasIndex(e => e.Slug, "UQ_PokemonMap_Slug").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.SvgPath).HasMaxLength(255);

            entity.HasOne(d => d.Region).WithMany(p => p.PokemonMaps)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonMap_Region");
        });

        modelBuilder.Entity<PokemonRegion>(entity =>
        {
            entity.ToTable("PokemonRegions");

            entity.HasIndex(e => e.Slug, "UQ_PokemonRegion_Slug").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(100);

            entity.HasOne(d => d.Generation).WithMany(p => p.PokemonRegions)
                .HasForeignKey(d => d.GenerationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonRegion_Generation");
        });

        modelBuilder.Entity<PokemonTranslation>(entity =>
        {
            entity.HasKey(e => new { e.PokemonId, e.LanguageCode });

            entity.ToTable("PokemonTranslation");

            entity.Property(e => e.PokemonId).HasColumnName("pokemon_id");
            entity.Property(e => e.LanguageCode).HasColumnName("language_code");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonTranslations)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PokemonTranslation_Pokemon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
