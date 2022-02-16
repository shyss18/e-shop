namespace ES.ProductService.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Agent Agent { get; set; }

    public ProductImage[] Images { get; set; }
}