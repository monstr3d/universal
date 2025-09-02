using Microsoft.EntityFrameworkCore;

namespace PostgreSQLWarehouse.Models;

public partial class PostgreSqlWarehouseContext : DbContext
{

    public virtual DbSet<BinaryTable> BinaryTables { get; set; }

    public virtual DbSet<BinaryTree> BinaryTrees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(Connection);

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
