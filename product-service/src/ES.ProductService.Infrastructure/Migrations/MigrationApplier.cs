using ES.ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ES.ProductService.Infrastructure.Migrations;

public class MigrationApplier : IMigrationApplier
{
    private readonly ApplicationContext _context;
    private readonly ILogger<MigrationApplier> _logger;

    public MigrationApplier(
        ApplicationContext context,
        ILogger<MigrationApplier> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Apply()
    {
        _logger.LogInformation("Start applying migrations");

        try
        {
            _context.Database.Migrate();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception was thrown when trying apply migrations");
            throw;
        }
        finally
        {
            foreach (var migrationName in _context.Database.GetAppliedMigrations())
            {
                _logger.LogInformation($"Migration {migrationName} was successfully applied");
            }

            _logger.LogInformation("Finish applying migrations");
        }
    }
}