using Microsoft.Extensions.Configuration;

namespace ES.AuthService.Infrastructure;

public static class ConfigurationRoot
{
    public static IConfiguration Get(string outputPath, string env)
        => new ConfigurationBuilder()
            .SetBasePath(outputPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json")
            .Build();

    public static IConfiguration GetMigrationsConfiguration()
        => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
}