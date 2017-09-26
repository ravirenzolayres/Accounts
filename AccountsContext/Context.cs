using AccountsEntity;
using System.Data.Entity;

namespace AccountsContext
{
    public class Context : DbContext
    {
        public Context() : base("Account")
        {
            Database.SetInitializer(new DBInitializer());

            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        public class DBInitializer : CreateDatabaseIfNotExists<Context>
        {
            public DBInitializer()
            {
            }
        }
        public DbSet<EUser> Users { get; set; }
        public DbSet<ERole> Roles { get; set; }
        public DbSet<EUserRole> UserRoles { get; set; }
    }

}
