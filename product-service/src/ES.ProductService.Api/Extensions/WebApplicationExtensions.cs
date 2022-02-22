using ES.ProductService.Infrastructure.Migrations;

namespace ES.ProductService.Api.Extensions;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder ApplyMigrations(
        this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var migrationApplier = scope.ServiceProvider.GetService<IMigrationApplier>();

        migrationApplier!.Apply();

        return app;
    }
}