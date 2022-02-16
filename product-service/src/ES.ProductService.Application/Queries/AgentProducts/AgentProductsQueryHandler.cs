using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.AgentProducts;

public class AgentProductsQueryHandler : IRequestHandler<AgentProductsQuery, Product[]>
{
    public Task<Product[]> Handle(AgentProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}