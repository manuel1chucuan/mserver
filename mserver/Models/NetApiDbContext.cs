using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mserver.Models;

public partial class NetApiDbContext : DbContext
{
    public NetApiDbContext()
    {
    }

    public NetApiDbContext(DbContextOptions<NetApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<TipoComidum> TipoComida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=NetApiDb;User Id=sa;Password=as123456;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.ComidaId).HasName("PK__comida__142E624D4D699310");

            entity.ToTable("comida");

            entity.HasIndex(e => e.NombreComida, "UQ__comida__8D79F10FEC98F545").IsUnique();

            entity.Property(e => e.ComidaId).HasColumnName("comida_id");
            entity.Property(e => e.NombreComida)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_comida");
            entity.Property(e => e.TipoComidaId).HasColumnName("tipo_comida_id");

            entity.HasOne(d => d.TipoComida).WithMany(p => p.Comida)
                .HasForeignKey(d => d.TipoComidaId)
                .HasConstraintName("FK__comida__tipo_com__73BA3083");
        });

        modelBuilder.Entity<TipoComidum>(entity =>
        {
            entity.HasKey(e => e.TipoComidaId).HasName("PK__tipo_com__B2E0C997D893EE09");

            entity.ToTable("tipo_comida");

            entity.HasIndex(e => e.TipoComida, "UQ__tipo_com__2EE6F644CE4C09BA").IsUnique();

            entity.Property(e => e.TipoComidaId).HasColumnName("tipo_comida_id");
            entity.Property(e => e.TipoComida)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_comida");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
