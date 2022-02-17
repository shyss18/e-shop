using MediatR;

namespace ES.ProductService.Application.Commands.ChangeProduct;

public class ChangeProductCommand : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}