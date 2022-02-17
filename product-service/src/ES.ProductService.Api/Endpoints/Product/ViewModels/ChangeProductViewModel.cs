namespace ES.ProductService.Api.Endpoints.Product.ViewModels;

public class ChangeProductViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}