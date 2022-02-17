using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using MediatR;

namespace ES.ProductService.Application.Queries.Products;

public class ProductsQueryHandler : IRequestHandler<ProductsQuery, Product[]>
{
    private readonly IGenericRepository<Product> _repository;

    public ProductsQueryHandler(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public Task<Product[]> Handle(ProductsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetRangeAsync(cancellationToken);
    }
}