using ES.ProductService.Domain.Entities;

namespace ES.ProductService.Api.Endpoints.Product.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Agent Agent { get; set; }

    public ProductImage[] Images { get; set; }
}