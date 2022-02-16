namespace ES.ProductService.Infrastructure.Models;

public class ProductImageModel
{
    public Guid Id { get; set; }

    public string Url { get; set; }

    public Guid ProductId { get; set; }

    public ProductModel Product { get; set; }
}