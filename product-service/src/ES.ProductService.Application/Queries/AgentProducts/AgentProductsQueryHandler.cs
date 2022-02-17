using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.AgentProducts;

public class AgentProductsQueryHandler : IRequestHandler<AgentProductsQuery, Product[]>
{
    private readonly IGenericRepository<Product> _repository;

    public AgentProductsQueryHandler(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public Task<Product[]> Handle(AgentProductsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetRangeAsync(p => p.Agent.Id == request.AgentId, cancellationToken);
    }
}