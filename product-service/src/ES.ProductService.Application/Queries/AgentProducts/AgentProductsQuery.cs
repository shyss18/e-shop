using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.AgentProducts;

public class AgentProductsQuery : IRequest<Product[]>
{
    public Guid AgentId { get; set; }
}