using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleSQLServerWarehouse.OutputDirectory
{
    public partial class AstronomyExpressContext : DbContext
    {
        public AstronomyExpressContext()
        {
        }

        public AstronomyExpressContext(DbContextOptions<AstronomyExpressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinaryTable> BinaryTable { get; set; }
        public virtual DbSet<BinaryTree> BinaryTree { get; set; }
        public virtual DbSet<ViewBinaryTableId> ViewBinaryTableId { get; set; }
        public virtual DbSet<ViewBinaryTableInfo> ViewBinaryTableInfo { get; set; }
        public virtual DbSet<ViewBinaryTreeId> ViewBinaryTreeId { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AstronomyExpress;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinaryTable>(entity =>
            {
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
                    .WithMany(p => p.BinaryTable)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinaryTable_BinaryTree");
            });

            modelBuilder.Entity<BinaryTree>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasColumnName("ext")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

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

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ViewBinaryTreeId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewBinaryTreeId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ext)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
