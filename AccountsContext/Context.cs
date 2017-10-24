using AccountsEntity;
using System.Data.Entity;

namespace AccountsContext
{
    public class Context : DbContext
    {
        public Context() : base("Account")
        {

            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        public DbSet<EUser> Users { get; set; }
        public DbSet<ERole> Roles { get; set; }
        public DbSet<EUserRole> UserRoles { get; set; }
    }

}
