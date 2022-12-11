using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FromTheTable.Persistence;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var stringBuilder = new StringBuilder(Directory.GetCurrentDirectory());
        var pathToApiDirectory = stringBuilder.Replace("Persistence", "Api").ToString();
        
        var config = new ConfigurationBuilder()
            .SetBasePath(pathToApiDirectory)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseSqlite(config.GetConnectionString("sqliteConnectionString"));

        return new ApplicationDbContext(optionsBuilder.Options); }
}