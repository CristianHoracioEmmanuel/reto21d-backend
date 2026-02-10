using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Reto21D.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var cwd = Directory.GetCurrentDirectory();

        // Busca Reto21D.Api en el directorio actual o 1 nivel arriba
        var apiPath1 = Path.Combine(cwd, "Reto21D.Api");
        var apiPath2 = Path.Combine(cwd, "..", "Reto21D.Api");

        var configBasePath =
            Directory.Exists(apiPath1) ? apiPath1 :
            Directory.Exists(apiPath2) ? apiPath2 :
            cwd;

        var config = new ConfigurationBuilder()
            .SetBasePath(configBasePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var conn = config.GetConnectionString("Default");
        if (string.IsNullOrWhiteSpace(conn))
            throw new InvalidOperationException("Connection string 'Default' no encontrada en appsettings.json.");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(conn)
            .Options;

        return new AppDbContext(options);
    }
}

