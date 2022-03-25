using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ES.AuthService.Infrastructure;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var configuration = ConfigurationRoot.GetMigrationsConfiguration();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("IdentityServerContext"));

        return new ApplicationContext(optionsBuilder.Options);
    }
}