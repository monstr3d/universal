using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SQLServerWarehouse.Models;

#nullable disable

namespace SQLServerWarehouse
{
    public partial class DataWarehouseContext : DbContext
    {
        public DataWarehouseContext()
        {
        }

        public DataWarehouseContext(DbContextOptions<DataWarehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinaryTable> BinaryTables { get; set; }
        public virtual DbSet<BinaryTree> BinaryTrees { get; set; }
        public virtual DbSet<ViewBinaryTableId> ViewBinaryTableIds { get; set; }
        public virtual DbSet<ViewBinaryTableInfo> ViewBinaryTableInfos { get; set; }
        public virtual DbSet<ViewBinaryTreeId> ViewBinaryTreeIds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(StaticExtension.ConnectionString);
                    //"Server=IVANKOV\\SQLExpress;Database=AstronomyExpress;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinaryTable>(entity =>
            {
                entity.ToTable("BinaryTable");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Length)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.BinaryTables)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinaryTable_BinaryTree");
            });

            modelBuilder.Entity<BinaryTree>(entity =>
            {
                entity.ToTable("BinaryTree");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ext")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinaryTree_BinaryTree");
            });

            modelBuilder.Entity<ViewBinaryTableId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBinaryTableId");
            });

            modelBuilder.Entity<ViewBinaryTableInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBinaryTableInfo");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ViewBinaryTreeId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBinaryTreeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
