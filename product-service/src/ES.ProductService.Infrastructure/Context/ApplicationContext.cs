using ES.ProductService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ES.ProductService.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public const string ConnectionString = "ApplicationContext";
    
    public const string MigrationAssembly = "ES.ProductService.Api";
    
    public DbSet<ProductModel> Products { get; set; }

    public DbSet<ProductImageModel> ProductImages { get; set; }

    public DbSet<AgentModel> Agents { get; set; }

    public DbSet<AgentContactInfoModel> AgentsContactInfo { get; set; }

    public DbSet<CompanyModel> Companies { get; set; }

    public DbSet<CompanyContactInfoModel> CompaniesContactInfo { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
}