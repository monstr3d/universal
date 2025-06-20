using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.VisualStudio.Services.Users;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSQLServerWarehouse
{
    public class MyDbContext : IdentityDbContext<User, Role, Key, UserLogin, UserRole, UserClaim>, IUnitOfWork
    {
        public MyDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new DbInitializer());
            Database.Initialize(true);
        }
    }
}
