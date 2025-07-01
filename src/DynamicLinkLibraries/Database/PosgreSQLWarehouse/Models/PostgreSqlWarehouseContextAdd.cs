using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLWarehouse.Models
{
    partial class PostgreSqlWarehouseContext
    {

        public PostgreSqlWarehouseContext()
        {
            StaticExtension.Context = this;
        }

        public PostgreSqlWarehouseContext(DbContextOptions<PostgreSqlWarehouseContext> options)
            : base(options)
        {
            StaticExtension.Context = this;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
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
            catch (Exception ex)
            {

            }
        }



        public string Connection
        {
            get;
            set;
        } = "Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0";
    }
}
