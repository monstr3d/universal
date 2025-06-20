using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosgreSQLWarehouse
{
    using Microsoft.EntityFrameworkCore;
    using Npgsql;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgis_35_warehouse;Username=postgres;Password=GREM0nP0");
            }
        }
      //  public DbSet<YourModel> YourModels { get; set; }
    }
       
}
