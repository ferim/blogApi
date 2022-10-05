using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace blogApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseMySql(configuration.GetConnectionString("dbConnection"),
                    // Replace with your server version and type.
                    new MySqlServerVersion(new Version(5, 7, 32)),
                    x => x.MigrationsAssembly("blogApi")
                    )
                    // Everything from this point on is optional but helps with debugging.
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();

            return new RepositoryContext(builder.Options);
        }
    }
}
