using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MyWebApp.Models;

public partial class MysqlwarehouseContext : DbContext
{
    public MysqlwarehouseContext()
    {
    }

    public MysqlwarehouseContext(DbContextOptions<MysqlwarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Binarytable> Binarytables { get; set; }

    public virtual DbSet<Binarytree> Binarytrees { get; set; }

    public virtual DbSet<Tablew> Tablews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=mysqlwarehouse;uid=root;pwd=SQj0Myhnks!12", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Binarytable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("binarytable");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ParentId, "TableTree");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("blob");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Extension).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.ParentId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Parent).WithMany(p => p.Binarytables)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TableTree");
        });

        modelBuilder.Entity<Binarytree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("binarytree");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ParentId, "TreeTree");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Extension).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TreeTree");
        });

        modelBuilder.Entity<Tablew>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("tablew");

            entity.Property(e => e.Extension).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
