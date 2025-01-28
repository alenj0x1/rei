using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Rei.Infrastructure;

namespace Rei.Infrastructure.Context;

public partial class ReiDbContext : DbContext
{
    public ReiDbContext()
    {
    }

    public ReiDbContext(DbContextOptions<ReiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialsLocation> MaterialsLocations { get; set; }

    public virtual DbSet<World> Worlds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("materials_pkey");

            entity.ToTable("materials");

            entity.HasIndex(e => e.Name, "materials_name_key").IsUnique();

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("'ups!, without a description'::character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MaterialsLocation>(entity =>
        {
            entity.HasKey(e => e.MaterialLocationId).HasName("materials_location_pkey");

            entity.ToTable("materials_location");

            entity.Property(e => e.MaterialLocationId).HasColumnName("material_location_id");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.WorldId).HasColumnName("world_id");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialsLocationMaterials)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materials_location_material_id_fkey");

            entity.HasOne(d => d.World).WithMany(p => p.MaterialsLocationWorlds)
                .HasForeignKey(d => d.WorldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materials_location_world_id_fkey");
        });

        modelBuilder.Entity<World>(entity =>
        {
            entity.HasKey(e => e.WorldId).HasName("worlds_pkey");

            entity.ToTable("worlds");

            entity.HasIndex(e => e.Name, "worlds_name_key").IsUnique();

            entity.Property(e => e.WorldId).HasColumnName("world_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'ups!, without a description'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
