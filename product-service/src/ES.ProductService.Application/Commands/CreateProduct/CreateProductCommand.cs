using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Guid AgentId { get; set; }

    public ProductImage[] Images { get; set; }
}