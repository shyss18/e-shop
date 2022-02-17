namespace ES.ProductService.Api.Endpoints.Product.ViewModels;

public class CreateProductViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Guid AgentId { get; set; }

    public string[]? ImageUrls { get; set; }
}