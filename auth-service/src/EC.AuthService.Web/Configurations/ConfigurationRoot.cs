namespace EC.AuthService.Web.Configurations;

public static class ConfigurationRoot
{
    public static IConfiguration Get(string outputPath, string env) {
        return new ConfigurationBuilder()
            .SetBasePath(outputPath)
            .AddJsonFile($"appsettings.json")
            .AddJsonFile($"appsettings.{env}.json")
            .Build();
    }   
}