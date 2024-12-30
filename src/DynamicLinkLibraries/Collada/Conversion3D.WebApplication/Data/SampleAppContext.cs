using Microsoft.EntityFrameworkCore;
using Conversion3D.WebApplication.Models;

namespace Conversion3D.WebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppFile> File { get; set; }
    }
}
