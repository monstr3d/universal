using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PosgreSQLWarehouse.Models;

public partial class PostgreSqlWarehouseContext : DbContext
{
    public PostgreSqlWarehouseContext()
    {
    }

    public PostgreSqlWarehouseContext(DbContextOptions<PostgreSqlWarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BinaryTable> BinaryTables { get; set; }

    public virtual DbSet<BinaryTree> BinaryTrees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<BinaryTable>(entity =>
        {
            entity.ToTable("BinaryTable");

            entity.HasIndex(e => e.ParentId, "IX_BinaryTable_ParentId");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Ext).HasMaxLength(10);
            entity.Property(e => e.Length).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Parent).WithMany(p => p.BinaryTables)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BinaryTable_BinaryTree");
        });

        modelBuilder.Entity<BinaryTree>(entity =>
        {
            entity.ToTable("BinaryTree");

            entity.HasIndex(e => e.ParentId, "IX_BinaryTree_ParentId");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Ext)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ext");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BinaryTree_BinaryTree");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
