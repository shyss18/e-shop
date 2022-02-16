namespace ES.ProductService.Infrastructure.Models;

public class ProductModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Guid AgentId { get; set; }

    public AgentModel Agent { get; set; }

    public ICollection<ProductImageModel> Images { get; set; }

    public ProductModel()
    {
        Images = new List<ProductImageModel>();
    }
}